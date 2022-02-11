select * into 平均学分绩点 FROM
(
select top 100 percent 学生.学号,总学分,总绩点/总学分 平均学分绩点 
from 学生,(select 学号,Sum(学分) from 学生成绩评价表 group by 学号) as temporary1(学号,总学分),(select 学号,Sum(学分*绩点*权重) from 学生成绩评价表 group by 学号) as temporary2(学号,总绩点) 
where 学生.学号=temporary1.学号 and 学生.学号=temporary2.学号 
order by 平均学分绩点 desc
)as temp