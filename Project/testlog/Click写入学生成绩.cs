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
    public partial class Click写入学生成绩 : Form
    {
        string[] str = new string[5];
        string Cno;
        public Click写入学生成绩()
        {
            InitializeComponent();
        }

        public Click写入学生成绩(string[] a)
        {
            InitializeComponent();
            for (int i = 0; i < 5; i++)
                str[i] = a[i];
            textBox1.Text = str[0];
            textBox2.Text = str[1];
            textBox3.Text = str[2];
            textBox4.Text = str[3];
            Cno = str[4];
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" )
            {
                MessageBox.Show("信息不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);//弹出一个对话框,其中的内容
            }
            else
            {
                if (textBox1.Text != str[0])
                    textBox1.Text = str[0];
                if (textBox2.Text != str[1])
                    textBox2.Text = str[1];
                if (textBox3.Text != str[2])
                    textBox3.Text = str[2];
                if (textBox4.Text != str[3])
                {
                    string sql = "Update 课程学生SC set 成绩 = " + textBox4.Text + " where 学号 = '" + textBox1.Text + "' and 课程号 = '" + Cno + "'";
                    Door Update_Grade = new Door();
                    try
                    {
                        int check =  Update_Grade.Excute(sql);
                        if (check > 0)
                        {
                            MessageBox.Show("成绩登陆成功！");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("成绩已提交，无法受理修改");
                        return;
                        //MessageBox.Show("请勿重复选课！");
                    }
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
        }

    }
}
