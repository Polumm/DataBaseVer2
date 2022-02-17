
namespace testlog
{
    partial class 教师功能区界面
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.地图交互ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.学情统计分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选课ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用户个人信息维护ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改密码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选课ToolStripMenuItem,
            this.地图交互ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 36);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 地图交互ToolStripMenuItem
            // 
            this.地图交互ToolStripMenuItem.Name = "地图交互ToolStripMenuItem";
            this.地图交互ToolStripMenuItem.Size = new System.Drawing.Size(152, 32);
            this.地图交互ToolStripMenuItem.Text = "多功能教务平台";
            this.地图交互ToolStripMenuItem.Click += new System.EventHandler(this.地图交互ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 419);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 31);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(82, 24);
            this.toolStripStatusLabel1.Text = "欢迎登陆";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(619, 24);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(64, 24);
            this.toolStripStatusLabel3.Text = " Timer";
            this.toolStripStatusLabel3.Click += new System.EventHandler(this.toolStripStatusLabel3_Click);
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(20, 24);
            this.toolStripStatusLabel4.Text = "  ";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // 学情统计分析ToolStripMenuItem
            // 
            this.学情统计分析ToolStripMenuItem.Name = "学情统计分析ToolStripMenuItem";
            this.学情统计分析ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.学情统计分析ToolStripMenuItem.Text = "退出系统";
            this.学情统计分析ToolStripMenuItem.Click += new System.EventHandler(this.学情统计分析ToolStripMenuItem_Click);
            // 
            // 选课ToolStripMenuItem
            // 
            this.选课ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.学情统计分析ToolStripMenuItem,
            this.用户个人信息维护ToolStripMenuItem,
            this.修改密码ToolStripMenuItem});
            this.选课ToolStripMenuItem.Name = "选课ToolStripMenuItem";
            this.选课ToolStripMenuItem.Size = new System.Drawing.Size(62, 32);
            this.选课ToolStripMenuItem.Text = "系统";
            // 
            // 用户个人信息维护ToolStripMenuItem
            // 
            this.用户个人信息维护ToolStripMenuItem.Name = "用户个人信息维护ToolStripMenuItem";
            this.用户个人信息维护ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.用户个人信息维护ToolStripMenuItem.Text = "用户个人信息维护";
            this.用户个人信息维护ToolStripMenuItem.Click += new System.EventHandler(this.用户个人信息维护ToolStripMenuItem_Click);
            // 
            // 修改密码ToolStripMenuItem
            // 
            this.修改密码ToolStripMenuItem.Name = "修改密码ToolStripMenuItem";
            this.修改密码ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.修改密码ToolStripMenuItem.Text = "修改密码";
            this.修改密码ToolStripMenuItem.Click += new System.EventHandler(this.修改密码ToolStripMenuItem_Click_1);
            // 
            // 教师功能区界面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "教师功能区界面";
            this.Text = "教师功能区界面";
            this.Load += new System.EventHandler(this.教师功能区界面_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem 地图交互ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选课ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 学情统计分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用户个人信息维护ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改密码ToolStripMenuItem;
    }
}