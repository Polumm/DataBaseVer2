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
    public partial class Click修改密码 : Form
    {
        //该类的全局变量，各方法都可见
        string UserName1, right1;
        public Click修改密码()
        {
            InitializeComponent();
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

        //调用构造函数时传入用户名、权限
        public Click修改密码(string UserName, string right)
        {
            InitializeComponent();
            UserName1 = UserName;
            right1 = right;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("输入不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);//弹出一个对话框,其中的内容
            }
            else
            {
                string sql = "select 用户名, 密码 from " + right1 + "密码表 where 用户名 ='" + UserName1 + "' and 密码 = '" + EncryptWithMD5(textBox1.Text.Trim()) + "'";
                Door dr = new Door();
                IDataReader check_origin_password = dr.Reader(sql);//Reader是Door封装的读入方法
                if (!check_origin_password.Read())//.Read()是IDataReader自带的方法，若成功读到信息，返回1
                {
                    MessageBox.Show("原始密码错误！");
                }
                else
                {
                    if (textBox2.Text != textBox3.Text)
                    {
                        MessageBox.Show("两次新密码不一致！");
                    }
                    else
                    {
                        string sql1 = "Update " + right1 + "密码表 set 密码 = '" + EncryptWithMD5(textBox3.Text.Trim()) + "' where 用户名 = '"+ UserName1 +"'";
                        Door Update_password = new Door();
                        int check = Update_password.Excute(sql1);//若添加成功，check值为1
                        if (check > 0)
                        {
                            MessageBox.Show("修改密码成功！");
                            textBox1.Text = null;
                            textBox2.Text = null;
                            textBox3.Text = null;
                        }
                    }  
                }
            }
        }
    }
}
