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

create table 排课表
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
foreign key(课程教学ID) references 排课表(课程教学ID)
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



/*==================================================================================================================================================================*/
/*CreateGPA_Model&Trigger*/
create table 绩点模型
(
学号 varchar(20),
课程代号 varchar(20),
等级 varchar(10),
绩点 float,
权重 float,
primary key(学号,课程代号),
foreign key(学号) references 学生(学号),
foreign key(课程代号) references 课程(课程代号)
)


go
create trigger insert_绩点
on 课程学生SC
after insert
as
begin
    declare @学号 varchar(20), @课程教学ID varchar(20), @课程代号 varchar(20), @计划上限 smallint, @当前人数 smallint, @成绩 smallint, @课程类型 varchar(20);
    select @学号=学号, @课程教学ID=课程教学ID, @成绩=成绩 from inserted;
	select @计划上限=计划上限, @当前人数=已选人数 from 排课表 where 课程教学ID=@课程教学ID;
	select @课程类型=课程类型,@课程代号=课程代号 from 课程 where 课程代号 = (select 课程代号 from 排课表 where 课程教学ID=@课程教学ID);
    if (@计划上限>=@当前人数)
	begin
		print '选课成功！';
		update 排课表 set 已选人数 = 已选人数+1 where 课程教学ID = @课程教学ID;
		if(@成绩=null)
		begin
			insert into 绩点模型(学号,课程代号)
			values(@学号,@课程代号)
		end
		else if(@成绩>=90 and @成绩<100)
		begin
			insert into 绩点模型(学号,课程代号,等级,绩点)
			values(@学号,@课程代号,'A',4.0)
		end
		else if(@成绩>=85 and @成绩<90)
		begin
			insert into 绩点模型(学号,课程代号,等级,绩点)
			values(@学号,@课程代号,'A-',3.7)
		end
		else if(@成绩>=82 and @成绩<85)
		begin
			insert into 绩点模型(学号,课程代号,等级,绩点)
			values(@学号,@课程代号,'B+',3.3)
		end
		else if(@成绩>=78 and @成绩<82)
		begin
			insert into 绩点模型(学号,课程代号,等级,绩点)
			values(@学号,@课程代号,'B',3.0)
		end
		else if(@成绩>=75 and @成绩<78)
		begin
			insert into 绩点模型(学号,课程代号,等级,绩点)
			values(@学号,@课程代号,'B-',2.7)
		end
		else if(@成绩>=71 and @成绩<75)
		begin
			insert into 绩点模型(学号,课程代号,等级,绩点)
			values(@学号,@课程代号,'C+',2.3)
		end
		else if(@成绩>=66 and @成绩<71)
		begin
			insert into 绩点模型(学号,课程代号,等级,绩点)
			values(@学号,@课程代号,'C',2.0)
		end
		else if(@成绩>=62 and @成绩<66)
		begin
			insert into 绩点模型(学号,课程代号,等级,绩点)
			values(@学号,@课程代号,'C-',1.7)
		end
		else if(@成绩>=60 and @成绩<62)
		begin
			insert into 绩点模型(学号,课程代号,等级,绩点)
			values(@学号,@课程代号,'D',1.3)
		end
		else if(@成绩<60)
		begin
			insert into 绩点模型(学号,课程代号,等级,绩点)
			values(@学号,@课程代号,'D-',1.0)
		end
		if(@课程类型='基础必修')
		begin
			update 绩点模型
			set 权重=1.2
			where 学号=@学号 and 课程代号=@课程代号
		end
		else if(@课程类型='专业必修')
		begin
			update 绩点模型
			set 权重=1.1
			where 学号=@学号 and 课程代号=@课程代号
		end
		else if(@课程类型='选修')
		begin
			update 绩点模型
			set 权重=1.0
			where 学号=@学号 and 课程代号=@课程代号
		end
	end
    else if(@计划上限<@当前人数)
	begin
		rollback transaction
		print '选课失败，课程已满！';
	end
end
go
create trigger update_绩点
on 课程学生SC
after update
as
begin
	declare @学号 varchar(20), @课程教学ID varchar(20), @课程代号 varchar(20), @成绩_before float, @成绩 float;
    select @学号=学号, @课程教学ID=课程教学ID from inserted;
	select @课程代号 = 课程代号 from 排课表 where 课程教学ID=@课程教学ID;
	select @成绩_before=成绩 from deleted;
	select @成绩=成绩 from inserted;
	begin
		if (update(成绩))
		begin
			print '绩点录入成功！';
			if(@成绩=null)
			begin
				update 绩点模型
				set 等级=null,绩点=null
				where 学号=@学号 and 课程代号=@课程代号
			end
			else if(@成绩>=90 and @成绩<100)
			begin
				update 绩点模型
				set 等级='A',绩点=4.0
				where 学号=@学号 and 课程代号=@课程代号
			end
			else if(@成绩>=85 and @成绩<90)
			begin
				update 绩点模型
				set 等级='A-',绩点=3.7
				where 学号=@学号 and 课程代号=@课程代号
			end
			else if(@成绩>=82 and @成绩<85)
			begin
				update 绩点模型
				set 等级='B+',绩点=3.3
				where 学号=@学号 and 课程代号=@课程代号
			end
			else if(@成绩>=78 and @成绩<82)
			begin
				update 绩点模型
				set 等级='B',绩点=3.0
				where 学号=@学号 and 课程代号=@课程代号
			end
			else if(@成绩>=75 and @成绩<78)
			begin
				update 绩点模型
				set 等级='B-',绩点=2.7
				where 学号=@学号 and 课程代号=@课程代号
			end
			else if(@成绩>=71 and @成绩<75)
			begin
				update 绩点模型
				set 等级='C+',绩点=2.3
				where 学号=@学号 and 课程代号=@课程代号
			end
			else if(@成绩>=66 and @成绩<71)
			begin
				update 绩点模型
				set 等级='C',绩点=2.0
				where 学号=@学号 and 课程代号=@课程代号
			end
			else if(@成绩>=62 and @成绩<66)
			begin
				update 绩点模型
				set 等级='C-',绩点=1.7
				where 学号=@学号 and 课程代号=@课程代号
			end
			else if(@成绩>=60 and @成绩<62)
			begin
				update 绩点模型
				set 等级='D',绩点=1.3
				where 学号=@学号 and 课程代号=@课程代号
			end
			else if(@成绩<60)
			begin
				update 绩点模型
				set 等级='D-',绩点=1.0
				where 学号=@学号 and 课程代号=@课程代号
			end
		end
		else if(update(学号) or update(课程教学ID))
		begin
			rollback transaction
			print '操作无效！';
		end
	end
