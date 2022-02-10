/*学生选课表的前置视图（必须先于学生选课表创建），与课程学生SC表的触发器紧密相关*/
create view 教学班当前选课情况(课程教学ID,上课时间,计划上限,当前人数)
as
select 课程教学ID,上课时间,计划上限,已选人数
from 排课表
/*连接课程表，取得计划上限*/

go
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
	select @计划上限=计划上限, @当前人数=当前人数 from 教学班当前选课情况 where 课程教学ID=@课程教学ID;
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
	if(@成绩_before is null)
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
	else
	begin
		rollback transaction
		if (update(成绩))
		begin
			print '已录入绩点，不可修改！'
		end
		else if(update(学号) or update(课程教学ID))
		begin
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