USE [master]
GO
/****** Object:  Database [ThesisDb]    Script Date: 1/29/2021 10:56:28 PM ******/
CREATE DATABASE [ThesisDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ThesisDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.LOCAL\MSSQL\DATA\ThesisDb.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ThesisDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.LOCAL\MSSQL\DATA\ThesisDb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
USE [ThesisDb]
GO
/****** Object:  Table [dbo].[DepartmentInfo]    Script Date: 1/29/2021 10:56:31 PM ******/
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
/****** Object:  Table [dbo].[Registration]    Script Date: 1/29/2021 10:56:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registration](
	[RegistrationId] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[MobileNo] [nvarchar](50) NULL,
	[DOB] [nvarchar](50) NOT NULL,
	[Gender] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Picture] [nvarchar](max) NULL,
	[DepartmentId] [int] NOT NULL,
	[Designation] [nvarchar](max) NULL,
	[FreeScheduleFrom] [nvarchar](50) NULL,
	[FreeScheduleTo] [nvarchar](50) NULL,
	[IdNo] [nvarchar](50) NULL,
	[Preffer] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
	[InTime] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[RegistrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Report]    Script Date: 1/29/2021 10:56:32 PM ******/
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
	[Type] [nvarchar](50) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ReqSupervisor]    Script Date: 1/29/2021 10:56:32 PM ******/
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
SET IDENTITY_INSERT [dbo].[DepartmentInfo] ON 

INSERT [dbo].[DepartmentInfo] ([DepartmentId], [DepartmentName], [InTime]) VALUES (1, N'CSE', N'24/01/2021_10:21:34')
SET IDENTITY_INSERT [dbo].[DepartmentInfo] OFF
INSERT [dbo].[Registration] ([RegistrationId], [Name], [Email], [MobileNo], [DOB], [Gender], [Address], [Type], [Picture], [DepartmentId], [Designation], [FreeScheduleFrom], [FreeScheduleTo], [IdNo], [Preffer], [Password], [Status], [InTime]) VALUES (N'1001', N'Shf Sakib', N'shfsakib@gmail.com', N'01685685523', N'1996-08-02', N'Male', N'Ctg', N'Teacher', N'/photos/1001.png', 1, N'MSc. in CSE', N'20:00', N'22:00', N'CSE 001 06214', N'Project', N'1', N'A', N'25/01/2021_11:35:18')
INSERT [dbo].[Registration] ([RegistrationId], [Name], [Email], [MobileNo], [DOB], [Gender], [Address], [Type], [Picture], [DepartmentId], [Designation], [FreeScheduleFrom], [FreeScheduleTo], [IdNo], [Preffer], [Password], [Status], [InTime]) VALUES (N'1002', N'Tirtha Talukder', N'moderatetech17@gmail.com', N'01835000456', N'1995-08-09', N'Male', N'Ctg', N'Student', N'/photos/1002.png', 1, N'', N'', N'', N'CSE 006 05532', N'', N'1', N'A', N'25/01/2021_11:36:39')
INSERT [dbo].[Registration] ([RegistrationId], [Name], [Email], [MobileNo], [DOB], [Gender], [Address], [Type], [Picture], [DepartmentId], [Designation], [FreeScheduleFrom], [FreeScheduleTo], [IdNo], [Preffer], [Password], [Status], [InTime]) VALUES (N'1003', N'Jobairul Islam', N'jiraees@yahoo.com', N'01822001122', N'1996-10-19', N'Male', N'Ctg', N'Coordinator', N'/photos/1003.png', 0, N'BBA in Management', N'', N'', N'0854216', N'', N'1', N'A', N'25/01/2021_11:37:48')
INSERT [dbo].[Registration] ([RegistrationId], [Name], [Email], [MobileNo], [DOB], [Gender], [Address], [Type], [Picture], [DepartmentId], [Designation], [FreeScheduleFrom], [FreeScheduleTo], [IdNo], [Preffer], [Password], [Status], [InTime]) VALUES (N'1004', N'Hasan', N'hasan@gmail.com', N'01800445522', N'1994-01-01', N'Male', N'Ctg', N'Admin', N'/photos/1004.png', 0, N'', N'', N'', N'', N'', N'1', N'A', N'26/01/2021_09:03:37')
INSERT [dbo].[Report] ([ReportId], [SupervisorId], [StudentId], [Subject], [Description], [FileName], [Attachment], [Status], [SendTime], [Type]) VALUES (N'1001', N'1001', N'1002', N'First Phase', N'Please check the attachment', N'Everything-1.4.1.969.x86-Setup.exe', N'/photos/1001Everything-1.4.1.969.x86-Setup.exe', N'A', N'29/01/2021_03:24:17', N'Report')
INSERT [dbo].[Report] ([ReportId], [SupervisorId], [StudentId], [Subject], [Description], [FileName], [Attachment], [Status], [SendTime], [Type]) VALUES (N'1002', N'', N'1001', N'', N'', N'Home Contructor Finder App', N'/photos/1002IDM 6.35 build 3 incl Patch [CrackingPatching] - Fake Serial Fixed.zip', N'A', N'29/01/2021_08:29:30', N'Project')
INSERT [dbo].[ReqSupervisor] ([ReqId], [SupervisorId], [StudentId], [Subject], [Description], [FileName], [Attachment], [Status], [ReqTime]) VALUES (N'1001', N'1001', N'1002', N'Thesis Management System', N'Test', N'AnyDesk', N'/photos/1001AnyDesk.exe', N'A', N'27/01/2021_01:23:28')
USE [master]
GO
ALTER DATABASE [ThesisDb] SET  READ_WRITE 
GO
