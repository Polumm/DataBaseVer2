/*CreateTable*/
create table 系
(
系编号 varchar(30) primary key,
系名 varchar(40),
系办公室电话 varchar(50),
学院 varchar(40),
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
专业 varchar(40),
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
课程代号 varchar(20) primary key,
课程名 varchar(40),
课程类型 varchar(20) check(课程类型 in ('基础必修','专业必修','选修')),/*check属性约束，限定课程类型*/
学分 tinyint,
)

create table 教学班
(
课程教学ID varchar(20) primary key,
上课时间 varchar(40),
教室编号 varchar(10),
教师编号 varchar(20),
计划上限 tinyint,
已选人数 tinyint,
课程代号 varchar(20),
/*foreign key(教室编号) references 教室(教室编号),*/
foreign key(教师编号) references 教师(教师编号),
foreign key(课程代号) references 课程(课程代号)
)

create table 课程学生SC
(
学号 varchar(20),
课程教学ID varchar(20),
成绩 float,
primary key(学号,课程教学ID),
foreign key(学号) references 学生(学号),
foreign key(课程教学ID) references 教学班(课程教学ID)
)

create table 用户安全信息          
(	
用户名 varchar(20) PRIMARY KEY,                          
密码 varchar(max), 
身份 varchar(20),
手机号码 varchar(11),
用户照片 image
); 
