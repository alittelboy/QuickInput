using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace QuickInput
{

    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Setting());
            //return;

            //有参数，变为设置
            //args = new string[1];
            //args[0] = "测试内容";
            if (args.Length != 0)
            {
                //MessageBox.Show(args[0]);
                string code = Input.InputBox.ShowInputBox("请输入想设置的快捷键","请输入 单个 小写 字母，或任意 按键码（不是数字键）,回车键确认。设置以后，使用空格+快捷键打开文件或文件夹。");
                if (code.Length == 1 && Encoding.ASCII.GetBytes(code)[0] >= Encoding.ASCII.GetBytes("a")[0] && Encoding.ASCII.GetBytes(code)[0] <= Encoding.ASCII.GetBytes("z")[0])
                {
                    int tmpcode = code[0];
                    tmpcode = tmpcode - 97 + 65;
                    //MessageBox.Show(tmpcode+"");
                    code = tmpcode + "";
                }
                string iniPath = Form1.quickInputSet + "\\QuickInputSet.ini";// 
                IniManager.Write("words", code, args[0], iniPath);
                MessageBox.Show("设置成功，即将重启本软件");

                Restart.restartQI();//重启

                //Application.Run(new Form1(args));
            }
                
            //无参数，正常运行
            else
            {
                //为真 则没有重复运行
                bool ifNotAlreadRun;

                Mutex mutex = new Mutex(true, Application.ProductName, out ifNotAlreadRun);
                if (ifNotAlreadRun)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                    mutex.ReleaseMutex();
                }
                else
                {
                    MessageBox.Show(null, "有一个和本程序相同的应用程序已经在运行，请不要同时运行多个本程序。\n\n这个程序即将退出。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();//退出程序
                }
            }



        }
    }
}
