using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace testlog
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new 管理员功能区界面("Admin"));
        }
    }
}



//登陆验证界面()
//new 管理员功能区界面("Admin")
//new 学生功能区界面("20201003150")
//new 教师功能区界面("liweifeng101")

//new Click学生信息管理()
//new 学生功能区界面("1")
//new Click教师信息管理()
//new 管理员功能区界面()
//Click学生成绩录入xxx
//new Click学生成绩录入xxx("liweifeng101")