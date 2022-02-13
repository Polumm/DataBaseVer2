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
                Column4.HeaderText = "院排名";
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
                Column4.HeaderText = "系排名";
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
                    float temp = Convert.ToSingle(dr["平均学分绩点"].ToString());
                    f = string.Format("{0:N2}", temp);//先转浮点再利用Format方法，注意该方法不对字符串生效，所以得先转float
                    g = dr["排名"].ToString();

                    string[] str = { a, b, c, d, e, f, g};
                    dataGridView1.Rows.Add(str);
                }
            }
            if(i.Node.Level == 3)
            {
                Column4.HeaderText = "专业排名";
                string sql = "select rank() over(order by 平均学分绩点 desc) as 排名,* from 年级排名表 where 专业 = '"+ i.Node.Text +"' ";
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
            if(i.Node.Level == 4)
            {
                Column4.HeaderText = "班排名";
                string sql = "select rank() over(order by 平均学分绩点 desc) as 排名,* from 年级排名表 where 班级 = '"+ i.Node.Text +"' ";
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

        }

        private void btnSelect_Click(object sender, EventArgs i)
        {
            string major;
            dataGridView1.Rows.Clear();
            if (radioButton2.Checked)
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("班级编号为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Column4.HeaderText = "班排名";
                    string sql = "select rank() over(order by 平均学分绩点 desc) as 排名,* from 年级排名表 where 班级 = '" + textBox2.Text + "' ";
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

                        string[] str = { a, b, c, d, e, f, g };
                        dataGridView1.Rows.Add(str);
                    }
                }
            }
            if (radioButton3.Checked)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("专业为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Column4.HeaderText = "专业排名";
                    string sql = "select rank() over(order by 平均学分绩点 desc) as 排名,* from 年级排名表 where 专业 = '" + textBox1.Text + "' ";
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

                        string[] str = { a, b, c, d, e, f, g };
                        dataGridView1.Rows.Add(str);
                    }
                }
            }
            if (radioButton1.Checked)
            {
                if (textBox4.Text == "" && textBox3.Text == "")
                {
                    MessageBox.Show("学生信息为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBox4.Text == "")
                {
                    Column4.HeaderText = "专业排名";
                    string sql0 = "select 专业 from 学生, 班 where 学生.班级编号 = 班.班级编号 and 学生.姓名 = '" + textBox3.Text + "' ";
                    Door dao0 = new Door();
                    IDataReader dr0 = dao0.Reader(sql0);
                    if (dr0.Read())
                    {
                        major = dr0["专业"].ToString();
                        string sql = "select rank() over(order by 平均学分绩点 desc) as 排名,* from 年级排名表 where 专业 = '" + major + "' ";
                        Door dao = new Door();
                        IDataReader dr = dao.Reader(sql);
                        while (dr.Read())
                        {
                            if (dr["姓名"].ToString() == textBox3.Text)
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

                                string[] str = { a, b, c, d, e, f, g };
                                dataGridView1.Rows.Add(str);
                            }
                        }
                    }
                }
                else
                {
                    Column4.HeaderText = "专业排名";
                    string sql0 = "select 专业 from 学生, 班 where 学生.班级编号 = 班.班级编号 and 学生.学号 = '"+ textBox4.Text +"' ";
                    Door dao0 = new Door();
                    IDataReader dr0 = dao0.Reader(sql0);
                    if (dr0.Read())
                    {
                        major = dr0["专业"].ToString();
                        string sql = "select rank() over(order by 平均学分绩点 desc) as 排名,* from 年级排名表 where 专业 = '" + major + "' ";
                        Door dao = new Door();
                        IDataReader dr = dao.Reader(sql);
                        while (dr.Read())
                        {
                            if (dr["学号"].ToString() == textBox4.Text)
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

                                string[] str = { a, b, c, d, e, f, g };
                                dataGridView1.Rows.Add(str);
                            }
                        }
                    }                   
                }
            }
        }

        private void button1_Click(object sender, EventArgs i)
        {
            dataGridView1.Rows.Clear();
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
        }
    }
}
