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
        //普通绑定的全局变量
        //DataTable dt = null;
        //BindingSource bs = null;

        //数据集dataset + 适配器实现快速绑定
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
            Door door = new Door();
            SqlConnection conn = door.Connection();
            /*            //普通绑定，以BindingSource作为数据（引用）的容器进行传递
            //1、新建适配器
            adapterStu = new SqlDataAdapter(sql, conn);
            //2、新建数据表，是虚拟表，临时保存数据。DataTable的对象包括DataSet和DataView。
            dt = new DataTable();
            //3、将数据注入虚拟表
            adapterStu.Fill(dt);
            //4、将虚拟表与dataGridView绑定
            dataGridView1.DataSource = dt;
            //5、新建并绑定BindingSource 
            bs = new BindingSource();
            bs.DataSource = dt; 
            conn.Close();
            // 设定单元格的ToolTip内容
            //dataGridView1.Columns[0].ToolTipText = "该列单元格的内容不能为空";*/


            //快速绑定：
            //1、新建适配器
            adapterStu = new SqlDataAdapter(sql, conn);
            //2、新建数据集
            dsStu = new DataSet();
            //3、将数据注入数据集，建立StudentInfo虚拟表
            adapterStu.Fill(dsStu, "StudentInfo");
            //4、将数据集的虚拟表与dataGridView绑定
            dataGridView1.DataSource = dsStu.Tables["StudentInfo"];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定提交修改吗？", "提示信息", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //若需求简单仅涉及单张表（单表视图），直接绑定数据集与dataGridView，无需考虑UpdateCommand
                //若涉及多表或多表连接的视图，必须指定UpdateCommand的对象和内容（执行指定的sql语句）

                //1、指定UpdateCommand所执行的sql语句
                adapterStu.UpdateCommand = new SqlCommand("update 学生 set 姓名 = @姓名, 性别 = @性别, 出生日期 = @出生日期, 班级编号 = @班级编号 where 学号 = @学号");
                //2、传递参数
                adapterStu.UpdateCommand.Parameters.Add("@学号", SqlDbType.VarChar, 50, "学号");
                adapterStu.UpdateCommand.Parameters.Add("@姓名", SqlDbType.VarChar, 50, "姓名");
                adapterStu.UpdateCommand.Parameters.Add("@性别", SqlDbType.VarChar, 50, "性别");
                adapterStu.UpdateCommand.Parameters.Add("@出生日期", SqlDbType.VarChar, 50, "出生年月");
                adapterStu.UpdateCommand.Parameters.Add("@班级编号", SqlDbType.VarChar, 50, "班级");

                //
                SqlCommandBuilder builder = new SqlCommandBuilder(adapterStu);
                try
                {
                    adapterStu.Update(dsStu.Tables["StudentInfo"]);
                    MessageBox.Show("提交修改成功！");
                    CancelAll();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
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
                    String sqlDelScore = "delete from 学生 where 学号='" + stuNo + "'";
                    SqlCommand command = new SqlCommand(sqlDelScore, conn);
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("删除学生成功！");
                        CancelAll();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
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
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
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
                sql = "select * from 学生信息表 where 学号 in (select 学号 from 学生信息表 where 学院 = '" + i.Node.Text + "')";
                ShowStudentAll();
            }
            if (i.Node.Level == 2)
            {
                //系学生信息
                sql = "select * from 学生信息表 where 学号 in (select 学号 from 学生信息表 where 系 = '" + i.Node.Text + "')";
                ShowStudentAll();
            }
            if (i.Node.Level == 3)
            {
                //专业学生信息
                sql = "select * from 学生信息表 where 学号 in (select 学号 from 学生信息表 where 专业 = '" + i.Node.Text + "')";
                ShowStudentAll();
            }
            if (i.Node.Level == 4)
            {
                //班学生信息
                sql = "select * from 学生信息表 where 学号 in (select 学号 from 学生信息表 where 班级 = '" + i.Node.Text + "')";
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
