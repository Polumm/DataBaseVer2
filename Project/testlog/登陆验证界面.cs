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
        public string code = null; //验证码

        public 登陆验证界面()
        {
            InitializeComponent();
            groupBox1.BackColor = Color.FromArgb(20, 40, 60, 82);
        }

        private void 登陆验证界面_Load(object sender, EventArgs e)
        {
            Random ran = new Random();
            int number;
            char code1;
            //取五个数 
            for (int i = 0; i < 5; i++)
            {
                number = ran.Next();//取非负随机数
                if (number % 2 == 0)
                    code1 = (char)('0' + (char)(number % 10));//两个char类型运算会自动转换为int类型的运算
                else
                    code1 = (char)('A' + (char)(number % 26)); //转化为字符 

                this.code += code1.ToString();
            }

            label5.Text = code;//验证码
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
                    管理员功能区界面 formAdmin_Win= new 管理员功能区界面(textBox1.Text);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (login())//test
            {
                timer1.Start();
                //如果登陆成功，隐藏多余控件,仅留下图片
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                comboBox1.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;

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

            //获取用户输入
            String username = textBox1.Text.Trim(); //获取用户名
            String password = EncryptWithMD5(textBox2.Text.Trim());//获取密码
            String Identity = comboBox1.Text.Trim(); //取出身份

            string sql = "select 用户名 from 用户安全信息 where 用户名 = '"+ username + "' and 密码 = '"+ password + "' and 身份 = '"+ Identity + "'";
            Door Login_Door = new Door();
            IDataReader dr = Login_Door.Reader(sql);//Reader是Door封装的读入方法

            if (dr.Read()) //查询结果存在
            {
                if (textBox3.Text == code)//验证码正确
                {
                    MessageBox.Show("登录成功！", "Tips", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);//设置弹出对话窗
                    return true;
                }
                else
                {
                    MessageBox.Show("验证码错误！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("用户名或密码错误！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;

        }


        private void button2_Click(object sender, EventArgs e)
        {//取消事件
            textBox1.Text = null;
            textBox2.Text = null;
            comboBox1.Text = null;
  
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            code = null;
            Random ran = new Random();
            int number;
            char code1;
            //取五个数 
            for (int i = 0; i < 5; i++)
            {
                number = ran.Next();//取非负随机数
                if (number % 2 == 0)
                    code1 = (char)('0' + (char)(number % 10));//两个char类型运算会自动转换为int类型的运算
                else
                    code1 = (char)('A' + (char)(number % 26)); //转化为字符 

                this.code += code1.ToString();
            }
            label5.Text = code;//验证码
        }
    }
}
