using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;//返回封装数据类型
using System.Data.SqlClient;//

namespace testlog
{
    class Door
    {
        //封装数据库链接
        public SqlConnection Connection()
        {
            string str = "Data Source=LAPTOP-A3741T29;Initial Catalog=大学生课程学习管理与成绩评价系统ver2;Integrated Security=True;";
            SqlConnection sc = new SqlConnection(str);//建立连接对象
            sc.Open();//打开数据库链接
            return sc;//返回连接对象
        }

        //封装操作
        public SqlCommand Command(string sql)
        {
            SqlCommand sc = new SqlCommand(sql, Connection());//参数2：连接对象sc调用connection方法
            return sc;//返回操作对象
        }

        //=========================================================================
        //将Door类实例化后，传入sql语句，调用如下方法：
        //Command方法建立tempsc对象



        //返回delete upate insert操作影响的行数
        public int Excute(string sql)
        { 
            return Command(sql).ExecuteNonQuery(); 
        }

        //Reader数据对象，用于select，返回SqlDataReader对象select到的数据
        public SqlDataReader Reader(string sql)
        {
            return Command(sql).ExecuteReader();//生成读入数据集对象
        }

    }
}
