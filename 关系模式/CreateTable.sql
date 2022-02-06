create table 系
(
系编号 varchar(30) primary key,
系名 varchar(40),
系办公室电话 varchar(50)
)

create table 教师
(
教师编号 varchar(20) primary key,
姓名 varchar(20),
职称 varchar(20),
联系方式 varchar(50),
系编号 varchar(30),
foreign key(系编号) references 系(系编号)
)

create table 班
(
班级编号 varchar(10) primary key,
系编号 varchar(30),
foreign key(系编号) references 系(系编号)
)

create table 学生
(
学号 varchar(20) primary key,
姓名 varchar(20),
性别 varchar(10),
出生日期 smalldatetime,
班级编号 varchar(10),
foreign key(班级编号) references 班(班级编号)
)

create table 教室
(
教室编号 varchar(10) primary key,
楼层 varchar(5),
容纳人数 tinyint,
空间位置 varchar(10)
)

create table 课程
(
课程号 varchar(20) primary key,
课程名 varchar(40),
课程类型 varchar(20) check(课程类型 in ('基础必修','专业必修','选修')),/*check属性约束，限定课程类型*/
学分 tinyint,
)

create table 课程学生SC
(
学号 varchar(20),
课程号 varchar(20),
成绩 float,
primary key(学号,课程号),
foreign key(学号) references 学生(学号),
foreign key(课程号) references 课程(课程号)
)

create table 课程教师TC
(
课程号 varchar(20),
教师编号 varchar(20),
上课时间 varchar(40),
计划上限 tinyint,
primary key(教师编号,课程号,上课时间),
foreign key(教师编号) references 教师(教师编号),
foreign key(课程号) references 课程(课程号)
)

create table 课程教室CC
(
课程号 varchar(20),
教室编号 varchar(10),
上课时间 varchar(40),
primary key(教室编号,课程号,上课时间),
foreign key(教室编号) references 教室(教室编号),
foreign key(课程号) references 课程(课程号)
)

create table 管理员密码表
(用户名 varchar(20) primary key,
 密码  varchar(max)
)

create table 教师密码表
(用户名 varchar(20) primary key,
 密码  varchar(max)
)

create table 学生密码表
(用户名 varchar(20) primary key,
 密码  varchar(max)
)