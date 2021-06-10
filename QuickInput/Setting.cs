using System;
using System.Collections.Generic;

using System.Drawing;

using System.Windows.Forms;

namespace QuickInput
{
    public partial class Setting : Form
    {
        bool shouldShowForm;
        private static int valuesNum = IniManager.valuesNum;
        private static Dictionary<int,string> valuesDic = IniManager.valuesDic;

        public Setting(bool status = true)
        {
            shouldShowForm = status;
            InitializeComponent();
        }

        /// <summary>
        ///     Method used to write the key received to the log file
        /// </summary>
        /// <param name="key">The key typed on the keyboard</param>
        /// This method should be activated for each and every keystrokes the user type.
        private static string toLetter(Keys key)
        {

            // Create aliases for special characters to render properly in the logs
            var specialKeys = new Dictionary<string, string>()
            {
                //{"Back", " *back* "},
                //{"Delete", " *delete* "},
                //{"Return", "\n"},
                //{"Space", " "},
                //{"Add", "+"},
                //{"Subtract", "-"},
                //{"Divide", "/"},
                //{"Multiply", "*"},
                //{"Up", " *up* "},
                //{"Down", " *down* "},
                //{"Left", " *left* "},
                //{"Capital", " *caps* "},
                //{"Tab", " *tabs* "},
                //{"LShiftKey", " ^ "},
                //{"RShiftKey", " ^ "},
                //{"Oemcomma", ","},
                //{"OemPeriod", "."}
            };

            string explaination;

            // Write the key (or its alias) to the file
            if (specialKeys.ContainsKey(key.ToString()))
            {
                explaination = specialKeys[key.ToString()];
            }
            else
            {
                explaination = key.ToString().ToLower();
            }
            return explaination;

        }


