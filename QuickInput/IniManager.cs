using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QuickInput
{
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
            if (!System.IO.File.Exists(filePath))
            {
                System.IO.File.Create(filePath).Dispose();//创建INI文件，并释放    
                writeWordsHelp(filePath);
            }
            WriteHelp(filePath);
        }

        private static void writeWordsHelp(string filePath)
        {
            if (Read("words", "65", "", filePath).Equals(""))
            {
                WritePrivateProfileString("words", "65", "空格 加 a以输入这行数据，需要关闭中文输入法。65-81对应a-z", filePath);
            }
            if (Read("words", "66", "", filePath).Equals(""))
            {
                WritePrivateProfileString("words", "66", "空格 加 b以输入这行数据，需要关闭中文输入法。{ENTER}表示换行，{+}、{^}、{%}等符号有特殊含义，可以看底部链接说明。", filePath);
            }
        }


        public static void WriteHelp(string filePath)
        {
            if (Read("words", "65", "", filePath).Equals(""))
            {
                WritePrivateProfileString("words", "65", "", filePath);
            }
            if (Read("words", "66", "", filePath).Equals(""))
            {
                WritePrivateProfileString("words", "66", "", filePath);
            }

            WritePrivateProfileString("使用说明", "设置编队", "你可以在这个文件里设置编队，请设置在[words]章节里，格式：按键码=编队内容。", filePath);
            WritePrivateProfileString("使用说明", "特殊字符", "功能键和一些特殊字符需要输入转义版本，例如{ENTER}表示换行。更多转义你可以查看下面的链接。", filePath);
           
            WritePrivateProfileString("使用说明", "打开文件", "将编队设置为文件地址，调用编队即可打开文件。例如：65=D:\\myfile.txt", filePath);
            WritePrivateProfileString("使用说明", "打开文件夹", "将编队设置为文件夹地址，调用编队即可打开文件夹。例如：65=D:\\", filePath);
            WritePrivateProfileString("使用说明", "打开网页", "将编队设置为完整的网页地址（http或https），调用编队即可打开网页。例如：65=https://www.baidu.com/", filePath);
            WritePrivateProfileString("使用说明", "运行指令", "将编队设置为开头“QuickInputRun:”，调用编队即可执行指令。例如：65=QuickInputRun:cmd", filePath);
            WritePrivateProfileString("使用说明", "KeyCode", "你可以在这个链接里查看按键码， https://www.bejson.com/othertools/keycodes/", filePath);
            WritePrivateProfileString("使用说明", "SendKeys", "你可以在这个链接查看转义字符， https://www.cnblogs.com/shaozhuyong/p/5951779.html", filePath);
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
