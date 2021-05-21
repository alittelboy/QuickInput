using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace QuickInput
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(int vKey);


        bool[] keys = new Boolean[255];
        bool[] keys_before = new Boolean[255];

        string[] values = new String[255];
        private string splitChar = "";
        private string iniPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\QuickInputSet.ini";
        private bool testMode = false;
        void timer_Tick()
        {

            
            GetPressedKey();

            if (testMode)
            {
                Text = string.Concat("TimerWindow  ", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                //输出看看
                for (int i = 0; i < 255; i++)
                {
                    if (keys[i])
                    {
                        this.Text += " " + i;
                    }
                }
            }


            // output快捷键 空格32+编队
            if (keys[32])
            {
                for (int i = 0; i < 255; i++)
                {
                    if (!keys[i] && keys_before[i])
                    {
                        SendKeys.SendWait("{BKSP}");
                        SendKeys.SendWait("{BKSP}");
                        SendKeys.SendWait(values[i]);
                        return;
                    }
                }
            }
            //ctrl 17 编队，只能0-9，48-57
            if(keys[17] && !keys[16])
            {
                for (int i = 48; i < 58; i++)
                {
                    if (!keys[i] && keys_before[i])
                    {
                        SendKeys.SendWait("^c");
                        setValue(i, Clipboard.GetText());
                        SendKeys.SendWait("^");//释放ctrl
                        return;
                    }
                }
            }

            //ctrl 17 + shift 16 add 编队，只能0-9
            if (keys[17] && keys[16])
            {
                for (int i = 48; i < 58; i++)
                {
                    if (!keys[i] && keys_before[i])
                    {
                        string tmp = values[i];
                        SendKeys.SendWait("^c");
                        string tmp2 = Clipboard.GetText();
                        setValue(i,tmp + splitChar + tmp2);
                        SendKeys.SendWait("^");//释放ctrl
                        SendKeys.SendWait("+");//释放shift
                        return;
                    }
                }
            }


        }

        private void GetPressedKey()
        {
            for (int i = 0; i < 255; i++)
            {
                keys_before[i] = keys[i];
                keys[i] = GetAsyncKeyState(i) != 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //设置timer
            timer1.Interval = 10;   //设置刷新的间隔时间
            timer1.Enabled = true;

            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ReadOnly = true;

            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.ReadOnly = true;
            this.textBox2.Text = iniPath;

            if (testMode)
            {
                for (int i = 0; i < 255; i++)
                {
                    values[i] = "test";
                }
            }
        
            read();

        }
                

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer_Tick();
        }
        private void save()
        {
            for (int i = 48; i < 57; i++)
            {
                if (!values[i].Equals(""))
                {
                    IniManager.Write("words", i.ToString(), values[i], iniPath);
                }
            }
        }

        private void read()
        {
            
            for (int i = 0; i < 255; i++)
            {
                values[i] = IniManager.Read("words", "" + i, "", iniPath, true);
            }
        }

        private void setValue(int index, String val, Boolean needsave = true)
        {
            Console.WriteLine("Set " + index + ": " +  val);
            //做一些反转义的处理
            values[index] = val.Replace("\r\n", "{ENTER}");
            values[index] = val.Replace("\n", "{ENTER}");

            if (needsave)
            {
                save();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //IniManager.WriteHelp(iniPath);
            read();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            testMode = checkBox1.Checked;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
    class IniManager
    {
        /// <summary>
        /// 为INI文件中指定的节点取得字符串
        /// </summary>
        /// <param name="lpAppName">欲在其中查找关键字的节点名称</param>
        /// <param name="lpKeyName">欲获取的项名</param>
        /// <param name="lpDefault">指定的项没有找到时返回的默认值</param>
        /// <param name="lpReturnedString">指定一个字串缓冲区，长度至少为nSize</param>
        /// <param name="nSize">指定装载到lpReturnedString缓冲区的最大字符数量</param>
        /// <param name="lpFileName">INI文件完整路径</param>
        /// <returns>复制到lpReturnedString缓冲区的字节数量，其中不包括那些NULL中止字符</returns>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        /// <summary>
        /// 修改INI文件中内容
        /// </summary>
        /// <param name="lpApplicationName">欲在其中写入的节点名称</param>
        /// <param name="lpKeyName">欲设置的项名</param>
        /// <param name="lpString">要写入的新字符串</param>
        /// <param name="lpFileName">INI文件完整路径</param>
        /// <returns>非零表示成功，零表示失败</returns>
        [DllImport("kernel32")]
        private static extern int WritePrivateProfileString(string lpApplicationName, string lpKeyName, string lpString, string lpFileName);



        /// <summary>
        /// 读取INI文件值
        /// </summary>
        /// <param name="section">节点名</param>
        /// <param name="key">键</param>
        /// <param name="def">未取到值时返回的默认值</param>
        /// <param name="filePath">INI文件完整路径</param>
        /// <returns>读取的值</returns>
        public static string Read(string section, string key, string def, string filePath, bool check = false)
        {
            if (check)
            {
                CheckPath(filePath);
            }
            
            StringBuilder sb = new StringBuilder(1024);
            GetPrivateProfileString(section, key, def, sb, 1024, filePath);
            return sb.ToString();
        }

        /// <summary>
        /// 写INI文件值
        /// </summary>
        /// <param name="section">欲在其中写入的节点名称</param>
        /// <param name="key">欲设置的项名</param>
        /// <param name="value">要写入的新字符串</param>
        /// <param name="filePath">INI文件完整路径</param>
        /// <returns>非零表示成功，零表示失败</returns>
        public static int Write(string section, string key, string value, string filePath)
        {
            CheckPath(filePath);
            return WritePrivateProfileString(section, key, value, filePath);
        }

        private static void CheckPath(string filePath)
        {
            if (!File.Exists(filePath))
            {                
                File.Create(filePath).Dispose();//创建INI文件，并释放                              
            }
            WriteHelp(filePath);
        }

        public static void WriteHelp(string filePath)
        {
            if (Read("words", "65", "", filePath).Equals("")){
                WritePrivateProfileString("words", "65", "空格 加 a以输入这行数据，需要关闭中文输入法。65-81对应a-z", filePath);
            }
            if (Read("words", "66", "", filePath).Equals(""))
            {
                WritePrivateProfileString("words", "66", "空格 加 b以输入这行数据，需要关闭中文输入法。{ENTER}表示换行，{+}、{^}、{%}等符号有特殊含义，可以看底部链接说明。", filePath);
            }
            WritePrivateProfileString("ReadMe", "KeyCode", "You can get value-key relation in this link. https://www.bejson.com/othertools/keycodes/", filePath);
            WritePrivateProfileString("ReadMe", "SendKeys", "You can set special words by this way. https://www.cnblogs.com/shaozhuyong/p/5951779.html", filePath);
        }
        /// <summary>
        /// 删除节
        /// </summary>
        /// <param name="section">节点名</param>
        /// <param name="filePath">INI文件完整路径</param>
        /// <returns>非零表示成功，零表示失败</returns>
        public static int DeleteSection(string section, string filePath)
        {
            return Write(section, null, null, filePath);
        }

        /// <summary>
        /// 删除键的值
        /// </summary>
        /// <param name="section">节点名</param>
        /// <param name="key">键名</param>
        /// <param name="filePath">INI文件完整路径</param>
        /// <returns>非零表示成功，零表示失败</returns>
        public static int DeleteKey(string section, string key, string filePath)
        {
            return Write(section, key, null, filePath);
        }
    }
}
