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
    public partial class Click写入修改信息 : Form
    {
        string[] str = new string[5];
        public Click写入修改信息()
        {
            InitializeComponent();
        }
        public Click写入修改信息(string[] a)
        {
            InitializeComponent();
            for (int i = 0; i < 5; i++)
                str[i] = a[i];
            textBox1.Text = str[0];
            textBox2.Text = str[1];
            textBox3.Text = str[2];
            textBox4.Text = str[3];
            textBox5.Text = str[4];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("修改不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);//弹出一个对话框,其中的内容
            }
            else
            {
                if (textBox1.Text != str[0])
                {
                    string sql1 = "update 学生 set 学号='" + textBox1.Text + "'where 学号='" + str[0] + "'";
                    Door Door1 = new Door();  
                    int check = Door1.Excute(sql1);//若修改成功，check值为1
                    if (check > 0)
                    {
                        MessageBox.Show("修改成功！查看修改结果请刷新");
                    }
                    str[0] = textBox1.Text;

                }
                if (textBox2.Text != str[1])
                {
                    string sql1 = "update 学生 set 姓名='" + textBox2.Text + "'where 学号='" + str[0] + "'";
                    Door Door1 = new Door();
                    int check = Door1.Excute(sql1);//若修改成功，check值为1
                    if (check > 0)
                    {
                        MessageBox.Show("修改成功！查看修改结果请刷新");
                    }
                    str[1] = textBox2.Text;

                }
                if (textBox3.Text != str[2])
                {
                    string sql1 = "update 学生 set 性别='" + textBox3.Text + "'where 学号='" + str[0] + "'";
                    Door Door1 = new Door();
                    int check = Door1.Excute(sql1);//若修改成功，check值为1
                    if (check > 0)
                    {
                        MessageBox.Show("修改成功！查看修改结果请刷新");
                    }
                    str[2] = textBox3.Text;

                }
                if (textBox4.Text != str[3])
                {
                    string sql1 = "update 学生 set 出生日期='" + textBox4.Text + "'where 学号='" + str[0] + "'";
                    Door Door1 = new Door();
                    int check = Door1.Excute(sql1);//若修改成功，check值为1
                    if (check > 0)
                    {
                        MessageBox.Show("修改成功！查看修改结果请刷新");
                    }
                    str[3] = textBox4.Text;

                }
                if (textBox5.Text != str[4])
                {
                    string sql1 = "update 学生 set 班级='" + textBox5.Text + "'where 学号='" + str[0] + "'";
                    Door Door1 = new Door();
                    int check = Door1.Excute(sql1);//若修改成功，check值为1
                    if (check > 0)
                    {
                        MessageBox.Show("修改成功！查看修改结果请刷新");
                    }
                    str[4] = textBox5.Text;

                }
                this.Close();
                //Click修改学生信息 rank = new Click修改学生信息();
                //rank.ShowDialog();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Click写入修改信息_Load(object sender, EventArgs e)
        {

        }
    }
 }

/*
                 string[] str = { dataGridView2.SelectedCells[0].Value.ToString(), dataGridView1.SelectedCells[1].Value.ToString(), dataGridView1.SelectedCells[2].Value.ToString(), dataGridView1.SelectedCells[3].Value.ToString(), dataGridView1.SelectedCells[4].Value.ToString() };
                Click添加学生信息 Insert_student = new Click添加学生信息(str);
            Insert_student.ShowDialog();
 */