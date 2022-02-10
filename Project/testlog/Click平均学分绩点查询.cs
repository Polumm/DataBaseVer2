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
    public partial class Click平均学分绩点查询 : Form
    {
        string Sno1;
        public Click平均学分绩点查询()
        {
            InitializeComponent();
        }
        public Click平均学分绩点查询(string Sno)
        {
            Sno1 = Sno;
            InitializeComponent();
            showTable();
        }

        private void showTable()
        {
            dataGridView1.Rows.Clear();
            string sql = " select* from 年级排名表 where 学号 = '" + Sno1 + "'";
            Door Print_grade = new Door();
            IDataReader dr = Print_grade.Reader(sql);
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
    }
}
