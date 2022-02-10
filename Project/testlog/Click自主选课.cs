using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;/*为SqlException添加命名空间，实现异常捕捉*/

namespace testlog
{
    public partial class Click自主选课 : Form
    {
        String Sno;
        public Click自主选课()//向构造函数传入Sno
        {

        }
        public Click自主选课(String SID)//向构造函数传入Sno
        {
            Sno = SID;
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            timer1.Start();
            showTable();
        }

        private void showTable()
        {
            dataGridView1.Rows.Clear();
            string sql = " select* from 学生可选课表";
            Door Choose_course = new Door();
            IDataReader dr = Choose_course.Reader(sql);
            while (dr.Read())
            {
                string a, b, c, d, e, f, g, h, temp1, temp2, temp3, temp4;
                a = dr["课程"].ToString();
                b = dr["课程号"].ToString();
                c = dr["学分"].ToString();
                d = dr["授课老师"].ToString();
                e = dr["上课时间"].ToString();
                temp1 = dr["空间位置"].ToString();
                temp2 = dr["教室编号"].ToString();
                temp3 = dr["当前人数"].ToString();
                temp4 = dr["计划上限"].ToString();
                f = temp1 + " " + temp2;
                g = temp3 + "/" + temp4;
                h = dr["课程类型"].ToString();
                string[] str = { a, b, h, c, d, e, f, g };
                //dataGridView1.Rows.Add(str);
                dataGridView1.Rows.Add(str);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void Form_SC_Choose_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 我的课程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Click学生个人课表查询 Choose_course = new Click学生个人课表查询(Sno);
            Choose_course.ShowDialog();
        }
        /*
            Click学生个人课表查询 Choose_course = new Click学生个人课表查询(Sno);
            Choose_course.ShowDialog();
         */

        /*
        private void 选课ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Cno = dataGridView1.SelectedCells[1].Value.ToString();
            string sql = "insert into 课程学生SC values('" + Sno + "','" + Cno + "',NULL)";
            Door Choose_door = new Door();
            try
            {
                Choose_door.Excute(sql);
            }
            catch (SqlException sqlExc)
            {
                foreach (SqlError error in sqlExc.Errors)
                {
                    string msg = string.Format("{0}: {1}", error.Number, error.Message);
                }
            }


        }
        */

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string Cno1 = dataGridView1.SelectedCells[1].Value.ToString();
            }
            catch
            {
                MessageBox.Show("请点击第一列空白处，选择一整行，再点击选课按钮完成选课");
                return;
            }
            String Cno = dataGridView1.SelectedCells[1].Value.ToString();
            string sql = "insert into 课程学生SC values('" + Sno + "','" + Cno + "',NULL)";
            Door Choose_door = new Door();
            try
            {
                Choose_door.Excute(sql);
                MessageBox.Show("选课成功！");
                Click学生个人课表查询 Choose_course = new Click学生个人课表查询(Sno);
                Choose_course.Show();
            }
            catch (SqlException sqlExc)
            {

                foreach (SqlError error in sqlExc.Errors)
                {
                    string msg = string.Format("{0}: {1}", error.Number, error.Message);//string msg = string.Format("{0}: {1}", error.Number, error.Message);（错误消息）
                    MessageBox.Show("请勿重复选课！");
                    break;
                }

                //MessageBox.Show("请勿重复选课！");
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

/*
   string Cno = dataGridView1.SelectedCells[1].Value.ToString();
string sql = "insert into 课程学生SC values('"+ Sno +"','"+ Cno +"',NULL)";
Door Choose_door = new Door();
try
{
    Choose_door.Excute(sql);
}
catch (SqlException sqlExc)
{
    foreach (SqlError error in sqlExc.Errors)
    {
        string msg = string.Format("{0}: {1}", error.Number, error.Message);
    }
 */

/*
int i = Choose_door.Excute(sql);
if(i > 0)
{
    MessageBox.Show("运行成功！");
}
*/
//string[] str = { dataGridView1.SelectedCells[0].Value.ToString(), dataGridView1.SelectedCells[1].Value.ToString(), dataGridView1.SelectedCells[2].Value.ToString(), dataGridView1.SelectedCells[3].Value.ToString() };
//Click写入修改信息 Insert_student = new Click写入修改信息(str);
//把这个数组整体的传到修改窗体，需要重写构造方法
//Insert_student.ShowDialog();