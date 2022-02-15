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
    public partial class Click学生成绩录入 : Form
    {
        String TID1;
        //数据集和适配器全局可见
        DataSet dsStu = null;
        SqlDataAdapter adapterStu = null;
        //课程教学ID
        String CTID;
        //课程名
        String Ccname;
        //授课教师
        String Ctname;
        //上课时间
        String Ctime; 

        public Click学生成绩录入()
        {
            InitializeComponent();
        }
        public Click学生成绩录入(string TID)
        {
            TID1 = TID;
            InitializeComponent();
            showTable1();
        }

        private void showTable1()
        {
            dataGridView1.Rows.Clear();
            string sql = " select* from 学生可选课表 where 教师编号 = '" + TID1 + "'";
            Door Choose_course = new Door();
            IDataReader dr = Choose_course.Reader(sql);
            while (dr.Read())
            {
                string a, b, c, d, e, f, g, h, temp1, temp2, temp3, temp4;
                a = dr["课程"].ToString();
                b = dr["课程号"].ToString();
                c = dr["学分"].ToString();
                d = dr["授课老师"].ToString();
                e = dr["上课时间"].ToString();
                temp1 = dr["空间位置"].ToString();
                temp2 = dr["教室编号"].ToString();
                temp3 = dr["当前人数"].ToString();
                temp4 = dr["计划上限"].ToString();
                f = temp1 + " " + temp2;
                g = temp3 + "/" + temp4;
                h = dr["课程教学ID"].ToString();

                string[] str = { a, b, c, d, e, f, g, h};
                dataGridView1.Rows.Add(str);
            }
            //添加buttons列
            DataGridViewButtonColumn dgv_button_col3 = new DataGridViewButtonColumn();
            // 设定列的名字
            dgv_button_col3.Name = "ResultButtons";
            dgv_button_col3.Width = 65;
            // 在所有按钮上表示"查看详情"
            dgv_button_col3.UseColumnTextForButtonValue = true;
            dgv_button_col3.Text = "登分";
            // 设置列标题
            dgv_button_col3.HeaderText = "点击登分";
            // 向DataGridView追加
            dataGridView1.Columns.Insert(dataGridView1.Columns.Count, dgv_button_col3);
        }
        private void showTable2()
        {
            //获取课程教学ID
            CTID = dataGridView1.SelectedCells[7].Value.ToString();
            //获取课程名
            Ccname = dataGridView1.SelectedCells[0].Value.ToString();
            //获取授课教师
            Ctname = dataGridView1.SelectedCells[3].Value.ToString();
            //获取上课时间
            Ctime = dataGridView1.SelectedCells[4].Value.ToString();
            //打表
            groupBox2.Text = Ctname + "   " + Ccname + "   " + Ctime;
            string sql_score = "select 姓名, 课程学生SC.学号, 成绩 from 课程学生SC, 学生 where 学生.学号 = 课程学生SC.学号 and 课程学生SC.课程教学ID = '" + CTID + "'";
            Door door = new Door();
            SqlConnection conn = door.Connection();
            //快速绑定：
            //1、新建适配器
            adapterStu = new SqlDataAdapter(sql_score, conn);
            //2、新建数据集
            dsStu = new DataSet();
            //3、将数据注入数据集，建立StudentInfo虚拟表
            adapterStu.Fill(dsStu, "StudentScore");
            //DataColumn dc1 = new DataColumn();
            DataColumn[] keys = new DataColumn[1];
            keys[0] = dsStu.Tables["StudentScore"].Columns["学号"];
            dsStu.Tables["StudentScore"].PrimaryKey = keys;
            //4、将数据集的虚拟表与dataGridView绑定
            dataGridView2.DataSource = dsStu.Tables["StudentScore"];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //获取行列索引
            if (dataGridView1.Columns[e.ColumnIndex].Name == "ResultButtons")
            {
                showTable2();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //若需求简单仅涉及单张表（单表视图），直接绑定数据集与dataGridView，无需考虑UpdateCommand
            //若涉及多表或多表连接的视图，必须指定UpdateCommand的对象和内容（执行指定的sql语句）

            //1、指定UpdateCommand所执行的sql语句
            adapterStu.UpdateCommand = new SqlCommand("update 课程学生SC set 成绩 = @成绩 where 学号 = @学号 and 课程教学ID = '"+ CTID + "'");
            //2、传递参数
            adapterStu.UpdateCommand.Parameters.Add("@学号", SqlDbType.VarChar, 20, "学号");
            adapterStu.UpdateCommand.Parameters.Add("@成绩", SqlDbType.Float, 8, "成绩");
            //
            SqlCommandBuilder builder = new SqlCommandBuilder(adapterStu);
            try
            {
                adapterStu.Update(dsStu.Tables["StudentScore"]);
                MessageBox.Show("提交修改成功！");
                showTable2();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showTable2();
        }
    }
}