end
go

create trigger delete_绩点
on 课程学生SC
after delete
as
begin
	declare @学号 varchar(20), @课程教学ID varchar(20),@课程代号 varchar(20),@成绩 smallint;
    select @学号=学号, @课程教学ID=课程教学ID, @成绩=成绩 from deleted;
	select @课程代号 = 课程代号 from 排课表 where 课程教学ID=@课程教学ID;
	if(@成绩 between 0 and 100)
	begin
		print '成绩已录入，操作无效！';
		rollback transaction
	end
	else
	begin
		delete
		from 绩点模型
		where 学号=@学号 and 课程代号 = @课程代号
		update 排课表 set 已选人数 = 已选人数-1 where 课程教学ID = @课程教学ID;
	end
end
go



/*==================================================================================================================================================================*/
/*AddDataFlow*/
insert into 系
values('081201,081202,081205T','测绘系','027-67883725','地理与信息工程学院')
insert into 系
values('070501,070504','地理系','027-67883725','地理与信息工程学院')
insert into 系
values('080902','软件工程系','027-67883725','地理与信息工程学院')
insert into 系
values('070101','应用数学系','027-67883091','数理学院')
insert into 系
values('030503','思想政治教育','027-67848620','马克思主义学院')
insert into 系
values('070901','地质系','027-67883001','地球科学学院')
insert into 系
values('050201','英语系','027-67883262','外国语学院')
insert into 系
values('070201','物理系','027-67883091','数理学院')
insert into 系
values('020101','经济系','027-67883209','经管学院')



insert into 班
values('11C201','081201,081202,081205T','测绘科学与技术')
insert into 班
values('11C202','081201,081202,081205T','遥感科学与技术')
insert into 班
values('11C203','081201,081202,081205T','地理空间信息工程')
insert into 班
values('11D201','070501,070504','地理科学')
insert into 班
values('11D202','070501,070504','地理信息科学')
insert into 班
values('11D203','070501,070504','地理信息科学')
insert into 班
values('11J201','080902','软件工程')
insert into 班
values('11J202','080902','软件工程')



insert into 教室
values('A-104','一层',60,'公教一')
insert into 教室
values('A-105','一层',60,'公教一')
insert into 教室
values('A-109','一层',80,'公教一')
insert into 教室
values('A-111','一层',120,'公教一')
insert into 教室
values('A-201','二层',50,'公教一')
insert into 教室
values('A-202','二层',50,'公教一')
insert into 教室
values('A-203','二层',50,'公教一')
insert into 教室
values('A-212','二层',90,'公教一')
insert into 教室
values('A-214','二层',90,'公教一')
insert into 教室
values('A-310','三层',150,'公教一')
insert into 教室
values('A-406','四层',120,'公教一')
insert into 教室
values('A-509','五层',120,'公教一')



insert into 教师
values('qikunlun0630','祁昆仑','副教授','qikunlun@cug.edu.cn','070501,070504')
insert into 教师
values('wanglunche13','王伦澈','教授','wang@cug.edu.cn','070501,070504')
insert into 教师
values('liuxiuguo225','刘修国','教授','liuxg318@163.com','081201,081202,081205T')
insert into 教师
values('chaoyi010701','晁怡','副教授','chaoyi@cug.edu.cn','070501,070504')
insert into 教师
values('guanqinfeng1','关庆锋','教授','guanqf@cug.edu.cn','070501,070504')
insert into 教师
values('liujianyu106','刘剑宇','副教授','liujy@cug.edu.cn','070501,070504')
insert into 教师
values('yaoyao180305','姚尧','副教授','yaoy@cug.edu.cn','080902')
insert into 教师
values('songxiaoqing','宋小青','副教授','sonniasxq@163.com','070501,070504')
insert into 教师
values('qinyangmin07','秦养民','副教授','qinyangmin2005@163.com','070501,070504')
insert into 教师
values('huaweihua601','花卫华','副教授','huaweihua@cug.edu.cn','080902')
insert into 教师
values('gongjunfang1','龚君芳','副教授','jfgong@cug.edu.cn','080902')
insert into 教师
values('lvjianjun007','吕建军','教授',' jjlv@cug.edu.cn','070501,070504')
insert into 教师
values('panxiong0029','潘雄','教授','pxjlh@163.com','081201,081202,081205T')
insert into 教师
values('lihui9790314','李辉','副教授','leelmars@gmail.com','070501,070504')
insert into 教师
values('guomingqiang','郭明强','副教授','8156485@qq.com','070501,070504')
insert into 教师
values('huhuaimin214','胡怀敏','副教授','huaimin_hu@cug.edu.cn.com','020101')
insert into 教师
values('liangyueling','梁玥琳','副教授','liangyueling@gmail.com','020101')
insert into 教师
values('lijiangmin98','李江敏','副教授','ljm1437@163.com','020101')
insert into 教师
values('wenhui721206','文辉','讲师','wenhui@cug.edu.cn.com','030503')
insert into 教师
values('luwenzhong01','卢文忠','教授','luwenzhong@cug.edu.cn.com','030503')
insert into 教师
values('wuguobin7372','吴国斌','副教授','wuguobin@cug.edu.cn.com','030503')
insert into 教师
values('guoguanyu747','郭关玉','副教授','guoguanyu@cug.edu.cn.com','030503')
insert into 教师
values('zguangyong09','张光勇','教授','zhgyong@163.com','070201')
insert into 教师
values('hekaihua9809','何开华','教授','khhe@cug.edu.cn','070201')
insert into 教师
values('liweifeng101','李卫峰','讲师','liweifeng@cug.edu.cn','070101')
insert into 教师
values('xiaohaijun65','肖海军','教授','xiaohaijun@cug.edu.cn','070101')
insert into 教师
values('hupeng110709','胡鹏','副教授','hupeng@cug.edu.cn','070101')
insert into 教师
values('zhaoyingke97','赵英科','副教授','zykbox@cug.edu.cn','050201')
insert into 教师
values('zhouliehong9','周烈红','副教授','dzhyzhlh@163.com','050201')
insert into 教师
values('wangguonian8','王国念','副教授','BobbyWang@cug.edu.cn','050201')
insert into 教师
values('fanruoying11','范若颖','副教授','fanruoying@cug.edu.cn','070901')




