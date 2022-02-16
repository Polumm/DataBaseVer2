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
    public partial class 教师功能区界面 : Form
    {
        string TID1;
        public 教师功能区界面()
        {
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            timer1.Start();
        }
        public 教师功能区界面(string TID)
        {
            TID1 = TID;
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            timer1.Start();
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void 教师功能区界面_Load(object sender, EventArgs e)
        {

        }

        private void 教学任务查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Click教学任务查询 Choose_course = new Click教学任务查询(TID1);
            Choose_course.ShowDialog();
        }

        private void 教学计划申请ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Click修改密码 Update_password = new Click修改密码(TID1, "教师");
            Update_password.ShowDialog();
        }

        private void 自主选课ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 学生成绩录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Click学生成绩录入 ScoreLoad = new Click学生成绩录入(TID1);
            ScoreLoad.ShowDialog();
        }

        private void 地图交互ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            地图交互 mapLoad = new 地图交互(TID1,2);
            mapLoad.ShowDialog();
        }
    }
}
