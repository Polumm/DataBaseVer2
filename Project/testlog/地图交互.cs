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
    public partial class 地图交互 : Form
    {
        public 地图交互()
        {
            InitializeComponent();
        }

        private string Loc = "";//全局变量，用于记录点击button的教室位置

        //楼层号 + 教室索引 生成教室编号
        private string class_room(string floor, string digit)
        {
            string classroom = "A-" + floor + digit;
            return classroom;
        }

        //选择楼层信息，如未选择return false
        private bool judge()
        {
            if (comboBox2.Text == "")
            {
                return false;
            }
            return true;
        }

        //搜索课程，跳转至教室所在位置
        private void showPos(string pos, int mod)
        {
            if (mod == 1)
            {
                switch (pos)
                {
                    case "01":
                        button1.BackColor = Color.LightSkyBlue;
                        label5.BackColor = Color.Yellow;
                        break;
                    case "02":
                        button2.BackColor = Color.LightSkyBlue;
                        label5.BackColor = Color.Yellow;
                        break;
                    case "03":
                        button3.BackColor = Color.LightSkyBlue;
                        label5.BackColor = Color.Yellow;
                        break;
                    case "04":
                        button4.BackColor = Color.LightSkyBlue;
                        label5.BackColor = Color.Yellow;
                        break;
                    case "05":
                        button5.BackColor = Color.LightSkyBlue;
                        label5.BackColor = Color.Yellow;
                        break;
                    case "06":
                        button6.BackColor = Color.LightSkyBlue;
                        label5.BackColor = Color.Yellow;
                        break;
                    case "07":
                        button7.BackColor = Color.LightSkyBlue;
                        label5.BackColor = Color.Yellow;
                        break;
                    case "08":
                        button8.BackColor = Color.LightSkyBlue;
                        label5.BackColor = Color.Yellow;
                        break;
                    case "09":
                        button9.BackColor = Color.LightSkyBlue;
                        label5.BackColor = Color.Yellow;
                        break;
                    case "10":
                        button10.BackColor = Color.LightSkyBlue;
                        label5.BackColor = Color.Yellow;
                        break;
                    case "11":
                        button12.BackColor = Color.LightSkyBlue;
                        label5.BackColor = Color.Yellow;
                        break;
                    case "12":
                        button13.BackColor = Color.LightSkyBlue;
                        label5.BackColor = Color.Yellow;
                        break;
                    case "13":
                        button20.BackColor = Color.LightSkyBlue;
                        label5.BackColor = Color.Yellow;
                        break;
                    case "14":
                        button14.BackColor = Color.LightSkyBlue;
                        label5.BackColor = Color.Yellow;
                        break;
                    case "15":
                        button19.BackColor = Color.LightSkyBlue;
                        label5.BackColor = Color.Yellow;
                        break;
                    case "16":
                        button15.BackColor = Color.LightSkyBlue;
                        label5.BackColor = Color.Yellow;
                        break;
                    case "17":
                        button11.BackColor = Color.LightSkyBlue;
                        label5.BackColor = Color.Yellow;
                        break;
                    case "18":
                        button21.BackColor = Color.LightSkyBlue;
                        label5.BackColor = Color.Yellow;
                        break;
                }
            }
            if (mod == 0)
            {
                label5.BackColor = Color.Transparent;
                button1.BackColor = Color.Transparent;
                button2.BackColor = Color.Transparent;
                button3.BackColor = Color.Transparent;
                button4.BackColor = Color.Transparent;
                button5.BackColor = Color.Transparent;
                button6.BackColor = Color.Transparent;
                button7.BackColor = Color.Transparent;
                button8.BackColor = Color.Transparent;
                button9.BackColor = Color.Transparent;
                button10.BackColor = Color.Transparent;
                button12.BackColor = Color.Transparent;
                button13.BackColor = Color.Transparent;
                button20.BackColor = Color.Transparent;
                button14.BackColor = Color.Transparent;
                button19.BackColor = Color.Transparent;
                button15.BackColor = Color.Transparent;
                button11.BackColor = Color.Transparent;
                button21.BackColor = Color.Transparent;
                
            }
        }

        private void input_table(string classroom)
        {
            string sql = "select * from 学生可选课表 where 教室编号 ='" + classroom + "'";
            Door Sql = new Door();
            IDataReader dr = Sql.Reader(sql);
            while (dr.Read())
            {
                string a, b, c, d, e, f, g, h;
                a = dr["课程号"].ToString();
                b = dr["课程"].ToString();
                c = dr["课程"].ToString();
                d = dr["学分"].ToString();
                e = dr["上课时间"].ToString();
                f = dr["教室编号"].ToString();
                g = dr["授课老师"].ToString();
                h = dr["计划上限"].ToString();
                string[] str = { a, b, c, d, e, f, g, h };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        //========================================================================
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (judge())
            {
                string classroom = class_room(comboBox2.Text, button2.Text);
                input_table(classroom);
            }
            else
            {
                MessageBox.Show("楼层信息未输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Loc = button1.Text;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (judge())
            {
                string classroom = class_room(comboBox2.Text, button2.Text);
                input_table(classroom);
            }
            else
            {
                MessageBox.Show("楼层信息未输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Loc = button2.Text;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (judge())
            {
                string classroom = class_room(comboBox2.Text, button2.Text);
                input_table(classroom);
            }
            else
            {
                MessageBox.Show("楼层信息未输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Loc = button3.Text;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (judge())
            {
                string classroom = class_room(comboBox2.Text, button2.Text);
                input_table(classroom);
            }
            else
            {
                MessageBox.Show("楼层信息未输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Loc = button4.Text;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (judge())
            {
                string classroom = class_room(comboBox2.Text, button2.Text);
                input_table(classroom);
            }
            else
            {
                MessageBox.Show("楼层信息未输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Loc = button5.Text;
        }        
        
        private void button6_Click_1(object sender, EventArgs e)
        {
            if (judge())
            {
                string classroom = class_room(comboBox2.Text, button2.Text);
                input_table(classroom);
            }
            else
            {
                MessageBox.Show("楼层信息未输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Loc = button6.Text;
        }
        
        private void button7_Click_1(object sender, EventArgs e)
        {
            if (judge())
            {
                string classroom = class_room(comboBox2.Text, button2.Text);
                input_table(classroom);
            }
            else
            {
                MessageBox.Show("楼层信息未输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Loc = button7.Text;
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            if (judge())
            {
                string classroom = class_room(comboBox2.Text, button2.Text);
                input_table(classroom);
            }
            else
            {
                MessageBox.Show("楼层信息未输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Loc = button8.Text;
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            if (judge())
            {
                string classroom = class_room(comboBox2.Text, button2.Text);
                input_table(classroom);
            }
            else
            {
                MessageBox.Show("楼层信息未输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Loc = button9.Text;
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            if (judge())
            {
                string classroom = class_room(comboBox2.Text, button2.Text);
                input_table(classroom);
            }
            else
            {
                MessageBox.Show("楼层信息未输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Loc = button10.Text;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (judge())
            {
                string classroom = class_room(comboBox2.Text, button2.Text);
                input_table(classroom);
            }
            else
            {
                MessageBox.Show("楼层信息未输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Loc = button21.Text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (judge())
            {
                string classroom = class_room(comboBox2.Text, button2.Text);
                input_table(classroom);
            }
            else
            {
                MessageBox.Show("楼层信息未输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Loc = button12.Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (judge())
            {
                string classroom = class_room(comboBox2.Text, button2.Text);
                input_table(classroom);
            }
            else
            {
                MessageBox.Show("楼层信息未输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Loc = button13.Text;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (judge())
            {
                string classroom = class_room(comboBox2.Text, button2.Text);
                input_table(classroom);
            }
            else
            {
                MessageBox.Show("楼层信息未输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Loc = button14.Text;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (judge())
            {
                string classroom = class_room(comboBox2.Text, button2.Text);
                input_table(classroom);
            }
            else
            {
                MessageBox.Show("楼层信息未输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Loc = button15.Text;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (judge())
            {
                string classroom = class_room(comboBox2.Text, button2.Text);
                input_table(classroom);
            }
            else
            {
                MessageBox.Show("楼层信息未输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Loc = button19.Text;
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            if (judge())
            {
                string classroom = class_room(comboBox2.Text, button2.Text);
                input_table(classroom);
            }
            else
            {
                MessageBox.Show("楼层信息未输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Loc = button11.Text;
        }

        private void button21_Click_1(object sender, EventArgs e)
        {
            if (judge())
            {
                string classroom = class_room(comboBox2.Text, button2.Text);
                input_table(classroom);
            }
            else
            {
                MessageBox.Show("楼层信息未输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Loc = button21.Text;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (judge())
            {
                string classroom = class_room(comboBox2.Text, button2.Text);
                input_table(classroom);
            }
            else
            {
                MessageBox.Show("楼层信息未输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Loc = button20.Text;
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = null;
            comboBox1.Text = null;
            comboBox2.Text = null;
            comboBox3.Text = null;
            dataGridView1.Rows.Clear();
            showPos("", 0);

        }

        //先搜索是否已存在，再进行信息添加
        private void button16_Click(object sender, EventArgs e)
        {
            if (judge())
            {
                string classroom = class_room(comboBox2.Text, Loc);
                string sql_1 = "select *from 课程教室CC where 教室编号 ='" + class_room(comboBox2.Text, Loc) + "'";
                string sql_2 = "select *from 课程 where 课程号 ='" + textBox1.Text + "'";
                Door Sql = new Door();
                IDataReader dr_1 = Sql.Reader(sql_1);
                IDataReader dr_2 = Sql.Reader(sql_2);
                if (textBox1.Text == "")
                {
                    MessageBox.Show("课程号为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dr_1.Close();
                    dr_2.Close();
                    return;
                }
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("课程类型为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dr_1.Close();
                    dr_2.Close();
                    return;
                }
                if (comboBox3.Text == "")
                {
                    MessageBox.Show("教师为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dr_1.Close();
                    dr_2.Close();
                    return;
                }
                if (dr_1.Read())
                {
                    MessageBox.Show("此教室已被占用！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dr_1.Close();
                    dr_2.Close();
                    return;
                }
                if (dr_2.Read())
                {
                    MessageBox.Show("课程已录入，不能重复录入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dr_1.Close();
                    dr_2.Close();
                    return;
                }
                if (!dr_2.Read())
                {
                    //sql_1 = "use 大学生课程学习管理与成绩评价系统 select *from Classroom where crno='" + classroom + "'";
                    //IDataReader dr = Sql.Reader(sql_1);
                    //string limit = dr["contain"].ToString(); 
                    sql_2 = "insert into 课程 values('" + textBox1.Text + "',null,'" + comboBox1.Text + "',null,null,null" + ")";
                    string sql_3 = "insert into 课程教师TC values('"+ textBox1.Text + "','"+ comboBox3.Text +"') insert into 教室 values('"+ class_room(comboBox2.Text, Loc) + "',null,null,'公教一') insert into 课程教室CC values('" + textBox1.Text + "','" + class_room(comboBox2.Text, Loc)  + "')";
                    Sql.Excute(sql_2);
                    Sql.Excute(sql_3);
                }
                MessageBox.Show("增加信息成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dr_1.Close();
                dr_2.Close();
                return;
            }
            else
            {
                MessageBox.Show("楼层信息未输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button18_Click_1(object sender, EventArgs i)
        {
            if (textBox1.Text != "")
            {
                string a, b, c, d, e, f, g, h;
                string sql = "select * from 学生可选课表 where 课程号 ='" + textBox1.Text + "'";
                Door Sql = new Door();
                IDataReader dr = Sql.Reader(sql);
                dataGridView1.Rows.Clear();
                while (dr.Read())
                {
                    showPos("", 0);
                    a = dr["课程号"].ToString();
                    b = dr["课程"].ToString();
                    c = dr["课程类型"].ToString();
                    d = dr["学分"].ToString();
                    e = dr["上课时间"].ToString();
                    f = dr["教室编号"].ToString();
                    g = dr["授课老师"].ToString();
                    h = dr["计划上限"].ToString();
                    label5.Text = "当前层数：" + dr["教室编号"].ToString()[2] + "层";
                    label5.BackColor = Color.LightGreen;
                    string[] str = { a, b, c, d, e, f, g, h };
                    dataGridView1.Rows.Add(str);
                    f = f.Substring(3);//截取教室编号
                    showPos(f, 1);
                }
                 dr.Close();
            }
            else
            {
                MessageBox.Show("课程号为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
    /*            if (textBox1.Text != "")
            {
                string sql = "select * from 学生可选课表 where 课程号 ='" + textBox1.Text + "'";
                Door Sql = new Door();
                IDataReader dr = Sql.Reader(sql);
                while (dr.Read())
                {
                    string a, b, c, d, e, f, g, h;
                    a = dr["课程号"].ToString();
                    b = dr["课程"].ToString();
                    c = dr["课程"].ToString();
                    d = dr["学分"].ToString();
                    e = dr["上课时间"].ToString();
                    f = dr["教室编号"].ToString();
                    g = dr["授课教师"].ToString();
                    h = dr["计划上限"].ToString();
                    string[] str = { a, b, c, d, e, f, g, h };
                    dataGridView1.Rows.Add(str);
                }
                dr.Close();
            }
            else
            {
                MessageBox.Show("课程号为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    */
}
