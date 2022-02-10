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
    public partial class Click学生成绩录入 : Form
    {
        string TID1;//传入教师编号
        public Click学生成绩录入(string TID)
        {
            TID1 = TID;
            InitializeComponent();
            showTable();
        }
        private void showTable()
        {
            dataGridView1.Rows.Clear();
            string sql = " select* from 学生学情表 where 课程号 = '" + TID1 + "'";
            Door Choose_course = new Door();
            IDataReader dr = Choose_course.Reader(sql);
            while (dr.Read())
            {
                string a, b, c, d, e, f;
                a = dr["学号"].ToString();
                b = dr["姓名"].ToString();
                c = dr["课程号"].ToString();
                d = dr["课程"].ToString();
                e = dr["学分"].ToString();
                f = dr["成绩"].ToString();
                string[] str = { a, b, c, d, e, f};
                dataGridView1.Rows.Add(str);
            }

        }
        /*
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string Sno1 = dataGridView1.SelectedCells[0].Value.ToString();
                string Cno1 = dataGridView1.SelectedCells[2].Value.ToString();
                string Grade1 = dataGridView1.SelectedCells[5].Value.ToString();

            }
            catch
            {
                //MessageBox.Show("请选择一整行，再登陆成绩");
                return;
            }
            string Sno = dataGridView1.SelectedCells[0].Value.ToString();
            string Cno = dataGridView1.SelectedCells[2].Value.ToString();
            string Grade = dataGridView1.SelectedCells[5].Value.ToString();
            string sql = "Update 课程学生SC set 成绩 = " + Grade + " where 学号 = '" + Sno + "' and 课程号 = '" + Cno + "'";
            Door Update_Grade = new Door();
            try
            {
                Update_Grade.Excute(sql);
                MessageBox.Show("成绩登陆成功！");
                dataGridView1.Rows.Clear();
                showTable();
            }
            catch
            {
                MessageBox.Show("请点击第一列空白处，选择一整行，再登陆成绩");
                return;

                //MessageBox.Show("请勿重复选课！");
            }
        }
        */
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        { 
        
        }
            private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string Cno = dataGridView1.SelectedCells[2].Value.ToString();
                string[] str1 = { dataGridView1.SelectedCells[0].Value.ToString(), dataGridView1.SelectedCells[1].Value.ToString(), dataGridView1.SelectedCells[3].Value.ToString(), dataGridView1.SelectedCells[5].Value.ToString(), Cno };
            }
            catch
            {
                MessageBox.Show("请选择一整行，再登陆成绩");
                return;
            }
            string Cno1 = dataGridView1.SelectedCells[2].Value.ToString();
            string[] str = { dataGridView1.SelectedCells[0].Value.ToString(), dataGridView1.SelectedCells[1].Value.ToString(), dataGridView1.SelectedCells[3].Value.ToString(), dataGridView1.SelectedCells[5].Value.ToString(), Cno1 };
            Click写入学生成绩 Insert_student = new Click写入学生成绩(str);
            //把这个数组整体的传到修改窗体，需要重写构造方法
            Insert_student.ShowDialog();
            dataGridView1.Rows.Clear();
            showTable();
        }
    }
}
