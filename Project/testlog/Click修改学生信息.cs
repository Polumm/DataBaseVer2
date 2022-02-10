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
    public partial class Click修改学生信息 : Form
    {
        public Click修改学生信息()
        {
            InitializeComponent();
            showTable();
        }

        private void showTable()
        {
            dataGridView3.Rows.Clear();
            string sql = " select* from 学生";
            Door dao = new Door();
            IDataReader dr = dao.Reader(sql);
            while (dr.Read())
            {
                string a, b, c, d, e, f;
                a = dr["学号"].ToString();
                b = dr["姓名"].ToString();
                c = dr["性别"].ToString();
                d = dr["出生日期"].ToString();
                e = dr["班级编号"].ToString();
                string[] str = { a, b, c, d, e };
                //dataGridView1.Rows.Add(str);
                dataGridView3.Rows.Add(str);
            }

        }
        private void Click修改保存_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            showTable();
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            string[] str = { dataGridView3.SelectedCells[0].Value.ToString(), dataGridView3.SelectedCells[1].Value.ToString(), dataGridView3.SelectedCells[2].Value.ToString(), dataGridView3.SelectedCells[3].Value.ToString(), dataGridView3.SelectedCells[4].Value.ToString() };
            Click写入修改信息 Insert_student = new Click写入修改信息(str);
            //把这个数组整体的传到修改窗体，需要重写构造方法
            Insert_student.ShowDialog();
            dataGridView3.Rows.Clear();
            showTable();
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            showTable();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
