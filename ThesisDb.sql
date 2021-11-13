USE [master]
GO
/****** Object:  Database [ThesisDb]    Script Date: 11/13/2021 6:48:02 PM ******/
CREATE DATABASE [ThesisDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ThesisDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.LOCAL\MSSQL\DATA\ThesisDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ThesisDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.LOCAL\MSSQL\DATA\ThesisDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ThesisDb] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ThesisDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ThesisDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ThesisDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ThesisDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ThesisDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ThesisDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [ThesisDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ThesisDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ThesisDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ThesisDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ThesisDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ThesisDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ThesisDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ThesisDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ThesisDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ThesisDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ThesisDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ThesisDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ThesisDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ThesisDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ThesisDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ThesisDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ThesisDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ThesisDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ThesisDb] SET  MULTI_USER 
GO
ALTER DATABASE [ThesisDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ThesisDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ThesisDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ThesisDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ThesisDb] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ThesisDb', N'ON'
GO
USE [ThesisDb]
GO
/****** Object:  Table [dbo].[DepartmentInfo]    Script Date: 11/13/2021 6:48:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepartmentInfo](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](max) NOT NULL,
	[InTime] [nvarchar](50) NULL,
 CONSTRAINT [PK_DepartmentInfo] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Documents]    Script Date: 11/13/2021 6:48:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documents](
	[DocId] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [nvarchar](50) NOT NULL,
	[MetricId] [nvarchar](max) NOT NULL,
	[TopicName] [nvarchar](max) NULL,
	[Attachment] [nvarchar](max) NULL,
	[Type] [nvarchar](50) NOT NULL,
	[UploadTime] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Documents] PRIMARY KEY CLUSTERED 
(
	[DocId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notice]    Script Date: 11/13/2021 6:48:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notice](
	[NoticeId] [nvarchar](50) NOT NULL,
	[Notice] [nvarchar](max) NOT NULL,
	[NoticeTime] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Notice] PRIMARY KEY CLUSTERED 
(
	[NoticeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registration]    Script Date: 11/13/2021 6:48:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registration](
	[RegistrationId] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[MobileNo] [nvarchar](max) NULL,
	[Gender] [nvarchar](50) NOT NULL,
	[Batch] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Picture] [nvarchar](max) NULL,
	[DepartmentId] [int] NOT NULL,
	[Designation] [nvarchar](max) NULL,
	[FreeScheduleFrom] [nvarchar](50) NULL,
	[FreeScheduleTo] [nvarchar](50) NULL,
	[IdNo] [nvarchar](50) NULL,
	[Preffer] [nvarchar](50) NULL,
	[Interest] [nvarchar](max) NULL,
	[Password] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
	[InTime] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[RegistrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Report]    Script Date: 11/13/2021 6:48:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Report](
	[ReportId] [nvarchar](50) NOT NULL,
	[SupervisorId] [nvarchar](50) NOT NULL,
	[StudentId] [nvarchar](50) NOT NULL,
	[Subject] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[FileName] [nvarchar](max) NULL,
	[Attachment] [nvarchar](max) NULL,
	[Status] [nvarchar](50) NOT NULL,
	[SendTime] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Report] PRIMARY KEY CLUSTERED 
(
	[ReportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReqSupervisor]    Script Date: 11/13/2021 6:48:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReqSupervisor](
	[ReqId] [nvarchar](50) NOT NULL,
	[SupervisorId] [nvarchar](50) NOT NULL,
	[StudentId] [nvarchar](50) NOT NULL,
	[Subject] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[FileName] [nvarchar](max) NULL,
	[Attachment] [nvarchar](max) NULL,
	[Status] [nvarchar](50) NOT NULL,
	[ReqTime] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ReqSupervisor] PRIMARY KEY CLUSTERED 
(
	[ReqId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resource]    Script Date: 11/13/2021 6:48:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resource](
	[ResourceId] [nvarchar](50) NOT NULL,
	[ResourceName] [nvarchar](max) NOT NULL,
	[Path] [nvarchar](max) NOT NULL,
	[InTime] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
 CONSTRAINT [PK_Resource] PRIMARY KEY CLUSTERED 
(
	[ResourceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DepartmentInfo] ON 

INSERT [dbo].[DepartmentInfo] ([DepartmentId], [DepartmentName], [InTime]) VALUES (1, N'CSE', N'24/01/2021_10:21:34')
SET IDENTITY_INSERT [dbo].[DepartmentInfo] OFF
SET IDENTITY_INSERT [dbo].[Documents] ON 

INSERT [dbo].[Documents] ([DocId], [StudentId], [MetricId], [TopicName], [Attachment], [Type], [UploadTime]) VALUES (3, N'1004', N'8219821', N'Xyz', N'/photos/6349521DemoSampleForms.zip', N'Proposal', N'11/11/2021_09:16:14')
SET IDENTITY_INSERT [dbo].[Documents] OFF
INSERT [dbo].[Notice] ([NoticeId], [Notice], [NoticeTime]) VALUES (N'1001', N'This is a test notice. Please ignore it.', N'11/11/2021_04:47:14')
INSERT [dbo].[Registration] ([RegistrationId], [Name], [Email], [MobileNo], [Gender], [Batch], [Type], [Picture], [DepartmentId], [Designation], [FreeScheduleFrom], [FreeScheduleTo], [IdNo], [Preffer], [Interest], [Password], [Status], [InTime]) VALUES (N'1001', N'Mr. Admin', N'admin@gmail.com', N'01911002233', N'Male', N'', N'Admin', N'/DashboardFile/avatar.svg', 0, N'', N'', N'', N'', N'', N'', N'123', N'A', N'11/11/2021_01:15 PM')
INSERT [dbo].[Registration] ([RegistrationId], [Name], [Email], [MobileNo], [Gender], [Batch], [Type], [Picture], [DepartmentId], [Designation], [FreeScheduleFrom], [FreeScheduleTo], [IdNo], [Preffer], [Interest], [Password], [Status], [InTime]) VALUES (N'1002', N'Hasan', N'hasan@gmail.com', N'01921091289', N'Male', N'', N'Coordinator', N'/photos/1002.png', 0, N'CSE Coordinator', N'', N'', N'192 098 894', N'Select', N'', N'123', N'A', N'11/11/2021_01:21:35')
INSERT [dbo].[Registration] ([RegistrationId], [Name], [Email], [MobileNo], [Gender], [Batch], [Type], [Picture], [DepartmentId], [Designation], [FreeScheduleFrom], [FreeScheduleTo], [IdNo], [Preffer], [Interest], [Password], [Status], [InTime]) VALUES (N'1003', N'Sakib Hossain', N'shfsakib@gmail.com', N'01928921244', N'Male', N'', N'Teacher', N'/DashboardFile/avatar.svg', 1, N'Sr. Lecturer', N'09:00', N'18:30', N'CSE 05 8921', N'Both', N'Image Processing', N'123', N'A', N'11/11/2021_01:24:38')
INSERT [dbo].[Registration] ([RegistrationId], [Name], [Email], [MobileNo], [Gender], [Batch], [Type], [Picture], [DepartmentId], [Designation], [FreeScheduleFrom], [FreeScheduleTo], [IdNo], [Preffer], [Interest], [Password], [Status], [InTime]) VALUES (N'1004', N'Sudipto Dhar', N'moderatetech17@gmail.com', N'01921891275', N'Male', N'42nd Batch', N'Student', N'/photos/1004.png', 1, N'', N'', N'', N'CSE 042 09658', N'Select', N'', N'123', N'A', N'11/11/2021_01:27:18')
INSERT [dbo].[Registration] ([RegistrationId], [Name], [Email], [MobileNo], [Gender], [Batch], [Type], [Picture], [DepartmentId], [Designation], [FreeScheduleFrom], [FreeScheduleTo], [IdNo], [Preffer], [Interest], [Password], [Status], [InTime]) VALUES (N'1005', N'Sudipto', N'sudipto@gmail.com', N'01982178912', N'Male', N'', N'Admin', N'/photos/1005.png', 0, N'', N'', N'', N'', N'', N'', N'123', N'A', N'11/11/2021_04:34:51')
INSERT [dbo].[Report] ([ReportId], [SupervisorId], [StudentId], [Subject], [Description], [FileName], [Attachment], [Status], [SendTime], [Type]) VALUES (N'1001', N'1003', N'1004', N'Thesis Management System', N'Test', N'DataFillingFinalSoft.zip', N'/photos/1001DataFillingFinalSoft.zip', N'A', N'11/11/2021_07:42:17', N'Report')
INSERT [dbo].[ReqSupervisor] ([ReqId], [SupervisorId], [StudentId], [Subject], [Description], [FileName], [Attachment], [Status], [ReqTime]) VALUES (N'1001', N'1003', N'1004', N'Thesis Management System', N'Sir I want make an web project based on our project or thesis management system for final year students', N'21DemoSampleForms.zip', N'/photos/100121DemoSampleForms.zip', N'A', N'11/11/2021_07:17:14')
INSERT [dbo].[Resource] ([ResourceId], [ResourceName], [Path], [InTime], [Type]) VALUES (N'1001', N'Test Video', N'/photos/1001Gig Video.mp4', N'11/11/2021_04:46:18', N'Video')
INSERT [dbo].[Resource] ([ResourceId], [ResourceName], [Path], [InTime], [Type]) VALUES (N'1002', N'Test File', N'/photos/100221DemoSampleForms.zip', N'11/11/2021_04:46:49', N'File')
USE [master]
GO
ALTER DATABASE [ThesisDb] SET  READ_WRITE 
GO
