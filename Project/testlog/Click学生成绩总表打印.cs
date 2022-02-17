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
    public partial class Click学生成绩总表打印 : Form
    {
        string SID1;
        public Click学生成绩总表打印(string SID)
        {
            SID1 = SID;
            InitializeComponent();
            showTable();
        }

        private void showTable()
        {
            string spacer = "                    ";//用于空格调整布局
            label10.Text = spacer + "打印时间：" +  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
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
                label6.Text = "姓名：" + dr["姓名"].ToString();
                string[] str = { a, b, c, d, e, f, g, h };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();
            string sql2 = "select* from 学生信息表 where 学号 = '" + SID1 + "'";
            Door Print_info = new Door();
            IDataReader dr2 = Print_info.Reader(sql2);
            while (dr2.Read())
            {
                label2.Text = "学院：" + dr2["学院"].ToString();
                label3.Text = "系：" + dr2["系"].ToString();
                label4.Text = "专业：" + dr2["专业"].ToString();
                label5.Text = "学号：" + dr2["学号"].ToString();
                label6.Text = "姓名：" + dr2["姓名"].ToString();
                label7.Text = "班级：" + dr2["班级"].ToString();
            }
            dr2.Close();
            string sql3 = "select rank() over(order by 平均学分绩点 desc) as 排名,* from 年级排名表 where 学号 = '" + SID1 + "'";
            Door Print_GPA = new Door();
            IDataReader dr3 = Print_GPA.Reader(sql3);
            while (dr3.Read())
            {
                label8.Text = "     已修学分：" + dr3["已修学分"].ToString();
                float temp0 = Convert.ToSingle(dr3["平均学分绩点"].ToString());
                string temp = string.Format("{0:N2}", temp0);//先转浮点再利用Format方法，注意该方法不对字符串生效，所以得先转float
                label9.Text = spacer + "历年平均学分绩点：" + temp;
            }
            dr3.Close();
        }
    }
}
