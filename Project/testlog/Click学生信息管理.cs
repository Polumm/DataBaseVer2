using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;//添加命名空间

namespace testlog
{
    public partial class Click学生信息管理 : Form
    {
        //数据集和适配器全局可见
        DataSet dsStu = null;
        SqlDataAdapter adapterStu = null;
        //当前视图全局可见
        String sql;
        public Click学生信息管理()
        {
            InitializeComponent();
            //ShowStudentAll();
        }
        private void ShowStudentAll()
        {
            //String sql = "select * from 学生";
            Door door = new Door();
            SqlConnection conn = door.Connection();
            dsStu = new DataSet();
            adapterStu = new SqlDataAdapter(sql, conn);
            //以学号为索引进行绑定
            adapterStu.Fill(dsStu, "学号");
            dataGridView1.DataSource = dsStu.Tables["学号"];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定提交修改吗？", "提示信息", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SqlCommandBuilder builder = new SqlCommandBuilder(adapterStu);
                int i = adapterStu.Update(dsStu, "学号");
                if (i > 0)
                {
                    MessageBox.Show("修改成功！");
                    ShowStudentAll();
                }
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //获取当前选中行
            if (dataGridView1.CurrentRow.Selected)
            { //是否选中了某行
                //获取该行索引
                //int i = dataGridView1.CurrentRow.Index;
                //获取学号
                String stuNo = dataGridView1.CurrentRow.Cells["学号"].Value.ToString();
                String stuName = dataGridView1.CurrentRow.Cells["姓名"].Value.ToString();
                DialogResult result = MessageBox.Show("确定要删除" + stuName + "的信息吗？该学生成绩也将同时被删除！", "提示信息", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    //先执行删除成绩信息
                    Door door = new Door();
                    SqlConnection conn = door.Connection();
                    dsStu = new DataSet();
                    String sqlDelScore = "delete from 学生 where 学号='" + stuNo + "'";
                    SqlCommand command = new SqlCommand(sqlDelScore, conn);
                    int i = command.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("删除成功！");
                        ShowStudentAll();
                    }
                    else
                    {
                        MessageBox.Show("删除失败！");
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime date = dtpBorn.Value;  //出生日期
            String born = String.Format("{0}.{1}.{2}", date.Year, date.Month, date.Day);
            if (textBox5.Text == "" || textBox6.Text == "" || comboBox1.Text == "" || textBox8.Text == "" || born == "")
            {
                MessageBox.Show("输入不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);//弹出一个对话框,其中的内容
            }
            else
            {
                string sql = "insert into 学生 values('" + textBox5.Text + "','" + textBox6.Text + "','" + comboBox1.Text + "','" + born + "','" + textBox8.Text + "')";
                Door InsertDoor = new Door();
                try
                {
                    int check = InsertDoor.Excute(sql);//若添加成功，check值为1
                    MessageBox.Show("新增学生成功！");
                    CancelAll();
                }
                catch
                {
                    MessageBox.Show("违反约束条件，新增失败！");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CancelAll();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CancelAll();
        }

        private void CancelAll()
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox8.Text = null;
            ShowStudentAll();
        }

        private void Tree1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs i)
        {
            if (i.Node.Level == 1)
            {
                //院学生信息
                sql = "select * from 学生 where 学号 in (select 学号 from 学生信息表 where 学院 = '" + i.Node.Text + "')";
                ShowStudentAll();
            }
            if (i.Node.Level == 2)
            {
                //系学生信息
                sql = "select * from 学生 where 学号 in (select 学号 from 学生信息表 where 系 = '" + i.Node.Text + "')";
                ShowStudentAll();
            }
            if (i.Node.Level == 3)
            {
                //专业学生信息
                sql = "select * from 学生 where 学号 in (select 学号 from 学生信息表 where 专业 = '" + i.Node.Text + "')";
                ShowStudentAll();
            }
            if (i.Node.Level == 4)
            {
                //班学生信息
                sql = "select * from 学生 where 学号 in (select 学号 from 学生信息表 where 班级编号 = '" + i.Node.Text + "')";
                ShowStudentAll();
            }


        }

        private void btnSelect_Click(object sender, EventArgs i)
        {
            if (radioButton2.Checked)
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("班级编号为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //Column4.HeaderText = "班排名";
                    sql = "select * from 学生 where 学号 in (select 学号 from 学生信息表 where 班级 = '" + textBox2.Text + "')";
                    ShowStudentAll();
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
                    //Column4.HeaderText = "专业排名";
                    sql = "select * from 学生 where 学号 in (select 学号 from 学生信息表 where 专业 = '" + textBox1.Text + "')";
                    ShowStudentAll();
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
                    //Column4.HeaderText = "专业排名,姓名搜索";
                    sql = "select * from 学生 where 姓名 = '" + textBox3.Text + "' ";
                    ShowStudentAll();
                }
                else
                {
                    //Column4.HeaderText = "专业排名，学号搜索";
                    sql = "select * from 学生 where 学号 = '" + textBox4.Text + "' ";
                    ShowStudentAll();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CancelAll();
        }
    }
}
