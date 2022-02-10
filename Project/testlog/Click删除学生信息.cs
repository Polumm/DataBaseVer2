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
    public partial class Click删除学生信息 : Form
    {
        public Click删除学生信息()
        {
            InitializeComponent();
            showTable();
        }

        private void showTable()
        {
            dataGridView2.Rows.Clear();
            string sql = " select* from 学生";
            Door dao = new Door();
            IDataReader dr = dao.Reader(sql);
            while (dr.Read())
            {
                string a, b, c, d, e;
                a = dr["学号"].ToString();
                b = dr["姓名"].ToString();
                c = dr["性别"].ToString();
                d = dr["出生日期"].ToString();
                e = dr["班级编号"].ToString();

                string[] str = { a, b, c, d, e };
                //dataGridView1.Rows.Add(str);
                dataGridView2.Rows.Add(str);
            }
        }

        private void Click删除学生信息_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.OKCancel);
            if (r == DialogResult.OK)
            {
                string id;
                id = dataGridView2.SelectedCells[0].Value.ToString();//获取选中得到第一行的第一个单元格的值转换成字符串
                String sql = "delete from 课程学生SC where 学号='" + id + "' delete from 绩点模型 where 学号='" + id + "' delete from 学生 where 学号 = '" + id + "' ";
                MessageBox.Show(sql);
                Door delete_door = new Door();
                int i = delete_door.Excute(sql);
                if (i > 0)
                {
                    MessageBox.Show("删除成功！");
                    dataGridView2.Rows.Clear();
                    showTable();
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            showTable();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