insert into 学生
values('1','tester2','男','2002.06.25','11D203')
insert into 学生
values('20201000830','tester','男','2002.06.25','11D203')
insert into 学生
values('20201003150','许涵','女','2002.10.14','11C201')
insert into 学生 
values('20201003381','邓睿','女','2002.10.6','11C201')
insert into 学生
values('20201000193','孙文锦','男','2001.2.18','11C201')
insert into 学生
values('20201000398','韩雪婷','女','2001.8.26','11C202')
insert into 学生
values('20201000503','邓启阳','男','2002.8.19','11C202')
insert into 学生
values('20201000746','邬宇航','男','2002.2.5','11C202')
insert into 学生
values('20201000872','秦伟杰','男','2001.10.15','11C202')
insert into 学生
values('20201001016','李玮璨','男','2002.1.23','11C203')
insert into 学生
values('20201001143','贾改虹','女','2002.5.18','11C203')
insert into 学生
values('20201001211','刘文鹏','男','2001.9.22','11C203')
insert into 学生
values('20201001219','徐鸣远','女','2002.4.11','11D203')
insert into 学生
values('20201001379','姜帆','女','2002.8.27','11D203')
insert into 学生
values('20201001567','王倩','男','2001.11.22','11D203')
insert into 学生
values('20201001705','李仲丹','男','2002.5.15','11D203')
insert into 学生
values('20201001735','朱文琪','女','2002.9.23','11D203')
insert into 学生
values('20201001902','王冰瑶','女','2002.3.7','11D203')
insert into 学生
values('20201002137','季玉轩','男','2001.10.7','11D201')
insert into 学生
values('20201002276','祁晓鹏','男','2001.10.10','11D201')
insert into 学生
values('20201002743','黄胤赫','男','2002.11.21','11D201')
insert into 学生
values('20201002920','余平平','女','2002.1.23','11D201')
insert into 学生
values('20201003024','施梦妍','女','2001.6.26','11D201')
insert into 学生
values('20201003038','赵凡翔','男','2002.2.11','11D202')
insert into 学生
values('20201003217','杨梓萌','女','2002.9.9','11D202')
insert into 学生
values('20201003752','熊万诚','男','2001.12.25','11D202')
insert into 学生
values('20201003578','刘洋','男','2002.7.19','11D202')
insert into 学生
values('20201003559','罗艺昕','女','2002.1.24','11D202')
insert into 学生
values('20201004101','王学亮','男','2002.4.26','11J201')
insert into 学生
values('20201004321','范修远','男','2002.3.14','11J201')
insert into 学生
values('20201004492','梁雨','男','2001.3.18','11J202')
insert into 学生
values('20201002343','李哲','男','2001.3.3','11J202')
insert into 学生
values('20201000910','姚阔','男','2001.7.17','11J202')



insert into 课程
values('2121271','高等数学A','基础必修',6)
insert into 课程
values('2121280','线性代数A','基础必修',4)
insert into 课程
values('2121301','大学物理C','基础必修',3)
insert into 课程
values('2011960','普通地质学','基础必修',3)
insert into 课程
values('1200520','思想道德修养与法律基础','基础必修',3)
insert into 课程
values('1170620','马克思主义基本原理概论','基础必修',3)
insert into 课程
values('1092341','大学英语','基础必修',3)
insert into 课程
values('8spoc00','文化遗产与自然遗产','选修',2)
insert into 课程
values('9spoc00','英语语音','选修',2)
insert into 课程
values('7080060','经济学导论','选修',2)
insert into 课程
values('7040060','生态学概论','选修',2)
insert into 课程
values('2193110','计算机高级语言程序设计（C++）','专业必修',3)
insert into 课程
values('2113060','自然地理学','专业必修',2)
insert into 课程
values('2010560','人文地理学','专业必修',2)
insert into 课程
values('2171760','地理学导论','专业必修',1)
insert into 课程
values('2113070','地理信息系统原理A','专业必修',3)
insert into 课程
values('2113040','计算科学基础','专业必修',2)



insert into 排课表
values('21212711', '周一1-2节','A-406','liweifeng101',120,0, '2121271')
insert into 排课表
values('21212712', '周一3-4节','A-509','xiaohaijun65',120,0, '2121271')
insert into 排课表
values('21212801', '周一3-4节','A-212','liweifeng101',70,0, '2121280')
insert into 排课表
values('21212802', '周一3-4节','A-214','hupeng110709',70,0, '2121280')
insert into 排课表
values('21213013', '周一5-6节','A-212','zguangyong09',80,0, '2121301')
insert into 排课表
values('21213023', '周一5-6节','A-214','hekaihua9809',80,0, '2121301')
insert into 排课表
values('20119600', '周一7-8节','A-104','fanruoying11',30,0, '2011960')
insert into 排课表
values('12005200', '周一9-10节','A-111','wuguobin7372',100,0, '1200520')
insert into 排课表
values('12005201', '周一9-10节','A-406','guoguanyu747',100,0, '1200520')
insert into 排课表
values('11706200', '周二1-2节','A-111','wenhui721206',90,0, '1170620')
insert into 排课表
values('11706201', '周二1-2节','A-509','luwenzhong01',90,0, '1170620')
insert into 排课表
values('10923410', '周二3-4节','A-310','zhaoyingke97',110,0, '1092341')
insert into 排课表
values('10923420', '周二3-4节','A-406','zhouliehong9',110,0, '1092341')
insert into 排课表
values('10923430', '周二3-4节','A-509','wangguonian8',110,0, '1092341')
insert into 排课表
values('8spoc001', '周二5-6节','A-104','lijiangmin98',60,0, '8spoc00')
insert into 排课表
values('8spoc002', '周二5-6节','A-105','liangyueling',60,0, '8spoc00')
insert into 排课表
values('8spoc005', '周二7-8节','A-109','wangguonian8',50,0, '9spoc00')
insert into 排课表
values('70800600', '周二7-8节','A-310','huhuaimin214',150,0, '7080060')
insert into 排课表
values('70400600', '周二9-10节','A-310','qinyangmin07',100,0, '7040060')
insert into 排课表
values('21931100', '周三1-2节','A-104','qikunlun0630',50,0, '2193110')
insert into 排课表
values('21931110', '周三3-4节','A-105','guomingqiang',50,0, '2193110')
insert into 排课表
values('41931200', '周三5-8节','A-201','liuxiuguo225',30,0, '2193110')
insert into 排课表
values('41931210', '周三5-8节','A-202','panxiong0029',30,0, '2193110')
insert into 排课表
values('41931220', '周三5-8节','A-203','yaoyao180305',30,0, '2193110')
insert into 排课表
values('41931230', '周三9-12节','A-104','songxiaoqing',30,0, '2193110')
insert into 排课表
values('41931240', '周三9-12节','A-105','huaweihua601',30,0, '2193110')
insert into 排课表
values('21130600', '周四1-2节','A-109','lihui9790314',60,0, '2113060')
insert into 排课表
values('21130700', '周四1-2节','A-212','liujianyu106',60,0, '2113060')
insert into 排课表
values('21130800', '周四1-2节','A-214','lvjianjun007',60,0, '2113060')
insert into 排课表
values('20105600', '周四3-4节','A-212','songxiaoqing',60,0, '2010560')
insert into 排课表
values('20105700', '周四3-4节','A-214','guanqinfeng1',60,0, '2010560')
insert into 排课表
values('21717600', '周四3-4节','A-310','wanglunche13',150,0, '2171760')
insert into 排课表
values('21130701', '周四5-8节','A-201','gongjunfang1',30,0, '2113070')
insert into 排课表
values('21130702', '周五1-4节','A-202','chaoyi010701',30,0, '2113070')
insert into 排课表
values('21130703', '周五1-4节','A-203','yaoyao180305',30,0, '2113070')
insert into 排课表
values('21130400', '周五5-8节','A-109','qikunlun0630',70,0, '2113040')
insert into 排课表
values('21130500', '周五5-8节','A-111','huaweihua601',90,0, '2113040')



