using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using System.Diagnostics;
using System.IO;
using File = System.IO.File;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace QuickInput
{
    public partial class Form1 : Form
    {
        public static string myName = System.IO.Path.GetFileName(Application.ExecutablePath);
        public static string myPath = Application.ExecutablePath;
        public static string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string startupPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
        public static string startupFullPath = startupPath + "\\QuickInput.lnk";
        public static string quickInputSet = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\quickInputSet";
        public static string sPath = Environment.GetEnvironmentVariable("AppData");
        public static string sendtoPath = sPath + "\\Microsoft\\Windows\\SendTo\\";

        public string iniPath = quickInputSet + "\\QuickInputSet.ini";
        int setMode = 0;
        public string[] args = null;
        //string[] values = IniManager.values;
        Dictionary<int, string> valuesDic = IniManager.valuesDic;

        public Form1(string[] args = null)
        {
            //参数表模式
            if (args != null)
            {
                this.args = args;
                setMode = 1;
            }
            
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(int vKey);


        bool[] keys = new Boolean[255];
        bool[] keys_before = new Boolean[255];


        private string splitChar = "";
        private bool testMode = false;
        string initial_title = "";
        int hotKeyOut = 32;//空格

        int[] press_test = new int[255];


        void timer_Tick()
        {

            //readWithoutNumber();
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
            if (keys[hotKeyOut] && keys_before[hotKeyOut])
            {
                for (int i = 0; i < 255; i++)
                {
                    if (keys[i] && !keys_before[i])
                    {
                        if (valuesDic.ContainsKey(i) && !valuesDic[i].Equals(""))//为空不输出
                        {

                            SendOutByI(i);
                            return;
                        }

                    }
                }
            }
            //ctrl 17 编队，只能0-9，48-57
            if (keys[17] && keys_before[17] && !keys[16])
            {
                for (int i = 48; i < 58; i++)
                {
                    if (keys[i] && !keys_before[i])
                    {
                        SendKeys.SendWait("^c");
                        setValue(i, Clipboard.GetText());
                        SendKeys.SendWait("^");//释放ctrl
                        return;
                    }
                }
            }

            //ctrl 17 + shift 16 add 编队，只能0-9
            if (keys[17] && keys_before[17] && keys[16] && keys_before[16])
            {
                for (int i = 48; i < 58; i++)
                {
                    if (keys[i] && !keys_before[i])
                    {
                        string tmp = valuesDic[i];
                        SendKeys.SendWait("^c");
                        string tmp2 = Clipboard.GetText();
                        setValue(i, tmp + splitChar + tmp2);
                        SendKeys.SendWait("^");//释放ctrl
                        SendKeys.SendWait("+");//释放shift
                        return;
                    }
                }
            }


        }

        private void SendOutByI(int i)
        {
            
            string tmp = valuesDic[i];

            if (tmp.IndexOf("QuickInputRun:")==0)
            {
                string com = tmp.Substring("QuickInputRun:".Length);
                WshShell shell = new WshShell();
                shell.Run(com);
                return;
            }
            if (Directory.Exists(tmp))
            {
                ExplorePath(tmp);
            }
            else if (File.Exists(tmp))
            {
                WshShell shell = new WshShell();
                shell.Run(tmp);
                return;
            }
            else if (IsUrl(tmp))
            {
                openAppWeb(tmp);
            }
            else
            {
                SendKeys.SendWait("{BKSP}");
                SendKeys.SendWait("{BKSP}");
                SendKeys.SendWait(tmp);
            }
            
        }

        private void GetPressedKey()
        {
            for (int i = 0; i < 255; i++)
            {
                keys_before[i] = keys[i];
                press_test[i] = GetAsyncKeyState(i);
                keys[i] = press_test[i] != 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            IniManager.init(this);
            if (!File.Exists(quickInputSet))
            {
                Directory.CreateDirectory(quickInputSet);
            }
            // 用于解决文件移动以后，快捷方式可能的问题
            if (File.Exists(startupFullPath))
            {
                File.Delete(startupFullPath);
                setStartUp(0,false);
            }
            // 在启动时有命令行时，执行设置模式，不启动窗体功能
            //if (setMode == 1)
            //{
            //    MessageBox.Show("123");
            //    // 关闭计时器等
            //    // inputbox
            //    // 设置快捷键
            //    // 退出
            //}

            //设置timer
            timer1.Interval = 30;   //设置刷新的间隔时间
            timer1.Enabled = true;

            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.ReadOnly = true;

            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.ReadOnly = true;
            this.textBox2.Text = iniPath;

            initial_title = this.Text;
            Size = new System.Drawing.Size(480, 180);

            if (testMode)
            {
                for (int i = 0; i < 255; i++)
                {
                    valuesDic[i] = "test";
                }
            }

            read();

            设置开机启动ToolStripMenuItem.Checked = System.IO.File.Exists(startupFullPath);

            //判断是否隐藏窗体，托盘启动
            string tmp = IniManager.Read("initialization", "openshow", "", iniPath);
            启动不显示窗体ToolStripMenuItem.Checked = !tmp.Equals("no");

            if (tmp.Equals("no"))
            {
                this.BeginInvoke(new Action(() =>
                {
                    this.Hide();
                }));
            }
            //这里取消透明，本来窗体是透明的，以此防止闪一下
            this.BeginInvoke(new Action(() =>
            {
                this.Opacity = 1;
            }));
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            timer_Tick();
        }
        private void save()
        {
            IniManager.writeIni(valuesDic, true);
        }

        private void read()
        {

            valuesDic = IniManager.readIni();
        }

        private void readWithoutNumber()
        {
            valuesDic = IniManager.readIni(false);
        }

        private void setValue(int index, String val, Boolean needsave = true)
        {
            Console.WriteLine("Set " + index + ": " + val);
            //做一些反转义的处理
            valuesDic[index] = val.Replace("\r\n", "{ENTER}");
            valuesDic[index] = val.Replace("\n\r", "{ENTER}");
            valuesDic[index] = val.Replace("\n", "{ENTER}");
            valuesDic[index] = val.Replace("\r", "{ENTER}");
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

        private void openSetIni()
        {
            System.Diagnostics.Process.Start("explorer.exe", iniPath);   //直接打开文件Readme.txt
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openSetIni();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {

        }

        private void openAppWeb(string url = "")
        {
            string target = url.Equals("") ? "https://github.com/alittelboy/QuickInput" : url;
            //Use no more than one assignment when you test this code. 
            //string target = "ftp://ftp.microsoft.com"; 
            //string target = "C:\\Program Files\\Microsoft Visual Studio\\INSTALL.HTM"; 

            try
            {
                System.Diagnostics.Process.Start(target);
            }
            catch
                (
                 System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openAppWeb();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            iniPath = textBox2.Text;
        }

        /// <summary>
        ///     This method creates a shortcut
        /// </summary>
        /// <param name="shortcutName">The name of the shortcut</param>
        /// <param name="shortcutPath">The location of the shortcut</param>
        /// <param name="targetFileLocation">What should be linked</param>
        /// Require "using IWshRuntimeLibrary;", and a reference to Windows Script Host Model
        public static void createShortcut(string shortcutName, string shortcutPath, string targetFileLocation)
        {
            string shortcutLocation = System.IO.Path.Combine(shortcutPath, shortcutName + ".lnk");
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

            shortcut.Description = "Keys";
            shortcut.TargetPath = targetFileLocation;
            shortcut.Save();
        }


        private void setStartUp(int code = 0,bool show = true)
        {
            if (code == 0)
            {
                // 设置开机启动
                if (!System.IO.File.Exists(startupFullPath))
                {
                    createShortcut("QuickInput", startupPath, myPath);
                    if (show) MessageBox.Show("设置成功" + startupFullPath); 
                    
                    设置开机启动ToolStripMenuItem.Checked = true;
                }
                else
                {
                    if(show)MessageBox.Show("设置失败，文件已经存在：" + startupFullPath);
                }
            }
            else
            {
                // 取消开机启动
                if (System.IO.File.Exists(startupFullPath))
                {
                    System.IO.File.Delete(startupFullPath);
                    if(show)MessageBox.Show("设置成功，已经删除" + startupFullPath);
                    设置开机启动ToolStripMenuItem.Checked = false;

                }
                else
                {
                    if(show)MessageBox.Show("设置失败，文件已经 不 存在：" + startupFullPath);
                }
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            setStartUp();
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openSetting(false);
        }

        private void 官网ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openAppWeb();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                string closed = IniManager.Read("initialization", "minimized", "", iniPath);
                if (closed.Equals(""))
                {
                    IniManager.Write("initialization", "minimized", "reminded", iniPath);
                    MessageBox.Show("软件将会变成托盘运行。\n下次不会提示。");
                }
                this.Hide();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                string closed = IniManager.Read("initialization", "closed", "", iniPath);
                if (closed.Equals(""))
                {
                    IniManager.Write("initialization", "closed", "reminded", iniPath);
                    MessageBox.Show("软件会变成托盘运行，右键托盘以退出。\n下次不会提示。");
                }

                e.Cancel = true;
                this.Hide();
            }

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void setOpenShow(int code = 0)
        {
            switch (code)
            {
                case 0:
                    //设置托盘启动
                    IniManager.Write("initialization", "openshow", "no", iniPath);
                    break;
                case 1:
                    //设置正常启动
                    IniManager.Write("initialization", "openshow", "", iniPath);
                    break;
                default:
                    break;
            }
        }


        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Show();
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Show();
            }

        }

        private void placeHolderTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                timer1.Interval = int.Parse(placeHolderTextBox1.Text);
            }
            catch (Exception)
            {

                ;
            }
        }

        private void 网站ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openAppWeb();
        }

        private void 托盘模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 读取设置文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            read();
            MessageBox.Show("读取设置成功！", "提示");
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string helpmsg = "使用说明：\n快捷输入\n空格 + 字母/数字/其他键盘按键：根据设置自动发送对应编队存储的按键。\n\n快捷编队\nCtrl + 数字： 将当前选中内容复制，并添加到数字对应的编队。\n\n增加到编队\nCtrl + Shift + 数字： 将当前选中内容复制到剪切板，并添加到编队保存的内容的后面。\n\n编辑QuickInputSet.ini文件以快速修改词库和设置。\n\n更多帮助请看“网站”。";
            MessageBox.Show(helpmsg, "帮助");
        }

        private void 启动不显示窗体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tmp = IniManager.Read("initialization", "openshow", "", iniPath);
            if (!tmp.Equals("no"))
            {
                启动不显示窗体ToolStripMenuItem.Checked = false;
                MessageBox.Show("已经设置为启动时 不 显示窗体！", "提示");
                setOpenShow(0);
            }
            else
            {
                启动不显示窗体ToolStripMenuItem.Checked = true;
                MessageBox.Show("已经设置为启动时显示窗体！", "提示");
                setOpenShow(1);
            }
        }

        private void 打开设置文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openSetIni();
        }

        private void 设置开机启动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(startupFullPath))
            {
                setStartUp();
            }
            else
            {
                setStartUp(1);
            }


        }

        private void 测试模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            测试模式ToolStripMenuItem.Checked = !测试模式ToolStripMenuItem.Checked;
            testMode = 测试模式ToolStripMenuItem.Checked;
            if (testMode)
            {
                Size = new System.Drawing.Size(480, 250);
                placeHolderTextBox1.Visible = true;
                placeHolderTextBox2.Visible = true;
                this.textBox3.BackColor = System.Drawing.SystemColors.Window;
                this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.textBox3.ReadOnly = false;

                this.textBox2.BackColor = System.Drawing.SystemColors.Window;
                this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.textBox2.ReadOnly = false;
            }
            else
            {
                Size = new System.Drawing.Size(480, 180);
                
                placeHolderTextBox1.Visible = false;
                placeHolderTextBox2.Visible = false;
                this.textBox3.BackColor = System.Drawing.SystemColors.Control;
                this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
                this.textBox3.ReadOnly = true;

                this.textBox2.BackColor = System.Drawing.SystemColors.Control;
                this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
                this.textBox2.ReadOnly = true;

                this.Text = initial_title;
            }
        }

        private void 按键码查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openAppWeb("https://www.bejson.com/othertools/keycodes/");
        }

        private void 转移查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openAppWeb("https://www.cnblogs.com/shaozhuyong/p/5951779.html");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void open打开设置文件ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //选择文件
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//该值确定是否可以选择多个文件
            dialog.Title = "请选择设置文件";
            dialog.Filter = "设置文件(*.ini)|*.ini";
            dialog.InitialDirectory = quickInputSet;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                iniPath = dialog.FileName;
            }
            textBox2.Text = iniPath;
        }
        /// <summary>
        /// 浏览文件
        /// </summary>
        /// <param name="filePath"></param>
        public static void ExploreFile(string filePath)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = "explorer";
            //打开资源管理器
            proc.StartInfo.Arguments = @"/select," + filePath;
            //选中"notepad.exe"这个程序,即记事本
            proc.Start();
        }

        /// <summary>
        /// 浏览文件夹
        /// </summary>
        /// <param name="path"></param>
        public static void ExplorePath(string path)
        {
            System.Diagnostics.Process.Start("explorer.exe", path);
        }

        private void 打开设置文件目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExploreFile(iniPath);
        }

        private void 另存为设置文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "设置文件(*.ini)|*.ini";//设置文件类型
            sfd.FileName = "QuickInputSet";//设置默认文件名
            sfd.DefaultExt = "ini";//设置默认格式（可以不设）
            sfd.AddExtension = true;//设置自动在文件名中添加扩展名
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(sfd.FileName))
                {
                    File.Delete(sfd.FileName);
                }
                File.Copy(iniPath, sfd.FileName);
                iniPath = sfd.FileName;
                textBox2.Text = iniPath;
            }
        }

        private void placeHolderTextBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                hotKeyOut = int.Parse(placeHolderTextBox1.Text);
            }
            catch (Exception)
            {

                ;
            }
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("developing!","sorry");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            WshShell shell = new WshShell();
            shell.Run("cmd");
        }

        /// <summary>
        /// 判断一个字符串是否为url
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsUrl(string str)
        {
            try
            {
                string Url = @"^http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$";
                return Regex.IsMatch(str, Url);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void 高级功能使用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tmp = "特殊字符\n功能键和一些特殊字符需要输入转义版本，例如{ENTER}表示换行。更多转义你可以点击关于->转义查询。\n\n打开文件\n将编队设置为文件地址，调用编队即可打开文件。例如：65=D:\\myfile.txt\n\n打开文件夹\n将编队设置为文件夹地址，调用编队即可打开文件夹。例如：65=D:\\\n\n打开网页\n将编队设置为完整的网页地址（http或https），调用编队即可打开网页。例如：65=https://www.baidu.com/\n\n运行指令\n将编队设置为开头“QuickInputRun:”，调用编队即可执行指令。例如：65=QuickInputRun:cmd";
            MessageBox.Show(tmp, "高级功能使用");
        }

        private void 设置右键发送到快捷键ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 复制到sendto


            if (!File.Exists(sendtoPath + myName))
            {
                File.Copy(myPath, sendtoPath + myName);
                MessageBox.Show("设置成功，你可以在选择文件（夹），右键，发送到，选本软件，设置快捷键。用快捷键即可打开文件");
            }
            else
            {
                MessageBox.Show("文件已经存在，将会替换");
                File.Delete(sendtoPath + myName);
                File.Copy(myPath, sendtoPath + myName);
            }
        }


        private void 重新读取设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            read();
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            readWithoutNumber();
        }

        private void 设置ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            openSetting();

        }

        void openSetting(bool needReshow = true)
        {
            Setting setting = new Setting(needReshow);
            this.Hide();
            setting.Show();
        }
    }

}
