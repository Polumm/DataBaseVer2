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
    public partial class Click年级学生排名 : Form
    {
        public Click年级学生排名()
        {
            InitializeComponent();
            Table();
        }
        private void Table()
        {
            string sql = " select* from 年级排名表 order by 平均学分绩点 DESC";
            Door dao = new Door();
            IDataReader dr = dao.Reader(sql);
            while (dr.Read())
            {
                string a, b, c, d, e, f;
                a = dr["学号"].ToString();
                b = dr["姓名"].ToString();
                c = dr["系"].ToString();
                d = dr["班级"].ToString();
                e = dr["已修学分"].ToString();
                f = dr["平均学分绩点"].ToString();

                string[] str = { a, b, c, d, e, f };
                dataGridView1.Rows.Add(str);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Click年级学生排名_Load(object sender, EventArgs e)
        {

        }
    }
}