insert into 课程学生SC
values('1','21212711',null)
insert into 课程学生SC
values('20201000830','21212712',90)
insert into 课程学生SC
values('20201003150','21212712',90)
insert into 课程学生SC
values('20201003150','21212802',89)
insert into 课程学生SC
values('20201003150','21213023',81)
insert into 课程学生SC
values('20201003150','20119600',78)
insert into 课程学生SC
values('20201003150','12005200',77)
insert into 课程学生SC
values('20201003150','11706201',97)
insert into 课程学生SC
values('20201003150','10923430',92)
insert into 课程学生SC
values('20201003150','70400600',91)
insert into 课程学生SC
values('20201003150','41931240',73)
insert into 课程学生SC
values('20201003150','21130800',61)
insert into 课程学生SC
values('20201003150','21717600',69)
insert into 课程学生SC
values('20201003150','21130500',97)

insert into 课程学生SC
values('20201003381','21212712',89)
insert into 课程学生SC
values('20201003381','21212802',93)
insert into 课程学生SC
values('20201003381','21213023',94)
insert into 课程学生SC
values('20201003381','20119600',90)
insert into 课程学生SC
values('20201003381','12005200',90)
insert into 课程学生SC
values('20201003381','11706201',93)
insert into 课程学生SC
values('20201003381','10923430',82)
insert into 课程学生SC
values('20201003381','70400600',81)
insert into 课程学生SC
values('20201003381','21931100',87)
insert into 课程学生SC
values('20201003381','21130800',83)
insert into 课程学生SC
values('20201003381','21717600',90)
insert into 课程学生SC
values('20201003381','21130500',78)

insert into 课程学生SC
values('20201000193','21212712',78)
insert into 课程学生SC
values('20201000193','21212802',77)
insert into 课程学生SC
values('20201000193','21213023',90)
insert into 课程学生SC
values('20201000193','20119600',89)
insert into 课程学生SC
values('20201000193','12005200',76)
insert into 课程学生SC
values('20201000193','11706201',78)
insert into 课程学生SC
values('20201000193','10923430',84)
insert into 课程学生SC
values('20201000193','70400600',69)
insert into 课程学生SC
values('20201000193','41931240',74)
insert into 课程学生SC
values('20201000193','21130800',85)
insert into 课程学生SC
values('20201000193','21717600',87)
insert into 课程学生SC
values('20201000193','21130500',90)

insert into 课程学生SC
values('20201000398','21212712',78)
insert into 课程学生SC
values('20201000398','21212802',72)
insert into 课程学生SC
values('20201000398','21213023',73)
insert into 课程学生SC
values('20201000398','20119600',90)
insert into 课程学生SC
values('20201000398','12005200',80)
insert into 课程学生SC
values('20201000398','11706201',90)
insert into 课程学生SC
values('20201000398','10923430',92)
insert into 课程学生SC
values('20201000398','70400600',85)
insert into 课程学生SC
values('20201000398','21931100',82)
insert into 课程学生SC
values('20201000398','21130800',75)
insert into 课程学生SC
values('20201000398','21717600',81)
insert into 课程学生SC
values('20201000398','21130500',85)

insert into 课程学生SC
values('20201000503','21212712',90)
insert into 课程学生SC
values('20201000503','21212802',78)
insert into 课程学生SC
values('20201000503','21213023',79)
insert into 课程学生SC
values('20201000503','20119600',90)
insert into 课程学生SC
values('20201000503','12005200',99)
insert into 课程学生SC
values('20201000503','11706201',83)
insert into 课程学生SC
values('20201000503','10923430',78)
insert into 课程学生SC
values('20201000503','70400600',76)
insert into 课程学生SC
values('20201000503','21931100',76)
insert into 课程学生SC
values('20201000503','21130800',82)
insert into 课程学生SC
values('20201000503','21717600',81)
insert into 课程学生SC
values('20201000503','21130500',83)

insert into 课程学生SC
values('20201000746','21212712',90)
insert into 课程学生SC
values('20201000746','21212802',92)
insert into 课程学生SC
values('20201000746','21213023',91)
insert into 课程学生SC
values('20201000746','20119600',93)
insert into 课程学生SC
values('20201000746','12005200',83)
insert into 课程学生SC
values('20201000746','11706201',89)
insert into 课程学生SC
values('20201000746','10923430',94)
insert into 课程学生SC
values('20201000746','70400600',91)
insert into 课程学生SC
values('20201000746','21931100',87)
insert into 课程学生SC
values('20201000746','21130800',91)
insert into 课程学生SC
values('20201000746','21717600',77)
insert into 课程学生SC
values('20201000746','21130500',90)

insert into 课程学生SC
values('20201000872','21212712',89)
insert into 课程学生SC
values('20201000872','21212802',88)
insert into 课程学生SC
values('20201000872','21213023',89)
insert into 课程学生SC
values('20201000872','20119600',90)
insert into 课程学生SC
values('20201000872','12005200',90)
insert into 课程学生SC
values('20201000872','11706201',88)
insert into 课程学生SC
values('20201000872','10923430',83)
insert into 课程学生SC
values('20201000872','70400600',85)
insert into 课程学生SC
values('20201000872','21931100',87)
insert into 课程学生SC
values('20201000872','21130800',87)
insert into 课程学生SC
values('20201000872','21717600',90)
insert into 课程学生SC
values('20201000872','21130500',81)

