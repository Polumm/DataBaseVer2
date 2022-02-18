# 数据库与空间数据库课设-教务管理系统ver2

1、项目在Project-testlog\.sln（没错，一开始随手起的，后来发现不好改了）

2、不断完善中~

3、文档部分正在整理

## 核心梳理

### 1、关系模式的改进

缺陷：1.0版本以课程号为排课的主码，遂出现同课异号的情况。

需求：

- 课程号和课程名要一一对应 
- 课程和授课教师的关系为N:N
- 同一门课程同一个老师也可以有不同的教学班次
- 从学生的成绩出发不仅要能找到对应课程，还要找到的授课教师，教学班……

解决方案：

借助面向对象的思想，以**课程**为父类，派生出**教学班**

- **课程**与选修行为无关，是该门课程所有开设的教学班的高级抽象

- **教学班**通过课程代号继承了课程的属性，并因选修行为联系了诸多实体派生出了时间、空间、对象的属性。
- 课程以课程代号为主键，教学班以课程教学ID为主键，**课程学生SC表以课程教学ID为外键**

```
系(系编号, 系名, 系办公室电话, 学院) 																				 key:系编号
教师(教师编号, 姓名, 职称, 联系方式, 系编号) 															   key:教师编号
班(班级编号 ,系编号, 专业) 																								  key:班级编号
学生(学号, 姓名, 性别, 出生日期, 班级编号) 																	  key:学号
教室(教室编号, 楼层, 容纳人数, 空间位置)																		  key:教室编号
课程(课程代号, 课程名, 课程类型, 学分)																			   key:课程代号
教学班(课程教学ID, 上课时间, 教室编号, 教师编号, 计划上限, 已选人数, 课程代号) 	  key:课程教学ID
课程学生SC(学号, 课程教学ID, 成绩)																					key:(学号, 课程教学ID)
用户安全信息(用户名, 密码, 身份, 手机号码, 用户照片)														key:用户名
```

### 2、选课操作对象的明确（用户看到的表和用户操作的表）

- 选课界面的基础是**教学班**表，看到的是开设的教学班信息
- 个人课表和成绩管理的基础是**课程学生SC**，是相应选课记录的呈现

### 3、用户批量修改、保存与提交

- 保存和提交功能的区分

  数据集是用户与数据库的桥梁，保存是用户的修改存入数据集（缓冲区），而提交是数据集的修改写入数据库

DataGridView

- 利用适配器和数据集（DataSet）绑定：界面表格-数据集虚拟表-数据库实体表

dgv表格就是为了直观呈现查询结果，绑定后，绑定后增删改查都可以直接在表格上实现，增强了可视性和便利性

- 主码不明确的视图或多表连接的表和视图难以通过消解法进行增删改操作

  解决方法：适配器设置参数，指定Updatecommand的sql语句
  
  ```C#
  //快速绑定：
  //1、新建适配器
  adapterStu = new SqlDataAdapter(sql, conn);
  //2、新建数据集
  dsStu = new DataSet();
  //3、将数据注入数据集，建立StudentInfo虚拟表
  adapterStu.Fill(dsStu, "StudentInfo");
  //4、将数据集的虚拟表与dataGridView绑定
  dataGridView1.DataSource = dsStu.Tables["StudentInfo"];
  
  //1、指定UpdateCommand所执行的sql语句
  adapterStu.UpdateCommand = new SqlCommand("update 学生 set 姓名 = @姓名, 性别 = @性别, 出生日期 = @出生日期, 班级编号 = @班级编号 where 学号 = @学号");
  //2、传递参数
  adapterStu.UpdateCommand.Parameters.Add("@学号", SqlDbType.VarChar, 50, "学号");
  adapterStu.UpdateCommand.Parameters.Add("@姓名", SqlDbType.VarChar, 50, "姓名");
  adapterStu.UpdateCommand.Parameters.Add("@性别", SqlDbType.VarChar, 50, "性别");
  adapterStu.UpdateCommand.Parameters.Add("@出生日期", SqlDbType.VarChar, 50, "出生年月");
  adapterStu.UpdateCommand.Parameters.Add("@班级编号", SqlDbType.VarChar, 50, "班级");
  
  //
  SqlCommandBuilder builder = new SqlCommandBuilder(adapterStu);
  try
  {
    adapterStu.Update(dsStu.Tables["StudentInfo"]);
    MessageBox.Show("提交修改成功！");
    CancelAll();
  }
  catch(Exception ex)
  {
    MessageBox.Show(ex.ToString());
  }
  ```
  
  



### 4、更安全的行为、更健壮的程序

```c#
try
            {
                //如果是学生，跳转选课
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Choosebuttons")
                {
                    //获取课程代号
                    int CnoIndex = dataGridView1.Columns["Column2"].Index;
                    String Cno = dataGridView1.SelectedCells[CnoIndex].Value.ToString();
```

最好不要使用自动生成的数字索引，可能会发生变化。按自定义索引标识访问更加安全

### 5、已选课程颜色标识

![image-20220218120105260](https://cdn.jsdelivr.net/gh/Polumm/PicGoo/image-20220218120105260.png)

自定义索引标识已选课程，展示教学班信息时检查是否已选。若已选，设置背景色为浅蓝

### 6、地图交互功能的发扬光大

对象：学生、教室、管理员都要用频繁使用

行为：查询教学楼楼层排课情况，点击教室查看教室的占用情况，示意教学班的教室位置，点击教室展示信息引导排课……

详见演示



## 优化

### 1、学生、教师、管理员共同抽象为用户

​	用户安全信息一张表存储所有用户：用户名, 密码, 身份, 手机号码, 用户照片，简化登陆验证程序

### 2、提高登陆的安全性

- 输入明文，密码MD5加密后再存储 
- 登陆时需输入随机生成的验证码

### 3、丰富可选择的查询条件，并利用treeView多级筛选

​	查询学情或师生个人信息时，根据院、系、专业、行政班的分级特点，用treeView多级筛选，条理清晰

​	根据treeView选中节点的级次，生成相应参考范围的名次（班排、专排、系排……）

### 4、提高重用率

	- 将相关联的功能组合，不单独增设界面
	- 重载部分界面的构造函数和功能函数，不同角色调用同一个界面可以实现相近或完全不同的功能
	- 增删改查往往在同一个界面甚至在同一张表上实现，可视性和便利性都更强了

### 5、安全性检查

- catch增删改操作带来的的风险

  注意约束性错误，比如：删除一个老师，则他的教学班、（若没有录入成绩）SC表中的选课记录应一并删除（触发器实现）

  有些属性，比如专业，在行政班不变的时候就应当ReadOnly禁止修改；排课时教室可容纳人数不得小于教学班的计划上限

- 注意注意索引访问和自动生成索引的不安全性（绑定最好手动指定索引）

### 6、省去不必要的按钮和简化操作过程

- 但凡有对数据库的数据有所改动都会自动刷新，第一时间反应在表上
- DataGridViewButtonCell，把选课、退课、录入成绩、排教学班的按钮嵌入到表中，类似操作直接点击目标行中的按钮即可

### 7、学生成绩总表打印高度仿真

- 历来所修课程的成绩、学分、类型、绩点详尽展示
- 成绩单下方计算已修总学分，平均学分绩点，显示成绩单打印时间

## 反思

1、敏捷开发，不要被数据捆住手脚，快速迭代

2、如何构思
