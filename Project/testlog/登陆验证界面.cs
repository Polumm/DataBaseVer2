using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;//md5加密命名空间


namespace testlog
{
    public partial class 登陆验证界面 : Form
    {
        public 登陆验证界面()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //一旦执行计时器事件，就会移动
            if (pictureBox1.Location.X < 150)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X + 3, pictureBox1.Location.Y);
            }
            //移动特效结束，窗体界面切换
            else
            {
                if(comboBox1.Text == "管理员")
                {
                    管理员功能区界面 formAdmin_Win= new 管理员功能区界面();
                    formAdmin_Win.Show();
                    this.Hide();//主窗体结束，程序随即结束，因此此时只能先隐藏
                    //this.Close();
                }
                timer1.Stop(); 
                if(comboBox1.Text == "学生")
                {
                    学生功能区界面 formAdmin_Win = new 学生功能区界面(textBox1.Text);
                    formAdmin_Win.Show();
                    this.Hide();//主窗体结束，程序随即结束，因此此时只能先隐藏
                    //this.Close();
                }
                timer1.Stop(); 
                if(comboBox1.Text == "教师")
                {
                    教师功能区界面 formAdmin_Win = new 教师功能区界面(textBox1.Text);
                    formAdmin_Win.Show();
                    this.Hide();//主窗体结束，程序随即结束，因此此时只能先隐藏
                    //this.Close();
                }
                timer1.Stop(); 
            }
            
        }
        //登陆事件


        private void button1_Click(object sender, EventArgs e)
        {
            if (login())//test
            {
                timer1.Start();
                //如果登陆成功，隐藏多余控件,仅留下图片
                textBox1.Visible = false;
                textBox2.Visible = false;
                comboBox1.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;

            }
            else
            {
                MessageBox.Show("用户名或密码不正确，请重新输入！");
            }
        }

        public static string EncryptWithMD5(string source)
        {
            //MD5加密，source为要加密的字符串
            byte[] sor = Encoding.UTF8.GetBytes(source);//将字符串编码为一个字符序列
            MD5 md5 = MD5.Create();
            byte[] result = md5.ComputeHash(sor);//计算指定字节数组的哈希值
            StringBuilder strbul = new StringBuilder(40);//可变字符字符串
            for (int i = 0; i < result.Length; i++)
            {
                strbul.Append(result[i].ToString("x2"));//加密结果"x2"结果为32位,"x3"结果为48位,"x4"结果为64位
                //向strbul字符串后追加
            }
            return strbul.ToString();
        }

        //登陆方法，验证登录
        private bool login()
        {
            if (textBox1.Text=="" || textBox2.Text=="" || comboBox1.Text=="")
            {
                MessageBox.Show("输入不完整，请重新输入", "提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);//提示，多重重载
                return false;
            }
            //根据下拉选框中的判断调用sql语句
            String password = EncryptWithMD5(textBox2.Text.Trim());
            if (comboBox1.Text == "学生")
            {
                string sql = "select 用户名, 密码 from 学生密码表 where 用户名 ='"+ textBox1.Text + "' and 密码 = '" + password + "'";
                Door dr = new Door();
                IDataReader Student_Door = dr.Reader(sql);//Reader是Door封装的读入方法
                if (Student_Door.Read())//.Read()是IDataReader自带的方法，若成功读到信息，返回1
                {
                    return true;
                }
                {
                    return false;
                }
            }
            if(comboBox1.Text == "教师")
            {
                string sql = "select 用户名, 密码 from 教师密码表 where 用户名 ='" + textBox1.Text + "' and 密码 = '" + password + "'";
                Door dr = new Door();
                IDataReader Student_Door = dr.Reader(sql);//Reader是Door封装的读入方法
                if (Student_Door.Read())//.Read()是IDataReader自带的方法，若成功读到信息，返回1
                {
                    return true;
                }
                {
                    return false;
                }
                // "select 用户名, 密码 from 管理员密码表 where 用户名 =' " + textBox1.Text + "' and 密码 = '" + textBox2.Text + "'; ";
            }
            if(comboBox1.Text == "管理员")
            {   //务必小心，sql是字符串，如果其中的引号是中文字符，编译器不会报错！
                string sql = "select 用户名, 密码 from 管理员密码表 where 用户名 ='"+ textBox1.Text +"' and 密码 = '"+ password + "'";
                Door dr = new Door();
                IDataReader Admin_Door = dr.Reader(sql);//Reader是Door封装的读入方法
                if (Admin_Door.Read())//.Read()是IDataReader自带的方法，若成功读到信息，返回1
                {
                    return true;
                }
                {
                    return false;
                }

            }
            return false;

        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {//取消事件
            textBox1.Text = null;
            textBox2.Text = null;
            comboBox1.Text = null;
  
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