insert into 课程学生SC
values('20201001016','21212712',63)
insert into 课程学生SC
values('20201001016','21212802',78)
insert into 课程学生SC
values('20201001016','21213023',90)
insert into 课程学生SC
values('20201001016','20119600',87)
insert into 课程学生SC
values('20201001016','12005200',83)
insert into 课程学生SC
values('20201001016','11706201',78)
insert into 课程学生SC
values('20201001016','10923430',90)
insert into 课程学生SC
values('20201001016','70400600',76)
insert into 课程学生SC
values('20201001016','21931100',65)
insert into 课程学生SC
values('20201001016','21130800',74)
insert into 课程学生SC
values('20201001016','21717600',69)
insert into 课程学生SC
values('20201001016','21130500',68)

insert into 课程学生SC
values('20201001143','21212712',92)
insert into 课程学生SC
values('20201001143','21212802',87)
insert into 课程学生SC
values('20201001143','21213023',93)
insert into 课程学生SC
values('20201001143','20119600',83)
insert into 课程学生SC
values('20201001143','12005200',84)
insert into 课程学生SC
values('20201001143','11706201',78)
insert into 课程学生SC
values('20201001143','10923430',76)
insert into 课程学生SC
values('20201001143','70400600',78)
insert into 课程学生SC
values('20201001143','21931100',90)
insert into 课程学生SC
values('20201001143','21130800',98)
insert into 课程学生SC
values('20201001143','21717600',93)
insert into 课程学生SC
values('20201001143','21130500',90)

insert into 课程学生SC
values('20201001211','21212712',90)
insert into 课程学生SC
values('20201001211','21212802',89)
insert into 课程学生SC
values('20201001211','21213023',88)
insert into 课程学生SC
values('20201001211','20119600',83)
insert into 课程学生SC
values('20201001211','12005200',85)
insert into 课程学生SC
values('20201001211','11706201',87)
insert into 课程学生SC
values('20201001211','10923430',78)
insert into 课程学生SC
values('20201001211','70400600',79)
insert into 课程学生SC
values('20201001211','21931100',73)
insert into 课程学生SC
values('20201001211','21130800',89)
insert into 课程学生SC
values('20201001211','21717600',90)
insert into 课程学生SC
values('20201001211','21130500',95)

insert into 课程学生SC
values('20201001219','21212711',79)
insert into 课程学生SC
values('20201001219','21212801',89)
insert into 课程学生SC
values('20201001219','21213013',87)
insert into 课程学生SC
values('20201001219','20119600',90)
insert into 课程学生SC
values('20201001219','12005200',79)
insert into 课程学生SC
values('20201001219','11706200',67)
insert into 课程学生SC
values('20201001219','10923410',78)
insert into 课程学生SC
values('20201001219','70400600',79)
insert into 课程学生SC
values('20201001219','21931100',90)
insert into 课程学生SC
values('20201001219','21130600',84)
insert into 课程学生SC
values('20201001219','20105600',83)
insert into 课程学生SC
values('20201001219','21717600',73)
insert into 课程学生SC
values('20201001219','21130701',74)
insert into 课程学生SC
values('20201001219','21130400',78)

insert into 课程学生SC
values('20201001379','21212711',78)
insert into 课程学生SC
values('20201001379','21212801',69)
insert into 课程学生SC
values('20201001379','21213013',60)
insert into 课程学生SC
values('20201001379','20119600',90)
insert into 课程学生SC
values('20201001379','12005200',97)
insert into 课程学生SC
values('20201001379','11706200',90)
insert into 课程学生SC
values('20201001379','10923410',76)
insert into 课程学生SC
values('20201001379','70400600',67)
insert into 课程学生SC
values('20201001379','41931220',64)
insert into 课程学生SC
values('20201001379','21130600',74)
insert into 课程学生SC
values('20201001379','20105600',79)
insert into 课程学生SC
values('20201001379','21717600',78)
insert into 课程学生SC
values('20201001379','21130701',75)
insert into 课程学生SC
values('20201001379','21130400',70)

insert into 课程学生SC
values('20201001567','21212711',90)
insert into 课程学生SC
values('20201001567','21212801',87)
insert into 课程学生SC
values('20201001567','21213013',67)
insert into 课程学生SC
values('20201001567','20119600',76)
insert into 课程学生SC
values('20201001567','12005200',89)
insert into 课程学生SC
values('20201001567','11706200',82)
insert into 课程学生SC
values('20201001567','10923410',87)
insert into 课程学生SC
values('20201001567','70400600',85)
insert into 课程学生SC
values('20201001567','41931220',89)
insert into 课程学生SC
values('20201001567','21130600',77)
insert into 课程学生SC
values('20201001567','20105600',74)
insert into 课程学生SC
values('20201001567','21717600',84)
insert into 课程学生SC
values('20201001567','21130701',83)
insert into 课程学生SC
values('20201001567','21130400',73)

insert into 课程学生SC
values('20201001705','21212711',78)
insert into 课程学生SC
values('20201001705','21212801',90)
insert into 课程学生SC
values('20201001705','21213013',92)
insert into 课程学生SC
values('20201001705','20119600',89)
insert into 课程学生SC
values('20201001705','12005200',90)
insert into 课程学生SC
values('20201001705','11706200',83)
insert into 课程学生SC
values('20201001705','10923410',78)
insert into 课程学生SC
values('20201001705','70400600',62)
insert into 课程学生SC
values('20201001705','41931220',65)
insert into 课程学生SC
values('20201001705','21130600',92)
insert into 课程学生SC
values('20201001705','20105600',88)
insert into 课程学生SC
values('20201001705','21717600',87)
insert into 课程学生SC
values('20201001705','21130701',82)
insert into 课程学生SC
values('20201001705','21130400',79)

insert into 课程学生SC
values('20201001735','21212711',88)
insert into 课程学生SC
values('20201001735','21212801',91)
insert into 课程学生SC
values('20201001735','21213013',65)
insert into 课程学生SC
values('20201001735','20119600',60)
insert into 课程学生SC
values('20201001735','12005200',80)
insert into 课程学生SC
values('20201001735','11706200',88)
insert into 课程学生SC
values('20201001735','10923410',99)
insert into 课程学生SC
values('20201001735','70400600',93)
insert into 课程学生SC
values('20201001735','41931220',93)
insert into 课程学生SC
values('20201001735','21130600',98)
insert into 课程学生SC
values('20201001735','20105600',78)
insert into 课程学生SC
values('20201001735','21717600',72)
insert into 课程学生SC
values('20201001735','21130701',81)
insert into 课程学生SC
values('20201001735','21130400',83)

