using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testlog
{
    public partial class 学生功能区界面 : Form
    {
        String SID1;
        public 学生功能区界面()
        {
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            timer1.Start();
        }
        
        public 学生功能区界面(String SID)
        {
            SID1 = SID;
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            timer1.Start();
        }



        private void 个人课表查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Click学生个人课表查询 Choose_course = new Click学生个人课表查询();
            Choose_course.ShowDialog();
        }

        private void 自主选课ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Click自主选课 Choose_course = new Click自主选课(SID1);
            Choose_course.ShowDialog();
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void 个人课表查询ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Click学生个人课表查询 Choose_course = new Click学生个人课表查询(SID1);
            Choose_course.ShowDialog();
        }

        private void 选课ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 选课情况确认ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 成绩总表打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Click学生成绩总表打印 Choose_course = new Click学生成绩总表打印(SID1);
            Choose_course.ShowDialog();
        }

        private void 平均学分绩点查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Click平均学分绩点查询 Choose_course = new Click平均学分绩点查询(SID1);
            Choose_course.ShowDialog();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Click修改密码 Update_password = new Click修改密码(SID1, "学生");
            Update_password.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            地图交互 mapLoad = new 地图交互(SID1, 1);
            mapLoad.ShowDialog();
        }
    }
}

