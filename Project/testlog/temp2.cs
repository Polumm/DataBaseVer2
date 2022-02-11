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
    public partial class temp2 : Form
    {
        string SID1;
        public temp2()
        {
            InitializeComponent();
        }

        public temp2(string SID)
        {
            SID1 = SID;
            InitializeComponent();
            showTable();
        }

        private void showTable()
        {
            dataGridView1.Rows.Clear();
            string sql = " select* from 学生成绩评价表 where 学号 = '" + SID1 + "'";
            Door Print_grade = new Door();
            IDataReader dr = Print_grade.Reader(sql);
            while (dr.Read())
            {
                string a, b, c, d, e, f, g, h;
                a = dr["课程号"].ToString();
                b = dr["课程"].ToString();
                c = dr["学分"].ToString();
                d = dr["课程类型"].ToString();
                e = dr["成绩"].ToString();
                f = dr["等级"].ToString();
                g = dr["绩点"].ToString();
                h = dr["权重"].ToString();
                label6.Text = "姓名：" + dr["姓名"].ToString() ;
                string[] str = { a, b, c, d, e, f, g, h };
                dataGridView1.Rows.Add(str);
            }

        }
    }

}
