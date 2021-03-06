USE [master]
GO
/****** Object:  Database [PMS]    Script Date: 29-11-2017 3:02:34 AM ******/
CREATE DATABASE [PMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PMS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\PMS.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PMS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\PMS_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PMS] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [PMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PMS] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [PMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PMS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PMS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PMS] SET  MULTI_USER 
GO
ALTER DATABASE [PMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PMS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [PMS]
GO
/****** Object:  Schema [PMS]    Script Date: 29-11-2017 3:02:35 AM ******/
CREATE SCHEMA [PMS]
GO
/****** Object:  Table [dbo].[AssignedPerson]    Script Date: 29-11-2017 3:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AssignedPerson](
	[iID] [int] IDENTITY(1,1) NOT NULL,
	[iProjectID] [int] NOT NULL,
	[vProjectName] [varchar](200) NOT NULL,
	[vAssignedPersonName] [varchar](100) NOT NULL,
	[vAssignedPersonDesignation] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AssignedPerson] PRIMARY KEY CLUSTERED 
(
	[iID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProjectInformation]    Script Date: 29-11-2017 3:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProjectInformation](
	[iID] [int] IDENTITY(1,1) NOT NULL,
	[vName] [varchar](200) NOT NULL,
	[vCodeName] [varchar](100) NOT NULL,
	[vDescription] [varchar](1000) NOT NULL,
	[dStartDate] [datetime] NOT NULL,
	[dEndDate] [datetime] NOT NULL,
	[iDurationInDays] [int] NOT NULL,
	[vFilesName] [varchar](max) NULL,
	[vStatus] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ProjectInformation] PRIMARY KEY CLUSTERED 
(
	[iID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 29-11-2017 3:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[iID] [int] IDENTITY(1,1) NOT NULL,
	[vName] [varchar](100) NOT NULL,
	[vEmail] [varchar](50) NOT NULL,
	[vPassword] [varchar](50) NOT NULL,
	[vStatus] [varchar](50) NOT NULL,
	[vDesignation] [varchar](100) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[iID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[AssignedPerson] ON 

INSERT [dbo].[AssignedPerson] ([iID], [iProjectID], [vProjectName], [vAssignedPersonName], [vAssignedPersonDesignation]) VALUES (1, 2, N'Inventory', N'Mr. ABC', N'Project Manager')
SET IDENTITY_INSERT [dbo].[AssignedPerson] OFF
SET IDENTITY_INSERT [dbo].[ProjectInformation] ON 

INSERT [dbo].[ProjectInformation] ([iID], [vName], [vCodeName], [vDescription], [dStartDate], [dEndDate], [iDurationInDays], [vFilesName], [vStatus]) VALUES (1, N'Payroll', N'Payroll', N'For Office', CAST(0x0000A83A00000000 AS DateTime), CAST(0x0000A84900000000 AS DateTime), 15, NULL, N'Not Started')
INSERT [dbo].[ProjectInformation] ([iID], [vName], [vCodeName], [vDescription], [dStartDate], [dEndDate], [iDurationInDays], [vFilesName], [vStatus]) VALUES (2, N'Inventory', N'Inventory', N'For Office', CAST(0x0000A81E00000000 AS DateTime), CAST(0x0000A85A00000000 AS DateTime), 60, N'EIL- Pay Slip October-17.xlsx', N'Started')
SET IDENTITY_INSERT [dbo].[ProjectInformation] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([iID], [vName], [vEmail], [vPassword], [vStatus], [vDesignation]) VALUES (1, N'Rana', N'rana09@gmail.com', N'rana09@gmail.com123', N'Active', N'IT-Admin')
INSERT [dbo].[User] ([iID], [vName], [vEmail], [vPassword], [vStatus], [vDesignation]) VALUES (2, N'Mr. ABC', N'abc@gmail.com', N'abc@gmail.com123', N'Active', N'Project Manager')
INSERT [dbo].[User] ([iID], [vName], [vEmail], [vPassword], [vStatus], [vDesignation]) VALUES (3, N'Mr.X', N'x@gmail.com', N'x@gmail.com123', N'Active', N'Team Lead')
SET IDENTITY_INSERT [dbo].[User] OFF
USE [master]
GO
ALTER DATABASE [PMS] SET  READ_WRITE 
GO
