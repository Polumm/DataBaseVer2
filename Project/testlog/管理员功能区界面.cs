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
    public partial class 管理员功能区界面 : Form
    {
        public 管理员功能区界面()
        {
            //启动时即获取时间
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            timer1.Start();
        }


        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {//获取当前系统时间,格式输出
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 删除学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Click删除学生信息 delete = new Click删除学生信息();
            delete.ShowDialog();
        }
        //Application.Exit();//分窗口关闭，程序强制退出

        private void Form2_Win_Load(object sender, EventArgs e)
        {

        }


        private void Form2_Win_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//分窗口关闭，程序强制退出
        }

        //使用Click事件调用
        private void 生成年级学生排名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Click年级学生排名 rank = new Click年级学生排名();
            rank.ShowDialog();
        }

        private void 统计班级学生信息ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void 统计年级学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 统计班级学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 统计学生个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 添加学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Click添加学生信息 Insert_student = new Click添加学生信息();
            Insert_student.ShowDialog();
        }

        private void 信息管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 修改学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Click修改学生信息 Upudate_student = new Click修改学生信息();
            Upudate_student.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
    
}
