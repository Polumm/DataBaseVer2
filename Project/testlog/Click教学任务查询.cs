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
    public partial class Click教学任务查询 : Form
    {
        String TID1;
        public Click教学任务查询()
        {
            InitializeComponent();
        }
        public Click教学任务查询(string TID)
        {
            TID1 = TID;            
            InitializeComponent();
            showTable();
        }

        private void showTable()
        {
            dataGridView1.Rows.Clear();
            string sql = " select* from 学生可选课表 where 教师编号 = '"+ TID1 +"'";
            Door Choose_course = new Door();
            IDataReader dr = Choose_course.Reader(sql);
            while (dr.Read())
            {
                string a, b, c, d, e, f, g, temp1, temp2, temp3, temp4;
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

                string[] str = { a, b, c, d, e, f, g };
                dataGridView1.Rows.Add(str);
            }

        }

        private void Click教学任务查询_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string Cno1 = dataGridView1.SelectedCells[1].Value.ToString();
            }
            catch
            {
                MessageBox.Show("选择一整行，再点击选课按钮完成选课");
                return;
            }
            String Cno = dataGridView1.SelectedCells[1].Value.ToString();
            Click学生成绩录入 Insert_grades = new Click学生成绩录入(Cno);
            Insert_grades.ShowDialog();
        }
    }
}
