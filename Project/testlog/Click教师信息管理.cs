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
    public partial class Click教师信息管理 : Form
    {
        DataSet dsStu = null;
        SqlDataAdapter adapterStu = null;
        //当前视图全局可见
        String sql = null;

        public Click教师信息管理()
        {
            InitializeComponent();
        }

        private void ShowStudentAll()
        {
            if(sql != null)
            {
                Door door = new Door();
                SqlConnection conn = door.Connection();

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
        }

        private void Tree1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs i)
        {
            if (i.Node.Level == 1)
            {
                //院教师信息
                sql = "select * from 教师信息表 where 教师编号 in (select 教师编号 from 教师信息表 where 学院 = '" + i.Node.Text + "')";
                ShowStudentAll();
            }
            if (i.Node.Level == 2)
            {
                //系教师信息
                sql = "select * from 教师信息表 where 教师编号 in (select 教师编号 from 教师信息表 where 系 = '" + i.Node.Text + "')";
                ShowStudentAll();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                if (comboBox2.Text == "")
                {
                    MessageBox.Show("职称为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    sql = "select * from 教师信息表 where 教师编号 in (select 教师编号 from 教师信息表 where 职称 = '" + comboBox2.Text + "')";
                    ShowStudentAll();
                }
            }
            if (radioButton3.Checked)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("系别为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //Column4.HeaderText = "专业排名";
                    sql = "select * from 教师信息表 where 教师编号 in (select 教师编号 from 教师信息表 where 系 = '" + textBox1.Text + "')";
                    ShowStudentAll();
                }
            }
            if (radioButton1.Checked)
            {
                if (comboBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("教师信息为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (comboBox3.Text == "教师编号")
                {
                    sql = "select * from 教师信息表 where 教师编号 = '" + textBox4.Text + "' ";
                    ShowStudentAll();
                }
                else
                {
                    sql = "select * from 教师信息表 where 姓名 = '" + textBox4.Text + "' ";
                    ShowStudentAll();
                }
            }
        }

        private void CancelAll()
        {
            textBox1.Text = null;
            textBox2.Text = null;
            comboBox3.Text = null;
            comboBox2.Text = null;
            comboBox1.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox8.Text = null;
            ShowStudentAll();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            CancelAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CancelAll();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String Sdept = null;
            if (textBox5.Text == "" || textBox6.Text == "" || comboBox1.Text == "" || textBox8.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("输入不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);//弹出一个对话框,其中的内容
            }
            else
            {
                string sql0 = "select 系编号 from 教师信息表 where 系 = '" + textBox2.Text + "'";
                Door door0 = new Door();
                IDataReader dr0 = door0.Reader(sql0);//Reader是Door封装的读入方法
                if (dr0.Read())//.Read()是IDataReader自带的方法，若成功读到信息，返回1
                {
                    Sdept = dr0["系编号"].ToString();
                }
                else
                {
                    MessageBox.Show("系别不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string sql = "insert into 教师 values('" + textBox5.Text + "','" + textBox6.Text + "','" + comboBox1.Text + "','" + textBox8.Text + "','" + Sdept + "')";
                Door InsertDoor = new Door();
                try
                {
                    int check = InsertDoor.Excute(sql);//若添加成功，check值为1
                    MessageBox.Show("新增教师成功！");
                    CancelAll();
                }
                catch (Exception ex)
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
                String stuNo = dataGridView1.CurrentRow.Cells["教师编号"].Value.ToString();
                String stuName = dataGridView1.CurrentRow.Cells["姓名"].Value.ToString();
                DialogResult result = MessageBox.Show("确定要删除" + stuName + "的信息吗？该教师的教学班也将同时被删除！", "提示信息", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    //先执行删除成绩信息
                    Door door = new Door();
                    SqlConnection conn = door.Connection();
                    String sqlDelScore = "delete from 教师 where 教师编号='" + stuNo + "'";
                    SqlCommand command = new SqlCommand(sqlDelScore, conn);
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("删除教师成功！");
                        CancelAll();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定提交修改吗？", "提示信息", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //若需求简单仅涉及单张表（单表视图），直接绑定数据集与dataGridView，无需考虑UpdateCommand
                //若涉及多表或多表连接的视图，必须指定UpdateCommand的对象和内容（执行指定的sql语句）

                //1、指定UpdateCommand所执行的sql语句
                adapterStu.UpdateCommand = new SqlCommand("update 教师 set 姓名 = @姓名, 职称 = @职称, 联系方式 = @联系方式, 系编号 = @系编号 where 教师编号 = @教师编号");
                //2、传递参数
                adapterStu.UpdateCommand.Parameters.Add("@姓名", SqlDbType.VarChar, 50, "姓名");
                adapterStu.UpdateCommand.Parameters.Add("@职称", SqlDbType.VarChar, 50, "职称");
                adapterStu.UpdateCommand.Parameters.Add("@联系方式", SqlDbType.VarChar, 50, "联系方式");
                adapterStu.UpdateCommand.Parameters.Add("@系编号", SqlDbType.VarChar, 50, "系编号");
                adapterStu.UpdateCommand.Parameters.Add("@教师编号", SqlDbType.VarChar, 50, "教师编号");

                //
                SqlCommandBuilder builder = new SqlCommandBuilder(adapterStu);
                try
                {
                    adapterStu.Update(dsStu.Tables["StudentInfo"]);
                    MessageBox.Show("提交修改成功！");
                    CancelAll();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CancelAll();
        }
    }
}
