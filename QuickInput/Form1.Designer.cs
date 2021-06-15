namespace QuickInput
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.官网ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.托盘模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开设置文件ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.另存为设置文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.启动不显示窗体ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置开机启动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置右键发送到快捷键ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.高级设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开设置文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开设置文件目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.读取设置文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.测试模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.高级功能使用ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.网站ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.按键码查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.转移查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.placeHolderTextBox2 = new RevitDevelopment.CustomControls.PlaceHolderTextBox();
            this.placeHolderTextBox1 = new RevitDevelopment.CustomControls.PlaceHolderTextBox();
            this.按键码实时显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            resources.ApplyResources(this.notifyIcon1, "notifyIcon1");
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.官网ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            resources.ApplyResources(this.打开ToolStripMenuItem, "打开ToolStripMenuItem");
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            resources.ApplyResources(this.设置ToolStripMenuItem, "设置ToolStripMenuItem");
            this.设置ToolStripMenuItem.Click += new System.EventHandler(this.设置ToolStripMenuItem_Click);
            // 
            // 官网ToolStripMenuItem
            // 
            this.官网ToolStripMenuItem.Name = "官网ToolStripMenuItem";
            resources.ApplyResources(this.官网ToolStripMenuItem, "官网ToolStripMenuItem");
            this.官网ToolStripMenuItem.Click += new System.EventHandler(this.官网ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            resources.ApplyResources(this.退出ToolStripMenuItem, "退出ToolStripMenuItem");
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始ToolStripMenuItem,
            this.设置ToolStripMenuItem1,
            this.高级设置ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // 开始ToolStripMenuItem
            // 
            this.开始ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.托盘模式ToolStripMenuItem,
            this.打开设置文件ToolStripMenuItem1,
            this.另存为设置文件ToolStripMenuItem,
            this.退出ToolStripMenuItem1});
            this.开始ToolStripMenuItem.Name = "开始ToolStripMenuItem";
            resources.ApplyResources(this.开始ToolStripMenuItem, "开始ToolStripMenuItem");
            // 
            // 托盘模式ToolStripMenuItem
            // 
            this.托盘模式ToolStripMenuItem.Name = "托盘模式ToolStripMenuItem";
            resources.ApplyResources(this.托盘模式ToolStripMenuItem, "托盘模式ToolStripMenuItem");
            this.托盘模式ToolStripMenuItem.Click += new System.EventHandler(this.托盘模式ToolStripMenuItem_Click);
            // 
            // 打开设置文件ToolStripMenuItem1
            // 
            this.打开设置文件ToolStripMenuItem1.Name = "打开设置文件ToolStripMenuItem1";
            resources.ApplyResources(this.打开设置文件ToolStripMenuItem1, "打开设置文件ToolStripMenuItem1");
            this.打开设置文件ToolStripMenuItem1.Click += new System.EventHandler(this.open打开设置文件ToolStripMenuItem1_Click);
            // 
            // 另存为设置文件ToolStripMenuItem
            // 
            this.另存为设置文件ToolStripMenuItem.Name = "另存为设置文件ToolStripMenuItem";
            resources.ApplyResources(this.另存为设置文件ToolStripMenuItem, "另存为设置文件ToolStripMenuItem");
            this.另存为设置文件ToolStripMenuItem.Click += new System.EventHandler(this.另存为设置文件ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem1
            // 
            this.退出ToolStripMenuItem1.Name = "退出ToolStripMenuItem1";
            resources.ApplyResources(this.退出ToolStripMenuItem1, "退出ToolStripMenuItem1");
            this.退出ToolStripMenuItem1.Click += new System.EventHandler(this.退出ToolStripMenuItem1_Click);
            // 
            // 设置ToolStripMenuItem1
            // 
            this.设置ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem2,
            this.启动不显示窗体ToolStripMenuItem,
            this.设置开机启动ToolStripMenuItem,
            this.设置右键发送到快捷键ToolStripMenuItem,
            this.按键码实时显示ToolStripMenuItem});
            this.设置ToolStripMenuItem1.Name = "设置ToolStripMenuItem1";
            resources.ApplyResources(this.设置ToolStripMenuItem1, "设置ToolStripMenuItem1");
            // 
            // 设置ToolStripMenuItem2
            // 
            this.设置ToolStripMenuItem2.Name = "设置ToolStripMenuItem2";
            resources.ApplyResources(this.设置ToolStripMenuItem2, "设置ToolStripMenuItem2");
            this.设置ToolStripMenuItem2.Click += new System.EventHandler(this.设置ToolStripMenuItem2_Click);
            // 
            // 启动不显示窗体ToolStripMenuItem
            // 
            this.启动不显示窗体ToolStripMenuItem.Checked = true;
            this.启动不显示窗体ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.启动不显示窗体ToolStripMenuItem.Name = "启动不显示窗体ToolStripMenuItem";
            resources.ApplyResources(this.启动不显示窗体ToolStripMenuItem, "启动不显示窗体ToolStripMenuItem");
            this.启动不显示窗体ToolStripMenuItem.Click += new System.EventHandler(this.启动不显示窗体ToolStripMenuItem_Click);
            // 
            // 设置开机启动ToolStripMenuItem
            // 
            this.设置开机启动ToolStripMenuItem.Name = "设置开机启动ToolStripMenuItem";
            resources.ApplyResources(this.设置开机启动ToolStripMenuItem, "设置开机启动ToolStripMenuItem");
            this.设置开机启动ToolStripMenuItem.Click += new System.EventHandler(this.设置开机启动ToolStripMenuItem_Click);
            // 
            // 设置右键发送到快捷键ToolStripMenuItem
            // 
            this.设置右键发送到快捷键ToolStripMenuItem.Name = "设置右键发送到快捷键ToolStripMenuItem";
            resources.ApplyResources(this.设置右键发送到快捷键ToolStripMenuItem, "设置右键发送到快捷键ToolStripMenuItem");
            this.设置右键发送到快捷键ToolStripMenuItem.Click += new System.EventHandler(this.设置右键发送到快捷键ToolStripMenuItem_Click);
            // 
            // 高级设置ToolStripMenuItem
            // 
            this.高级设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开设置文件ToolStripMenuItem,
            this.打开设置文件目录ToolStripMenuItem,
            this.读取设置文件ToolStripMenuItem,
            this.测试模式ToolStripMenuItem});
            this.高级设置ToolStripMenuItem.Name = "高级设置ToolStripMenuItem";
            resources.ApplyResources(this.高级设置ToolStripMenuItem, "高级设置ToolStripMenuItem");
            // 
            // 打开设置文件ToolStripMenuItem
            // 
            this.打开设置文件ToolStripMenuItem.Name = "打开设置文件ToolStripMenuItem";
            resources.ApplyResources(this.打开设置文件ToolStripMenuItem, "打开设置文件ToolStripMenuItem");
            this.打开设置文件ToolStripMenuItem.Click += new System.EventHandler(this.打开设置文件ToolStripMenuItem_Click);
            // 
            // 打开设置文件目录ToolStripMenuItem
            // 
            this.打开设置文件目录ToolStripMenuItem.Name = "打开设置文件目录ToolStripMenuItem";
            resources.ApplyResources(this.打开设置文件目录ToolStripMenuItem, "打开设置文件目录ToolStripMenuItem");
            this.打开设置文件目录ToolStripMenuItem.Click += new System.EventHandler(this.打开设置文件目录ToolStripMenuItem_Click);
            // 
            // 读取设置文件ToolStripMenuItem
            // 
            this.读取设置文件ToolStripMenuItem.Name = "读取设置文件ToolStripMenuItem";
            resources.ApplyResources(this.读取设置文件ToolStripMenuItem, "读取设置文件ToolStripMenuItem");
            this.读取设置文件ToolStripMenuItem.Click += new System.EventHandler(this.重新读取设置ToolStripMenuItem_Click);
            // 
            // 测试模式ToolStripMenuItem
            // 
            this.测试模式ToolStripMenuItem.Name = "测试模式ToolStripMenuItem";
            resources.ApplyResources(this.测试模式ToolStripMenuItem, "测试模式ToolStripMenuItem");
            this.测试模式ToolStripMenuItem.Click += new System.EventHandler(this.测试模式ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帮助ToolStripMenuItem,
            this.高级功能使用ToolStripMenuItem,
            this.网站ToolStripMenuItem,
            this.按键码查询ToolStripMenuItem,
            this.转移查询ToolStripMenuItem,
            this.englishToolStripMenuItem});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            resources.ApplyResources(this.关于ToolStripMenuItem, "关于ToolStripMenuItem");
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            resources.ApplyResources(this.帮助ToolStripMenuItem, "帮助ToolStripMenuItem");
            this.帮助ToolStripMenuItem.Click += new System.EventHandler(this.帮助ToolStripMenuItem_Click);
            // 
            // 高级功能使用ToolStripMenuItem
            // 
            this.高级功能使用ToolStripMenuItem.Name = "高级功能使用ToolStripMenuItem";
            resources.ApplyResources(this.高级功能使用ToolStripMenuItem, "高级功能使用ToolStripMenuItem");
            this.高级功能使用ToolStripMenuItem.Click += new System.EventHandler(this.高级功能使用ToolStripMenuItem_Click);
            // 
            // 网站ToolStripMenuItem
            // 
            this.网站ToolStripMenuItem.Name = "网站ToolStripMenuItem";
            resources.ApplyResources(this.网站ToolStripMenuItem, "网站ToolStripMenuItem");
            this.网站ToolStripMenuItem.Click += new System.EventHandler(this.网站ToolStripMenuItem_Click);
            // 
            // 按键码查询ToolStripMenuItem
            // 
            this.按键码查询ToolStripMenuItem.Name = "按键码查询ToolStripMenuItem";
            resources.ApplyResources(this.按键码查询ToolStripMenuItem, "按键码查询ToolStripMenuItem");
            this.按键码查询ToolStripMenuItem.Click += new System.EventHandler(this.按键码查询ToolStripMenuItem_Click);
            // 
            // 转移查询ToolStripMenuItem
            // 
            this.转移查询ToolStripMenuItem.Name = "转移查询ToolStripMenuItem";
            resources.ApplyResources(this.转移查询ToolStripMenuItem, "转移查询ToolStripMenuItem");
            this.转移查询ToolStripMenuItem.Click += new System.EventHandler(this.转移查询ToolStripMenuItem_Click);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // textBox3
            // 
            this.textBox3.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.textBox3, "textBox3");
            this.textBox3.Name = "textBox3";
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // textBox4
            // 
            resources.ApplyResources(this.textBox4, "textBox4");
            this.textBox4.Name = "textBox4";
            // 
            // placeHolderTextBox2
            // 
            resources.ApplyResources(this.placeHolderTextBox2, "placeHolderTextBox2");
            this.placeHolderTextBox2.ForeColor = System.Drawing.Color.Gray;
            this.placeHolderTextBox2.Name = "placeHolderTextBox2";
            this.placeHolderTextBox2.PlaceHolderText = "修改快捷键，替换空格键，输入按键码";
            this.placeHolderTextBox2.TextChanged += new System.EventHandler(this.placeHolderTextBox2_TextChanged);
            // 
            // placeHolderTextBox1
            // 
            resources.ApplyResources(this.placeHolderTextBox1, "placeHolderTextBox1");
            this.placeHolderTextBox1.ForeColor = System.Drawing.Color.Gray;
            this.placeHolderTextBox1.Name = "placeHolderTextBox1";
            this.placeHolderTextBox1.PlaceHolderText = "检测时间间隔（ms）";
            this.placeHolderTextBox1.TextChanged += new System.EventHandler(this.placeHolderTextBox1_TextChanged);
            // 
            // 按键码实时显示ToolStripMenuItem
            // 
            this.按键码实时显示ToolStripMenuItem.Checked = true;
            this.按键码实时显示ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.按键码实时显示ToolStripMenuItem.Name = "按键码实时显示ToolStripMenuItem";
            resources.ApplyResources(this.按键码实时显示ToolStripMenuItem, "按键码实时显示ToolStripMenuItem");
            this.按键码实时显示ToolStripMenuItem.Click += new System.EventHandler(this.按键码实时显示ToolStripMenuItem_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.placeHolderTextBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.placeHolderTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0D;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 官网ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private RevitDevelopment.CustomControls.PlaceHolderTextBox placeHolderTextBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 开始ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 网站ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 托盘模式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 启动不显示窗体ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置开机启动ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 按键码查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 转移查询ToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem 打开设置文件ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 另存为设置文件ToolStripMenuItem;
        private RevitDevelopment.CustomControls.PlaceHolderTextBox placeHolderTextBox2;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 高级功能使用ToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ToolStripMenuItem 设置右键发送到快捷键ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 高级设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开设置文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开设置文件目录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 测试模式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 读取设置文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 按键码实时显示ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}