        private void deleteKey(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int row = tableLayoutPanel1.GetRow(button);
            int col = tableLayoutPanel1.GetColumn(button);
            TextBox keycode = (TextBox)tableLayoutPanel1.GetControlFromPosition(0, row);
            TextBox content = (TextBox)tableLayoutPanel1.GetControlFromPosition(2, row);
            //MessageBox.Show(keycode.Text);


            try
            {
                int key = int.Parse(keycode.Text);
                if (key < 0 || key >= valuesNum)
                {
                    MessageBox.Show("设置失败，无效的按键码");
                    return;
                }
                if (IniManager.valuesDic.ContainsKey(key))
                {
                    IniManager.valuesDic.Remove(key);
                    IniManager.DeleteKey("words",(key).ToString());
                    MessageBox.Show("删除成功");
                }
                else
                {
                    MessageBox.Show("删除失败，按键码编队不存在");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("设置失败，无效的按键码");
                return;
            }

            
            keycode.Text = "";
            content.Text = "";


        }
        private void addKey(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int row = tableLayoutPanel1.GetRow(button);
            int col = tableLayoutPanel1.GetColumn(button);
            TextBox keycode = (TextBox)tableLayoutPanel1.GetControlFromPosition(0, row);

            TextBox tb_content = (TextBox)tableLayoutPanel1.GetControlFromPosition(2, row);
            //MessageBox.Show(keycode.Text);
            try
            {
                int key = int.Parse(keycode.Text);
                if (key < 0 || key >= valuesNum)
                {
                    MessageBox.Show("设置失败，无效的按键码");
                    return;
                }
                IniManager.valuesDic[key] = tb_content.Text;
                IniManager.Write("words", keycode.Text, tb_content.Text);
                MessageBox.Show("设置成功");
            }
            catch (Exception)
            {
                MessageBox.Show("设置失败，无效的按键码");
                return;
            }
            
            
            

        }

        private void AddTitle()
        {
            TextBox key = new TextBox();
            TextBox key_explain = new TextBox();

            TextBox tb_content = new TextBox();
            TextBox tb_operation = new TextBox();

            key.Text = "按键码";
            key.Size = new Size(50, 25);
            key.TabIndex = 100;
            key.BackColor = System.Drawing.SystemColors.Control;
            key.BorderStyle = System.Windows.Forms.BorderStyle.None;
            key.ReadOnly = true;

            key_explain.Text = "说明";
            key_explain.TabIndex = 100;
            key_explain.BackColor = System.Drawing.SystemColors.Control;
            key_explain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            key_explain.ReadOnly = true;

            
            tb_content.Text = "编队";
            tb_content.TabIndex = 100;
            tb_content.Size = new Size(200, 25);
            tb_content.TextAlign = HorizontalAlignment.Center;
            tb_content.BackColor = System.Drawing.SystemColors.Control;
            tb_content.BorderStyle = System.Windows.Forms.BorderStyle.None;
            tb_content.ReadOnly = true;

            tb_operation.Text = "操作";
            tb_operation.TabIndex = 100;
            tb_operation.Size = new Size(150, 25);
            tb_operation.TextAlign = HorizontalAlignment.Center;
            tb_operation.BackColor = System.Drawing.SystemColors.Control;
            tb_operation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            tb_operation.ReadOnly = true;

            tableLayoutPanel1.Controls.Add(key, 0, 0);
            tableLayoutPanel1.Controls.Add(key_explain, 1, 0);
            tableLayoutPanel1.Controls.Add(tb_content, 2, 0);
            tableLayoutPanel1.Controls.Add(tb_operation, 3, 0);
            tableLayoutPanel1.SetColumnSpan(tb_operation, 2);

        }
        // 0-255按键信息
        // 256-valuesNum 自定义按键
        private void AddRow(int rownum, int keycode, string content)
        {

            rownum += 1;
            TextBox key = new TextBox();
            TextBox key_explain = new TextBox();
            
            TextBox tb_content = new TextBox();
            Button btn_del = new Button();
            Button btn_change = new Button();

            key.Text = keycode.ToString();
            key.TextChanged += new EventHandler(tryExplain);
            key.Size = new Size(50, 25);//默认100,25

            key_explain.Text = keycode < 256 ? toLetter((Keys)keycode): "特殊组合键";
            key_explain.BackColor = System.Drawing.SystemColors.Control;
            key_explain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            key_explain.ReadOnly = true;
            key_explain.TabIndex = 100;
            

            tb_content.Text = IniManager.valuesDic[keycode];
            tb_content.Size = new Size(200, 25);

            btn_del.Text = "删除";
            btn_del.Size = new Size(75, 25);
            btn_del.Click += new EventHandler(deleteKey);
            btn_change.Text = "修改";
            btn_change.Size = new Size(75, 25);
            btn_change.Click += new EventHandler(addKey);

            tableLayoutPanel1.Controls.Add(key, 0, rownum);
            tableLayoutPanel1.Controls.Add(key_explain, 1, rownum);
            tableLayoutPanel1.Controls.Add(tb_content, 2, rownum);
            tableLayoutPanel1.Controls.Add(btn_del, 3, rownum);
            tableLayoutPanel1.Controls.Add(btn_change, 4, rownum);

        }

        private void AddAdd(int num = -1)
        {
            if (num == -1)
            {
                num = valuesNum;
            }
            TextBox key = new TextBox();
            TextBox key_explain = new TextBox();

            TextBox tb_content = new TextBox();
            Button btn_del = new Button();
            Button btn_change = new Button();

            key.Size = new Size(50, 25);//默认100,25
            key.TextChanged += new EventHandler(tryExplain);

            key_explain.Text = "新增编队";
            key_explain.BackColor = System.Drawing.SystemColors.Control;
            key_explain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            key_explain.ReadOnly = true;
            key_explain.TabIndex = 100;

            tb_content.Size = new Size(200, 25);

            btn_del.Text = "删除";
            btn_del.Click += new EventHandler(deleteKey);
            btn_change.Text = "修改";
            btn_change.Click += new EventHandler(addKey);

            tableLayoutPanel1.Controls.Add(key, 0, num);
            tableLayoutPanel1.Controls.Add(key_explain, 1, num);
            tableLayoutPanel1.Controls.Add(tb_content, 2, num);
            tableLayoutPanel1.Controls.Add(btn_del, 3, num);
            tableLayoutPanel1.Controls.Add(btn_change, 4, num);

        }


        void tryExplain(object sender, EventArgs e)
        {
            TextBox key = (TextBox)sender;
            int row = tableLayoutPanel1.GetRow(key);
            int col = tableLayoutPanel1.GetColumn(key);
            TextBox key_explain = ((TextBox)tableLayoutPanel1.GetControlFromPosition(1, row));
            try
            {
                int keycode = int.Parse(key.Text);
                key_explain.Text = keycode < 256 ? toLetter((Keys)keycode) : "特殊组合键";
            }
            catch (Exception)
            {

                key_explain.Text = "无效按键码";
            }
            
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = Size - new Size(30, 140);
            tableLayoutPanel1.Location = Point.Empty + new Size(10, 100);

            reLoad();

        }

        void read()
        {
            AddTitle();
            //IniManager.readIni();
            foreach (var iv in valuesDic)
            {
                int i = iv.Key;
                if (!iv.Value.Equals(""))
                {
                    AddRow(i, i, iv.Value);
                }
            }

            AddAdd(valuesNum);
            AddAdd(513);

        }

        void reLoad()
        {
            for (int i = tableLayoutPanel1.Controls.Count - 1; i >= 0; i--)
            {
                Control c = tableLayoutPanel1.Controls[i];
                c.Dispose();
            }
            IniManager.readIni();
            read();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            reLoad();


        }

        private void Setting_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (shouldShowForm)
            {
                IniManager.form1.Show();
            }
        }
    }
}