insert into 课程学生SC
values('20201001902','21212711',85)
insert into 课程学生SC
values('20201001902','21212801',80)
insert into 课程学生SC
values('20201001902','21213013',85)
insert into 课程学生SC
values('20201001902','20119600',78)
insert into 课程学生SC
values('20201001902','12005200',75)
insert into 课程学生SC
values('20201001902','11706200',73)
insert into 课程学生SC
values('20201001902','10923410',71)
insert into 课程学生SC
values('20201001902','70400600',65)
insert into 课程学生SC
values('20201001902','41931220',67)
insert into 课程学生SC
values('20201001902','21130600',69)
insert into 课程学生SC
values('20201001902','20105600',99)
insert into 课程学生SC
values('20201001902','21717600',91)
insert into 课程学生SC
values('20201001902','21130701',89)
insert into 课程学生SC
values('20201001902','21130400',88)

insert into 课程学生SC
values('20201002137','21212711',81)
insert into 课程学生SC
values('20201002137','21212801',78)
insert into 课程学生SC
values('20201002137','21213013',90)
insert into 课程学生SC
values('20201002137','20119600',88)
insert into 课程学生SC
values('20201002137','12005200',79)
insert into 课程学生SC
values('20201002137','11706200',67)
insert into 课程学生SC
values('20201002137','10923410',78)
insert into 课程学生SC
values('20201002137','70400600',90)
insert into 课程学生SC
values('20201002137','41931220',98)
insert into 课程学生SC
values('20201002137','21130600',81)
insert into 课程学生SC
values('20201002137','20105600',85)
insert into 课程学生SC
values('20201002137','21717600',78)
insert into 课程学生SC
values('20201002137','21130701',79)
insert into 课程学生SC
values('20201002137','21130400',75)

insert into 课程学生SC
values('20201002276','21212711',90)
insert into 课程学生SC
values('20201002276','21212801',78)
insert into 课程学生SC
values('20201002276','21213013',99)
insert into 课程学生SC
values('20201002276','20119600',78)
insert into 课程学生SC
values('20201002276','12005200',76)
insert into 课程学生SC
values('20201002276','11706200',69)
insert into 课程学生SC
values('20201002276','10923410',88)
insert into 课程学生SC
values('20201002276','70400600',86)
insert into 课程学生SC
values('20201002276','41931220',82)
insert into 课程学生SC
values('20201002276','21130600',67)
insert into 课程学生SC
values('20201002276','20105600',69)
insert into 课程学生SC
values('20201002276','21717600',72)
insert into 课程学生SC
values('20201002276','21130701',76)
insert into 课程学生SC
values('20201002276','21130400',81)

insert into 课程学生SC
values('20201002743','21212711',88)
insert into 课程学生SC
values('20201002743','21212801',83)
insert into 课程学生SC
values('20201002743','21213013',78)
insert into 课程学生SC
values('20201002743','20119600',90)
insert into 课程学生SC
values('20201002743','12005200',92)
insert into 课程学生SC
values('20201002743','11706200',78)
insert into 课程学生SC
values('20201002743','10923410',77)
insert into 课程学生SC
values('20201002743','70400600',76)
insert into 课程学生SC
values('20201002743','41931220',98)
insert into 课程学生SC
values('20201002743','21130600',69)
insert into 课程学生SC
values('20201002743','20105600',81)
insert into 课程学生SC
values('20201002743','21717600',84)
insert into 课程学生SC
values('20201002743','21130701',89)
insert into 课程学生SC
values('20201002743','21130400',89)

insert into 课程学生SC
values('20201002920','21212711',90)
insert into 课程学生SC
values('20201002920','21212801',88)
insert into 课程学生SC
values('20201002920','21213013',78)
insert into 课程学生SC
values('20201002920','20119600',99)
insert into 课程学生SC
values('20201002920','12005200',73)
insert into 课程学生SC
values('20201002920','11706200',78)
insert into 课程学生SC
values('20201002920','10923410',89)
insert into 课程学生SC
values('20201002920','70400600',67)
insert into 课程学生SC
values('20201002920','21931100',90)
insert into 课程学生SC
values('20201002920','21130600',92)
insert into 课程学生SC
values('20201002920','20105600',87)
insert into 课程学生SC
values('20201002920','21717600',82)
insert into 课程学生SC
values('20201002920','21130701',81)
insert into 课程学生SC
values('20201002920','21130400',87)

insert into 课程学生SC
values('20201003024','21212711',90)
insert into 课程学生SC
values('20201003024','21212801',91)
insert into 课程学生SC
values('20201003024','21213013',90)
insert into 课程学生SC
values('20201003024','20119600',90)
insert into 课程学生SC
values('20201003024','12005200',100)
insert into 课程学生SC
values('20201003024','11706200',99)
insert into 课程学生SC
values('20201003024','10923410',90)
insert into 课程学生SC
values('20201003024','70400600',89)
insert into 课程学生SC
values('20201003024','21931100',90)
insert into 课程学生SC
values('20201003024','21130600',94)
insert into 课程学生SC
values('20201003024','20105600',89)
insert into 课程学生SC
values('20201003024','21717600',88)
insert into 课程学生SC
values('20201003024','21130701',99)
insert into 课程学生SC
values('20201003024','21130400',90)

insert into 课程学生SC
values('20201003038','21212711',67)
insert into 课程学生SC
values('20201003038','21212801',65)
insert into 课程学生SC
values('20201003038','21213013',67)
insert into 课程学生SC
values('20201003038','20119600',78)
insert into 课程学生SC
values('20201003038','12005200',79)
insert into 课程学生SC
values('20201003038','11706200',89)
insert into 课程学生SC
values('20201003038','10923410',90)
insert into 课程学生SC
values('20201003038','70400600',81)
insert into 课程学生SC
values('20201003038','41931210',69)
insert into 课程学生SC
values('20201003038','21130700',90)
insert into 课程学生SC
values('20201003038','20105700',88)
insert into 课程学生SC
values('20201003038','21717600',78)
insert into 课程学生SC
values('20201003038','21130702',67)
insert into 课程学生SC
values('20201003038','21130400',89)

insert into 课程学生SC
values('20201003217','21212711',91)
insert into 课程学生SC
values('20201003217','21212801',90)
insert into 课程学生SC
values('20201003217','21213013',79)
insert into 课程学生SC
values('20201003217','20119600',76)
insert into 课程学生SC
values('20201003217','12005200',87)
insert into 课程学生SC
values('20201003217','11706200',83)
insert into 课程学生SC
values('20201003217','10923410',90)
insert into 课程学生SC
values('20201003217','70400600',71)
insert into 课程学生SC
values('20201003217','21931110',90)
insert into 课程学生SC
values('20201003217','21130700',93)
insert into 课程学生SC
values('20201003217','20105700',96)
insert into 课程学生SC
values('20201003217','21717600',84)
insert into 课程学生SC
values('20201003217','21130702',81)
insert into 课程学生SC
values('20201003217','21130400',83)

