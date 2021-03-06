USE [master]
GO
/****** Object:  Database [大学生课程学习管理与成绩评价系统ver2]    Script Date: 2022/2/19 11:18:22 ******/
CREATE DATABASE [大学生课程学习管理与成绩评价系统ver2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'大学生课程学习管理与成绩评价系统ver2', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\大学生课程学习管理与成绩评价系统ver2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'大学生课程学习管理与成绩评价系统ver2_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\大学生课程学习管理与成绩评价系统ver2_log.ldf' , SIZE = 139264KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [大学生课程学习管理与成绩评价系统ver2] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [大学生课程学习管理与成绩评价系统ver2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [大学生课程学习管理与成绩评价系统ver2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [大学生课程学习管理与成绩评价系统ver2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [大学生课程学习管理与成绩评价系统ver2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [大学生课程学习管理与成绩评价系统ver2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [大学生课程学习管理与成绩评价系统ver2] SET ARITHABORT OFF 
GO
ALTER DATABASE [大学生课程学习管理与成绩评价系统ver2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [大学生课程学习管理与成绩评价系统ver2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [大学生课程学习管理与成绩评价系统ver2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [大学生课程学习管理与成绩评价系统ver2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [大学生课程学习管理与成绩评价系统ver2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [大学生课程学习管理与成绩评价系统ver2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [大学生课程学习管理与成绩评价系统ver2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [大学生课程学习管理与成绩评价系统ver2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [大学生课程学习管理与成绩评价系统ver2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [大学生课程学习管理与成绩评价系统ver2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [大学生课程学习管理与成绩评价系统ver2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [大学生课程学习管理与成绩评价系统ver2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [大学生课程学习管理与成绩评价系统ver2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [大学生课程学习管理与成绩评价系统ver2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [大学生课程学习管理与成绩评价系统ver2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [大学生课程学习管理与成绩评价系统ver2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [大学生课程学习管理与成绩评价系统ver2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [大学生课程学习管理与成绩评价系统ver2] SET RECOVERY FULL 
GO
ALTER DATABASE [大学生课程学习管理与成绩评价系统ver2] SET  MULTI_USER 
GO
ALTER DATABASE [大学生课程学习管理与成绩评价系统ver2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [大学生课程学习管理与成绩评价系统ver2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [大学生课程学习管理与成绩评价系统ver2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [大学生课程学习管理与成绩评价系统ver2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [大学生课程学习管理与成绩评价系统ver2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [大学生课程学习管理与成绩评价系统ver2] SET QUERY_STORE = OFF
GO
USE [大学生课程学习管理与成绩评价系统ver2]
GO
/****** Object:  Table [dbo].[系]    Script Date: 2022/2/19 11:18:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[系](
	[系编号] [varchar](30) NOT NULL,
	[系名] [varchar](40) NULL,
	[系办公室电话] [varchar](50) NULL,
	[学院] [varchar](40) NULL,
PRIMARY KEY CLUSTERED 
(
	[系编号] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[班]    Script Date: 2022/2/19 11:18:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[班](
	[班级编号] [varchar](10) NOT NULL,
	[系编号] [varchar](30) NULL,
	[专业] [varchar](40) NULL,
PRIMARY KEY CLUSTERED 
(
	[班级编号] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[学生]    Script Date: 2022/2/19 11:18:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[学生](
	[学号] [varchar](20) NOT NULL,
	[姓名] [varchar](20) NULL,
	[性别] [varchar](10) NULL,
	[出生日期] [smalldatetime] NULL,
	[班级编号] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[学号] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[学生信息表]    Script Date: 2022/2/19 11:18:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[学生信息表](班级,学号,姓名,性别,出生年月,系,学院,专业)
as
select 学生.班级编号,学号,姓名,性别,出生日期,系名,学院,专业 
from 学生,班,系
where 学生.班级编号=班.班级编号 and 系.系编号=班.系编号
GO
/****** Object:  Table [dbo].[教师]    Script Date: 2022/2/19 11:18:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[教师](
	[教师编号] [varchar](20) NOT NULL,
	[姓名] [varchar](20) NULL,
	[职称] [varchar](20) NULL,
	[联系方式] [varchar](50) NULL,
	[系编号] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[教师编号] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[教师信息表]    Script Date: 2022/2/19 11:18:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*用于教师信息管理维护*/
create view [dbo].[教师信息表](姓名,教师编号,职称,联系方式,系,系编号, 学院)
as
select 姓名,教师编号,职称,联系方式,系名,系.系编号,学院
from 教师, 系
where 教师.系编号 = 系.系编号
GO
/****** Object:  Table [dbo].[教室]    Script Date: 2022/2/19 11:18:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[教室](
	[教室编号] [varchar](10) NOT NULL,
	[楼层] [varchar](5) NULL,
	[容纳人数] [tinyint] NULL,
	[空间位置] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[教室编号] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[课程]    Script Date: 2022/2/19 11:18:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[课程](
	[课程代号] [varchar](20) NOT NULL,
	[课程名] [varchar](40) NULL,
	[课程类型] [varchar](20) NULL,
	[学分] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[课程代号] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[教学班]    Script Date: 2022/2/19 11:18:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[教学班](
	[课程教学ID] [varchar](20) NOT NULL,
	[上课时间] [varchar](40) NULL,
	[教室编号] [varchar](10) NULL,
	[教师编号] [varchar](20) NULL,
	[计划上限] [tinyint] NULL,
	[已选人数] [tinyint] NULL,
	[课程代号] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[课程教学ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[学生可选课表]    Script Date: 2022/2/19 11:18:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*用于选课和教学任务查询，全校可见，基于教学班*/
create view [dbo].[学生可选课表](课程教学ID, 课程, 课程号, 课程类型, 学分, 教师编号,授课老师, 空间位置, 教室编号, 上课时间, 计划上限, 当前人数)
as
select 课程教学ID, 课程.课程名, 课程.课程代号, 课程类型 ,学分, 教师.教师编号, 教师.姓名, 空间位置, 教学班.教室编号, 上课时间, 教学班.计划上限, 教学班.已选人数
from 课程, 教师, 教室, 教学班
where 教学班.课程代号 = 课程.课程代号 and 教学班.教师编号 = 教师.教师编号 and 教学班.教室编号 = 教室.教室编号
GO
/****** Object:  Table [dbo].[课程学生SC]    Script Date: 2022/2/19 11:18:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[课程学生SC](
	[学号] [varchar](20) NOT NULL,
	[课程教学ID] [varchar](20) NOT NULL,
	[成绩] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[学号] ASC,
	[课程教学ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[学生当前选课情况]    Script Date: 2022/2/19 11:18:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*用于查看选课记录，部分可见部分隐藏，基于课程学生SC表*/
create view [dbo].[学生当前选课情况](课程教学ID, 学号, 课程, 课程号, 课程类型, 学分, 授课老师, 空间位置, 教室编号, 上课时间, 计划上限, 当前人数, 成绩)
as
select 教学班.课程教学ID, 学号, 课程.课程名, 课程.课程代号 ,课程类型, 学分, 教师.姓名, 空间位置, 教学班.教室编号, 上课时间, 教学班.计划上限, 教学班.已选人数, 成绩
from 课程, 教师, 教室, 教学班, 课程学生SC
where  教学班.课程教学ID = 课程学生SC.课程教学ID and 教学班.课程代号 = 课程.课程代号 and 教学班.教师编号 = 教师.教师编号 and 教学班.教室编号 = 教室.教室编号
GO
/****** Object:  Table [dbo].[绩点模型]    Script Date: 2022/2/19 11:18:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[绩点模型](
	[学号] [varchar](20) NOT NULL,
	[课程代号] [varchar](20) NOT NULL,
	[等级] [varchar](10) NULL,
	[绩点] [float] NULL,
	[权重] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[学号] ASC,
	[课程代号] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[学生成绩评价表]    Script Date: 2022/2/19 11:18:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*用于学生成绩总表打印*/
create view [dbo].[学生成绩评价表](学号,姓名,课程号,课程,学分,课程类型,成绩,等级,绩点,权重)
as
select 学生.学号,姓名,教学班.课程代号,课程.课程名,学分,课程类型,成绩,等级,绩点,权重
from 学生,课程,课程学生SC,绩点模型,教学班
where 课程学生SC.学号=学生.学号 and 课程学生SC.课程教学ID = 教学班.课程教学ID and 教学班.课程代号 = 课程.课程代号 and 课程学生SC.学号=绩点模型.学号 and 课程.课程代号 = 绩点模型.课程代号
GO
/****** Object:  View [dbo].[年级排名表]    Script Date: 2022/2/19 11:18:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*平均学分绩点的计算*/
create view [dbo].[年级排名表](学号,姓名,学院,专业,系,班级,已修学分,平均学分绩点)
as
select 学生.学号,姓名,学院,专业,系名,学生.班级编号,总学分,平均学分绩点 
from
学生, 班, 系,(select 学生.学号,总学分,总绩点/总学分 平均学分绩点 from 学生,(select 学号,Sum(学分) from 学生成绩评价表 group by 学号) as temporary1(学号,总学分),(select 学号,Sum(学分*绩点*权重) from 学生成绩评价表 group by 学号) as temporary2(学号,总绩点) where 学生.学号=temporary1.学号 and 学生.学号=temporary2.学号) as temporary3
where 学生.班级编号=班.班级编号 and 系.系编号=班.系编号 and 学生.学号 = temporary3.学号
GO
/****** Object:  Table [dbo].[用户安全信息]    Script Date: 2022/2/19 11:18:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[用户安全信息](
	[用户名] [varchar](20) NOT NULL,
	[密码] [varchar](max) NULL,
	[身份] [varchar](20) NULL,
	[手机号码] [varchar](11) NULL,
	[用户照片] [image] NULL,
PRIMARY KEY CLUSTERED 
(
	[用户名] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[班]  WITH CHECK ADD FOREIGN KEY([系编号])
REFERENCES [dbo].[系] ([系编号])
GO
ALTER TABLE [dbo].[绩点模型]  WITH CHECK ADD FOREIGN KEY([课程代号])
REFERENCES [dbo].[课程] ([课程代号])
GO
ALTER TABLE [dbo].[绩点模型]  WITH CHECK ADD FOREIGN KEY([学号])
REFERENCES [dbo].[学生] ([学号])
GO
ALTER TABLE [dbo].[教师]  WITH CHECK ADD FOREIGN KEY([系编号])
REFERENCES [dbo].[系] ([系编号])
GO
ALTER TABLE [dbo].[教学班]  WITH CHECK ADD FOREIGN KEY([教师编号])
REFERENCES [dbo].[教师] ([教师编号])
GO
ALTER TABLE [dbo].[教学班]  WITH CHECK ADD FOREIGN KEY([课程代号])
REFERENCES [dbo].[课程] ([课程代号])
GO
ALTER TABLE [dbo].[课程学生SC]  WITH CHECK ADD FOREIGN KEY([课程教学ID])
REFERENCES [dbo].[教学班] ([课程教学ID])
GO
ALTER TABLE [dbo].[课程学生SC]  WITH CHECK ADD FOREIGN KEY([学号])
REFERENCES [dbo].[学生] ([学号])
GO
ALTER TABLE [dbo].[学生]  WITH CHECK ADD FOREIGN KEY([班级编号])
REFERENCES [dbo].[班] ([班级编号])
GO
ALTER TABLE [dbo].[课程]  WITH CHECK ADD CHECK  (([课程类型]='选修' OR [课程类型]='专业必修' OR [课程类型]='基础必修'))
GO
USE [master]
GO
ALTER DATABASE [大学生课程学习管理与成绩评价系统ver2] SET  READ_WRITE 
GO
