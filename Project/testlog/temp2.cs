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
        public temp2()
        {
            InitializeComponent();
        }
        private void show()
        {
            //tvMenu.Nodes.
        }

        private void Tree1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs i)
        {
            dataGridView1.Rows.Clear();
            if (i.Node.Level == 1)
            {
                string sql = "select rank() over(order by 平均学分绩点 desc) as 排名,* from 年级排名表 where 学院 = '"+ i.Node.Text +"' ";
                Door dao = new Door();
                IDataReader dr = dao.Reader(sql);
                while (dr.Read())
                {
                    string a, b, c, d, e, f, g;
                    a = dr["学号"].ToString();
                    b = dr["姓名"].ToString();
                    c = dr["专业"].ToString();
                    d = dr["班级"].ToString();
                    e = dr["已修学分"].ToString();
                    float temp = Convert.ToSingle(dr["平均学分绩点"].ToString());
                    f = string.Format("{0:N2}", temp);//先转浮点再利用Format方法，注意该方法不对字符串生效，所以得先转float
                    g = dr["排名"].ToString();

                    string[] str = { a, b, c, d, e, f, g};
                    dataGridView1.Rows.Add(str);
                }
            }
            if(i.Node.Level == 2)
            {
                string sql = "select rank() over(order by 平均学分绩点 desc) as 排名,* from 年级排名表 where 系 = '"+ i.Node.Text +"' ";
                Door dao = new Door();
                IDataReader dr = dao.Reader(sql);
                while (dr.Read())
                {
                    string a, b, c, d, e, f, g;
                    a = dr["学号"].ToString();
                    b = dr["姓名"].ToString();
                    c = dr["专业"].ToString();
                    d = dr["班级"].ToString();
                    e = dr["已修学分"].ToString();
                    f = dr["平均学分绩点"].ToString().Substring(0, 4);
                    g = dr["排名"].ToString();

                    string[] str = { a, b, c, d, e, f, g};
                    dataGridView1.Rows.Add(str);
                }
            }

        }
    }
}
