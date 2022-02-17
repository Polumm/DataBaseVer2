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
    public partial class Click排教学班 : Form
    {
        String Cno = null;
        String classroom = null;

        //数据集dataset + 适配器实现快速绑定
        //数据集和适配器全局可见
        DataSet dsSectionClass = null;
        SqlDataAdapter adapterSectionClass = null;

        public Click排教学班(string CourseNo)
        {
            Cno = CourseNo;
            InitializeComponent();
            button3.Text = "提\n交\n修\n改\n";
            button4.Text = "撤\n消\n修\n改\n";
            showTable();
        }
        public Click排教学班(string CourseNo, string classroomInfo)
        {
            Cno = CourseNo;
            classroom = classroomInfo;
            InitializeComponent();
            button3.Text = "提\n交\n修\n改\n";
            button4.Text = "撤\n消\n修\n改\n";
            textBox3.Text = classroomInfo;
            textBox3.ReadOnly = true;
            showTable();
        }

        private void showTable()
        {
            string Cname = "";
            string preRead = " select 课程名 from 课程 where 课程代号 = '"+ Cno +"'";
            Door pre = new Door();
            IDataReader dr0 = pre.Reader(preRead);
            if (dr0.Read())
            {
                Cname = dr0["课程名"].ToString();
            }
            label6.Text = "课程";
            label7.Text = Cname;
            label8.Text = "课程代号";
            label9.Text = Cno;
            Door door = new Door();
            SqlConnection conn = door.Connection();
            string sql = " select* from 教学班 where 课程代号 = '"+ Cno +"'";
            //快速绑定：
            //1、新建适配器
            adapterSectionClass = new SqlDataAdapter(sql, conn);
            //2、新建数据集
            dsSectionClass = new DataSet();
            //3、将数据注入数据集，建立CourseInfo虚拟表
            adapterSectionClass.Fill(dsSectionClass, "SectionClassInfo");
            //4、将数据集的虚拟表与dataGridView绑定
            dataGridView1.DataSource = dsSectionClass.Tables["SectionClassInfo"];
            dataGridView1.Columns["课程教学ID"].Width = 80;
            dataGridView1.Columns["课程教学ID"].ReadOnly = true;
            dataGridView1.Columns["上课时间"].Width = 80;
            dataGridView1.Columns["教室编号"].Width = 80;
            dataGridView1.Columns["教师编号"].Width = 80;
            dataGridView1.Columns["教师编号"].ReadOnly = true;
            dataGridView1.Columns["计划上限"].Width = 80;
            dataGridView1.Columns["已选人数"].Width = 80;
            dataGridView1.Columns["已选人数"].ReadOnly = true;
            dataGridView1.Columns["课程代号"].Width = 80;
            dataGridView1.Columns["课程代号"].ReadOnly = true;
            //防止产生重复列
            try
            {
                dataGridView1.Columns.Remove("paijiaoxuebanbuttons");
            }
            catch
            { }
        }

        private void CancelAll()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            showTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("输入不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);//弹出一个对话框,其中的内容
            }
            else
            {
                string check_id = " select * from 教学班 where 课程教学ID = '"+ textBox1.Text + "'";
                Door check_door0 = new Door();
                IDataReader dr0 = check_door0.Reader(check_id);
                if (dr0.Read())
                {
                    MessageBox.Show("课程教学ID已存在，请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dr0.Close();
                    return;
                }
                string check_classroom = " select * from 教学班 where 教室编号 = '" + textBox3.Text + "' and 上课时间 = '" + textBox2.Text + "'";
                Door check_door1 = new Door();
                IDataReader dr1 = check_door1.Reader(check_classroom);
                if (dr1.Read())
                {
                    MessageBox.Show("该教室在该时间段已被占用，请重新安排", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dr1.Close();
                    return;
                }
                string check_teacher = " select 教师编号 from 教师 where 教师编号 = '"+ textBox4.Text +"'";
                Door check_door2 = new Door();
                IDataReader dr2 = check_door2.Reader(check_teacher);
                if (!dr2.Read())
                {
                    MessageBox.Show("教师编号不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dr2.Close();
                    return;
                }

                //若合法择插入
                int num = Convert.ToInt32(textBox5.Text);
                string sql = "insert into 教学班 values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','"+ num + "',0,'"+ Cno +"')";
                Door InsertDoor = new Door();
                try
                {
                    InsertDoor.Excute(sql);
                    MessageBox.Show("新增教学班成功！");
                    CancelAll();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定提交修改吗？", "提示信息", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //
                SqlCommandBuilder builder = new SqlCommandBuilder(adapterSectionClass);
                try
                {
                    adapterSectionClass.Update(dsSectionClass.Tables["SectionClassInfo"]);
                    MessageBox.Show("提交修改成功！");
                    //CancelAll();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Selected)
            { //是否选中了某行
                //获取该行索引
                //int i = dataGridView1.CurrentRow.Index;
                //获取学号
                String ID = dataGridView1.CurrentRow.Cells["课程教学ID"].Value.ToString();
                DialogResult result = MessageBox.Show("确定要删除课程教学ID为" + ID + "的教学班？该教学班的选课记录也将同时被删除！", "提示信息", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    //先执行删除成绩信息
                    Door door = new Door();
                    SqlConnection conn = door.Connection();
                    String DelSectionClass = "delete from 教学班 where 课程教学ID='" + ID + "'";
                    SqlCommand command = new SqlCommand(DelSectionClass, conn);
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("删除课程成功！");
                    }
                    catch
                    {
                        MessageBox.Show("已录入成绩，删除失败！");
                    }
                }
            }
            CancelAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CancelAll();
        }
    }
}