insert into 课程学生SC
values('20201003752','21212711',89)
insert into 课程学生SC
values('20201003752','21212801',87)
insert into 课程学生SC
values('20201003752','21213013',93)
insert into 课程学生SC
values('20201003752','20119600',78)
insert into 课程学生SC
values('20201003752','12005200',77)
insert into 课程学生SC
values('20201003752','11706200',80)
insert into 课程学生SC
values('20201003752','10923410',85)
insert into 课程学生SC
values('20201003752','70400600',88)
insert into 课程学生SC
values('20201003752','21931110',91)
insert into 课程学生SC
values('20201003752','21130700',89)
insert into 课程学生SC
values('20201003752','20105700',84)
insert into 课程学生SC
values('20201003752','21717600',90)
insert into 课程学生SC
values('20201003752','21130702',96)
insert into 课程学生SC
values('20201003752','21130400',95)

insert into 课程学生SC
values('20201003578','21212711',98)
insert into 课程学生SC
values('20201003578','21212801',97)
insert into 课程学生SC
values('20201003578','21213013',88)
insert into 课程学生SC
values('20201003578','20119600',83)
insert into 课程学生SC
values('20201003578','12005200',82)
insert into 课程学生SC
values('20201003578','11706200',90)
insert into 课程学生SC
values('20201003578','10923410',90)
insert into 课程学生SC
values('20201003578','70400600',91)
insert into 课程学生SC
values('20201003578','21931110',90)
insert into 课程学生SC
values('20201003578','21130700',89)
insert into 课程学生SC
values('20201003578','20105700',97)
insert into 课程学生SC
values('20201003578','21717600',91)
insert into 课程学生SC
values('20201003578','21130702',89)
insert into 课程学生SC
values('20201003578','21130400',90)

insert into 课程学生SC
values('20201003559','21212711',98)
insert into 课程学生SC
values('20201003559','21212801',87)
insert into 课程学生SC
values('20201003559','21213013',82)
insert into 课程学生SC
values('20201003559','20119600',89)
insert into 课程学生SC
values('20201003559','12005200',90)
insert into 课程学生SC
values('20201003559','11706200',60)
insert into 课程学生SC
values('20201003559','10923410',80)
insert into 课程学生SC
values('20201003559','70400600',87)
insert into 课程学生SC
values('20201003559','41931210',72)
insert into 课程学生SC
values('20201003559','21130700',73)
insert into 课程学生SC
values('20201003559','20105700',74)
insert into 课程学生SC
values('20201003559','21717600',78)
insert into 课程学生SC
values('20201003559','21130702',88)
insert into 课程学生SC
values('20201003559','21130400',90)

insert into 课程学生SC
values('20201004101','21212712',90)
insert into 课程学生SC
values('20201004101','21212802',99)
insert into 课程学生SC
values('20201004101','21213023',76)
insert into 课程学生SC
values('20201004101','12005201',79)
insert into 课程学生SC
values('20201004101','11706200',88)
insert into 课程学生SC
values('20201004101','10923420',89)
insert into 课程学生SC
values('20201004101','70400600',90)
insert into 课程学生SC
values('20201004101','41931230',81)
insert into 课程学生SC
values('20201004101','21717600',73)
insert into 课程学生SC
values('20201004101','21130703',72)
insert into 课程学生SC
values('20201004101','21130500',77)

insert into 课程学生SC
values('20201004321','21212712',87)
insert into 课程学生SC
values('20201004321','21212802',78)
insert into 课程学生SC
values('20201004321','21213023',90)
insert into 课程学生SC
values('20201004321','12005201',84)
insert into 课程学生SC
values('20201004321','11706200',83)
insert into 课程学生SC
values('20201004321','10923420',86)
insert into 课程学生SC
values('20201004321','70400600',97)
insert into 课程学生SC
values('20201004321','41931230',90)
insert into 课程学生SC
values('20201004321','21717600',69)
insert into 课程学生SC
values('20201004321','21130703',75)
insert into 课程学生SC
values('20201004321','21130500',79)

insert into 课程学生SC
values('20201004492','21212712',90)
insert into 课程学生SC
values('20201004492','21212802',89)
insert into 课程学生SC
values('20201004492','21213023',88)
insert into 课程学生SC
values('20201004492','12005201',81)
insert into 课程学生SC
values('20201004492','11706200',95)
insert into 课程学生SC
values('20201004492','10923420',94)
insert into 课程学生SC
values('20201004492','70400600',90)
insert into 课程学生SC
values('20201004492','21931110',92)
insert into 课程学生SC
values('20201004492','21717600',78)
insert into 课程学生SC
values('20201004492','21130703',79)
insert into 课程学生SC
values('20201004492','21130500',85)

insert into 课程学生SC
values('20201002343','21212712',78)
insert into 课程学生SC
values('20201002343','21212802',82)
insert into 课程学生SC
values('20201002343','21213023',85)
insert into 课程学生SC
values('20201002343','12005201',67)
insert into 课程学生SC
values('20201002343','11706200',76)
insert into 课程学生SC
values('20201002343','10923420',92)
insert into 课程学生SC
values('20201002343','70400600',90)
insert into 课程学生SC
values('20201002343','41931200',92)
insert into 课程学生SC
values('20201002343','21717600',97)
insert into 课程学生SC
values('20201002343','21130703',88)
insert into 课程学生SC
values('20201002343','21130500',84)

insert into 课程学生SC
values('20201000910','21212712',65)
insert into 课程学生SC
values('20201000910','21212802',79)
insert into 课程学生SC
values('20201000910','21213023',87)
insert into 课程学生SC
values('20201000910','12005201',92)
insert into 课程学生SC
values('20201000910','11706200',93)
insert into 课程学生SC
values('20201000910','10923420',79)
insert into 课程学生SC
values('20201000910','70400600',89)
insert into 课程学生SC
values('20201000910','21931110',73)
insert into 课程学生SC
values('20201000910','21717600',76)
insert into 课程学生SC
values('20201000910','21130703',79)
insert into 课程学生SC
values('20201000910','21130500',63)

insert into 课程学生SC
values('20201002743','8spoc002',91)
insert into 课程学生SC
values('20201002743','8spoc005',90)
insert into 课程学生SC
values('20201002743','70800600',93)
insert into 课程学生SC
values('20201003038','8spoc001',98)
insert into 课程学生SC
values('20201003038','8spoc005',100)
insert into 课程学生SC
values('20201003038','70800600',95)
insert into 课程学生SC
values('20201001016','8spoc001',88)
insert into 课程学生SC
values('20201001016','8spoc005',97)
insert into 课程学生SC
values('20201001016','70800600',96)
insert into 课程学生SC
values('20201001567','8spoc002',90)
insert into 课程学生SC
values('20201001567','8spoc005',87)
insert into 课程学生SC
values('20201001567','70800600',82)



