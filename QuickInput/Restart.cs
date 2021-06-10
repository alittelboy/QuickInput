using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickInput
{
    static class Restart
    {
        static private string bat = Form1.sendtoPath + "restartQI.bat";
        private static void deleteBat()
        {
            if (File.Exists(bat))
            {
                File.Delete(bat);
            }
        }
        public static void setBat()
        {
            deleteBat();
            
            using (StreamWriter sw = new StreamWriter(bat))
            {
                sw.WriteLine("taskkill -f -im quickinput.exe");
                sw.WriteLine("start " + Form1.sendtoPath + "QuickInput.exe");
                sw.WriteLine("del %0");

            }
        }

        public static void restartQI()
        {
            //MessageBox.Show(bat);
            setBat();
            Process compiler = new Process();
            compiler.StartInfo.FileName = bat;
            compiler.StartInfo.UseShellExecute = false;
            compiler.StartInfo.RedirectStandardOutput = true;
            compiler.StartInfo.CreateNoWindow = true;
            compiler.Start();
        }
    }
}
