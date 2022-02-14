using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace testlog
{
    public partial class Click学生个人课表查询 : Form
    {
        String Sno;
        public Click学生个人课表查询()
        {
            InitializeComponent();
            showTable();
        }

        public Click学生个人课表查询(String SID)//向构造函数传入Sno
        {
            Sno = SID;
            InitializeComponent();
            showTable();
        }

        private void showTable()
        {
            dataGridView4.Rows.Clear();
            string sql = " select* from 学生当前选课情况 where 学号 = '" + Sno + "'";
            Door read_my_course = new Door();
            IDataReader dr = read_my_course.Reader(sql);
            while (dr.Read())
            {
                string a, b, c, d, e, f, g, h, temp1, temp2;
                a = dr["课程"].ToString();
                b = dr["课程号"].ToString();
                c = dr["学分"].ToString();
                d = dr["授课老师"].ToString();
                e = dr["上课时间"].ToString();
                temp1 = dr["空间位置"].ToString();
                temp2 = dr["教室编号"].ToString();
                f = temp1 + " " + temp2;
                g = dr["课程类型"].ToString();
                h = dr["课程教学ID"].ToString();
                string[] str = { a, b, g, c, d, e, f, h};
                //dataGridView1.Rows.Add(str);
                dataGridView4.Rows.Add(str);

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Click学生个人课表查询_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string Cno1 = dataGridView4.SelectedCells[1].Value.ToString();
            }
            catch
            {
                MessageBox.Show("请点击第一列空白处，选择一整行，再点击删除退选按钮");
                return;
            }
            DialogResult r = MessageBox.Show("确定要退选吗？", "提示", MessageBoxButtons.OKCancel);
            if (r == DialogResult.OK)
            {
                String CTID = dataGridView4.SelectedCells[7].Value.ToString();
                string sql = "delete from 课程学生SC where 学号 = '" + Sno + "' and 课程教学ID = '" + CTID + "'";
                Door Choose_door = new Door();
                try
                {
                    Choose_door.Excute(sql);
                    MessageBox.Show("退选成功！");
                    dataGridView4.Rows.Clear();
                    showTable();
                }
                catch (SqlException sqlExc)
                {

                    foreach (SqlError error in sqlExc.Errors)
                    {
                        string msg = string.Format("{0}: {1}", error.Number, error.Message);//string msg = string.Format("{0}: {1}", error.Number, error.Message);（错误消息）
                        MessageBox.Show("退选失败！");
                        break;
                    }
                }
            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