/*GRANT*/
insert into 管理员密码表
values('Admin','e10adc3949ba59abbe56e057f20f883e')

insert into 学生密码表
values('20201003150','e10adc3949ba59abbe56e057f20f883e')
insert into 学生密码表 
values('20201003381','e10adc3949ba59abbe56e057f20f883e')
insert into 学生密码表
values('20201000193','e10adc3949ba59abbe56e057f20f883e')
insert into 学生密码表
values('20201000398','e10adc3949ba59abbe56e057f20f883e')
insert into 学生密码表
values('20201000503','e10adc3949ba59abbe56e057f20f883e')
insert into 学生密码表
values('20201000746','e10adc3949ba59abbe56e057f20f883e')
insert into 学生密码表
values('20201000872','e10adc3949ba59abbe56e057f20f883e')
insert into 学生密码表
values('20201001016','e10adc3949ba59abbe56e057f20f883e')
insert into 学生密码表
values('20201001143','e10adc3949ba59abbe56e057f20f883e')
insert into 学生密码表
values('20201001211','e10adc3949ba59abbe56e057f20f883e')
insert into 学生密码表
values('20201001219','e10adc3949ba59abbe56e057f20f883e')
insert into 学生密码表
values('20201001379','e10adc3949ba59abbe56e057f20f883e')
insert into 学生密码表
values('20201001567','e10adc3949ba59abbe56e057f20f883e')
insert into 学生密码表
values('20201001705','e10adc3949ba59abbe56e057f20f883e')
insert into 学生密码表
values('20201001735','e10adc3949ba59abbe56e057f20f883e')
insert into 学生密码表
values('20201001902','e10adc3949ba59abbe56e057f20f883e')
insert into 学生密码表
values('20201002137','e10adc3949ba59abbe56e057f20f883e')
insert into 学生密码表
values('20201002276','e10adc3949ba59abbe56e057f20f883e')
insert into 学生密码表
values('20201002743','e10adc3949ba59abbe56e057f20f883e')
insert into 学生密码表
values('20201002920','e10adc3949ba59abbe56e057f20f883e')
insert into 学生密码表
values('20201003024','e10adc3949ba59abbe56e057f20f883e')
insert into 学生密码表
values('20201003038','e10adc3949ba59abbe56e057f20f883e')
insert into 学生密码表
values('20201003217','e10adc3949ba59abbe56e057f20f883e')
insert into 学生密码表
values('20201003752','e10adc3949ba59abbe56e057f20f883e')
insert into 学生密码表
values('20201003578','e10adc3949ba59abbe56e057f20f883e')
insert into 学生密码表
values('20201003559','e10adc3949ba59abbe56e057f20f883e')
insert into 学生密码表
values('20201004101','e10adc3949ba59abbe56e057f20f883e')
insert into 学生密码表
values('20201004321','e10adc3949ba59abbe56e057f20f883e')
insert into 学生密码表
values('20201004492','e10adc3949ba59abbe56e057f20f883e')
insert into 学生密码表
values('20201002343','e10adc3949ba59abbe56e057f20f883e')
insert into 学生密码表
values('20201000910','e10adc3949ba59abbe56e057f20f883e')
insert into 学生密码表
values('20201000830','e10adc3949ba59abbe56e057f20f883e')

insert into 教师密码表
values('qikunlun0630','e10adc3949ba59abbe56e057f20f883e')
insert into 教师密码表
values('wanglunche13','e10adc3949ba59abbe56e057f20f883e')
insert into 教师密码表
values('liuxiuguo225','e10adc3949ba59abbe56e057f20f883e')
insert into 教师密码表
values('chaoyi010701','e10adc3949ba59abbe56e057f20f883e')
insert into 教师密码表
values('guanqinfeng1','e10adc3949ba59abbe56e057f20f883e')
insert into 教师密码表
values('liujianyu106','e10adc3949ba59abbe56e057f20f883e')
insert into 教师密码表
values('yaoyao180305','e10adc3949ba59abbe56e057f20f883e')
insert into 教师密码表
values('songxiaoqing','e10adc3949ba59abbe56e057f20f883e')
insert into 教师密码表
values('qinyangmin07','e10adc3949ba59abbe56e057f20f883e')
insert into 教师密码表
values('huaweihua601','e10adc3949ba59abbe56e057f20f883e')
insert into 教师密码表
values('gongjunfang1','e10adc3949ba59abbe56e057f20f883e')
insert into 教师密码表
values('lvjianjun007','e10adc3949ba59abbe56e057f20f883e')
insert into 教师密码表
values('panxiong0029','e10adc3949ba59abbe56e057f20f883e')
insert into 教师密码表
values('lihui9790314','e10adc3949ba59abbe56e057f20f883e')
insert into 教师密码表
values('guomingqiang','e10adc3949ba59abbe56e057f20f883e')
insert into 教师密码表
values('huhuaimin214','e10adc3949ba59abbe56e057f20f883e')
insert into 教师密码表
values('liangyueling','e10adc3949ba59abbe56e057f20f883e')
insert into 教师密码表
values('lijiangmin98','e10adc3949ba59abbe56e057f20f883e')
insert into 教师密码表
values('wenhui721206','e10adc3949ba59abbe56e057f20f883e')
insert into 教师密码表
values('luwenzhong01','e10adc3949ba59abbe56e057f20f883e')
insert into 教师密码表
values('wuguobin7372','e10adc3949ba59abbe56e057f20f883e')
insert into 教师密码表
values('guoguanyu747','e10adc3949ba59abbe56e057f20f883e')
insert into 教师密码表
values('zguangyong09','e10adc3949ba59abbe56e057f20f883e')
insert into 教师密码表
values('hekaihua9809','e10adc3949ba59abbe56e057f20f883e')
insert into 教师密码表
values('liweifeng101','e10adc3949ba59abbe56e057f20f883e')
insert into 教师密码表
values('xiaohaijun65','e10adc3949ba59abbe56e057f20f883e')
insert into 教师密码表
values('hupeng110709','e10adc3949ba59abbe56e057f20f883e')
insert into 教师密码表
values('zhaoyingke97','e10adc3949ba59abbe56e057f20f883e')
insert into 教师密码表
values('zhouliehong9','e10adc3949ba59abbe56e057f20f883e')
insert into 教师密码表
values('wangguonian8','e10adc3949ba59abbe56e057f20f883e')
insert into 教师密码表
values('fanruoying11','e10adc3949ba59abbe56e057f20f883e')