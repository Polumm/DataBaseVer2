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
    public partial class Click添加课程1 : Form
    {
        string classroom;
        //数据集dataset + 适配器实现快速绑定
        //数据集和适配器全局可见
        DataSet dsCoures = null;
        SqlDataAdapter adapterCourse = null;


        public Click添加课程1()
        {
            InitializeComponent();
            button3.Text = "提\n交\n修\n改\n";
            button4.Text = "撤\n消\n修\n改\n";
            showTable();
        }
        public Click添加课程1(string classroom_info)
        {
            classroom = classroom_info;
            InitializeComponent();
            button3.Text = "提\n交\n修\n改\n";
            button4.Text = "撤\n消\n修\n改\n";
            showTable();
        }

        private void showTable()
        {
            Door door = new Door();
            SqlConnection conn = door.Connection();
            string sql = " select* from 课程";
            //快速绑定：
            //1、新建适配器
            adapterCourse = new SqlDataAdapter(sql, conn);
            //2、新建数据集
            dsCoures = new DataSet();
            //3、将数据注入数据集，建立CourseInfo虚拟表
            adapterCourse.Fill(dsCoures, "CourseInfo");
            //4、将数据集的虚拟表与dataGridView绑定
            dataGridView1.DataSource = dsCoures.Tables["CourseInfo"];
            dataGridView1.Columns["课程代号"].Width = 90;
            dataGridView1.Columns["课程名"].Width = 64;
            dataGridView1.Columns["课程类型"].Width = 90;
            dataGridView1.Columns["学分"].Width = 64;
            //防止产生重复列
            try
            {
                dataGridView1.Columns.Remove("paijiaoxuebanbuttons");
            }
            catch
            { }
            //添加buttons列
            DataGridViewButtonColumn dgv_button_col = new DataGridViewButtonColumn();
            // 设定列的名字
            dgv_button_col.Name = "paijiaoxuebanbuttons";
            // 在所有按钮上表示"查看详情"
            dgv_button_col.UseColumnTextForButtonValue = true;
            dgv_button_col.Text = "排教学班";
            // 设置列标题
            dgv_button_col.HeaderText = "点击排教学班";
            // 向DataGridView追加
            dataGridView1.Columns.Insert(dataGridView1.Columns.Count, dgv_button_col);

            //如果用自动生成的主键，刷新
            DataColumn[] keys = new DataColumn[1];
            keys[0] = dsCoures.Tables["CourseInfo"].Columns["学号"];
            dsCoures.Tables["CourseInfo"].PrimaryKey = keys;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox4.Text == "")
            {
                MessageBox.Show("输入不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);//弹出一个对话框,其中的内容
            }
            else
            {
                string check_sno = "select 课程名 from 课程 where 课程代号 = '" + textBox1.Text + "'";
                Door check_door1 = new Door();
                IDataReader dr1 = check_door1.Reader(check_sno);
                string check_cname = "select 课程代号 from 课程 where 课程名 = '" + textBox2.Text + "'";
                Door check_door2 = new Door();
                IDataReader dr2 = check_door2.Reader(check_cname);
                if (dr1.Read())
                {
                    MessageBox.Show("课程号已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dr1.Close();
                    return;
                }
                if (dr2.Read())
                {
                    MessageBox.Show("课程名已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dr2.Close();
                    return;
                }

                //若合法择插入
                string sql = "insert into 课程 values('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox4.Text + "','" + textBox3.Text + "')";
                Door InsertDoor = new Door();
                try
                {
                    InsertDoor.Excute(sql);
                    MessageBox.Show("新增课程成功！");
                    CancelAll();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CancelAll();
        }

        private void CancelAll()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox4.Text = "";
            showTable();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定提交修改吗？", "提示信息", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //
                SqlCommandBuilder builder = new SqlCommandBuilder(adapterCourse);
                try
                {
                    adapterCourse.Update(dsCoures.Tables["CourseInfo"]);
                    MessageBox.Show("提交修改成功！");
                    CancelAll();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CancelAll();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Selected)
            { //是否选中了某行
                //获取该行索引
                //int i = dataGridView1.CurrentRow.Index;
                //获取学号
                String Cno = dataGridView1.CurrentRow.Cells["课程代号"].Value.ToString();
                String Cname = dataGridView1.CurrentRow.Cells["课程名"].Value.ToString();
                DialogResult result = MessageBox.Show("确定要删除" + Cname + "课程吗？该课程的教学班也将同时被删除！", "提示信息", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    //先执行删除成绩信息
                    Door door = new Door();
                    SqlConnection conn = door.Connection();
                    String sqlDelScore = "delete from 课程 where 课程代号='" + Cno + "'";
                    SqlCommand command = new SqlCommand(sqlDelScore, conn);
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("删除课程成功！");
                        CancelAll();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //获取行列索引
            if (dataGridView1.Columns[e.ColumnIndex].Name == "paijiaoxuebanbuttons")
            {
                //获取课程代号
                int CnoIndex = dataGridView1.Columns["课程代号"].Index;
                String Cno = dataGridView1.SelectedCells[CnoIndex].Value.ToString();
                //检验是否重复选课

                try
                {
                    MessageBox.Show(Cno);
                }
                catch (SqlException sqlExc)
                {
                    MessageBox.Show(sqlExc.ToString());
                }
            }
        }
    }
}
