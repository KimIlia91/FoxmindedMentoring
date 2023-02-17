USE [master]
GO
/****** Object:  Database [HogwartsDB]    Script Date: �� 29.09.22 20:34:44 ******/
CREATE DATABASE [HogwartsDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HogwartsDB', FILENAME = N'D:\DATABASE\HogwartsDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HogwartsDB_log', FILENAME = N'D:\DATABASE\HogwartsDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HogwartsDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HogwartsDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HogwartsDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HogwartsDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HogwartsDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HogwartsDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HogwartsDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [HogwartsDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HogwartsDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HogwartsDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HogwartsDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HogwartsDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HogwartsDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HogwartsDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HogwartsDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HogwartsDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HogwartsDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HogwartsDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HogwartsDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HogwartsDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HogwartsDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HogwartsDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HogwartsDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HogwartsDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HogwartsDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HogwartsDB] SET  MULTI_USER 
GO
ALTER DATABASE [HogwartsDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HogwartsDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HogwartsDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HogwartsDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HogwartsDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HogwartsDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [HogwartsDB] SET QUERY_STORE = OFF
GO
USE [HogwartsDB]
GO
/****** Object:  Table [dbo].[COURSES]    Script Date: �� 29.09.22 20:34:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COURSES](
	[COURSE_ID] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [nvarchar](20) NOT NULL,
	[DESCRIPTION] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_COURSES] PRIMARY KEY CLUSTERED 
(
	[COURSE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GROUPS]    Script Date: �� 29.09.22 20:34:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GROUPS](
	[GROUP_ID] [int] IDENTITY(1,1) NOT NULL,
	[COURSE_ID] [int] NOT NULL,
	[NAME] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_GROUPS] PRIMARY KEY CLUSTERED 
(
	[GROUP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[STUDENTS]    Script Date: �� 29.09.22 20:34:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STUDENTS](
	[STUDENT_ID] [int] IDENTITY(1,1) NOT NULL,
	[GROUP_ID] [int] NOT NULL,
	[FIRST_NAME] [nvarchar](20) NOT NULL,
	[LAST_NAME] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_STUDENTS] PRIMARY KEY CLUSTERED 
(
	[STUDENT_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[GROUPS] ADD  CONSTRAINT [DF_GROUPS_COURSE_ID]  DEFAULT ((1)) FOR [COURSE_ID]
GO
ALTER TABLE [dbo].[STUDENTS] ADD  CONSTRAINT [DF_STUDENTS_GROUP_ID]  DEFAULT ((1)) FOR [GROUP_ID]
GO
ALTER TABLE [dbo].[GROUPS]  WITH CHECK ADD  CONSTRAINT [FK_GROUPS_ID_COURSES] FOREIGN KEY([COURSE_ID])
REFERENCES [dbo].[COURSES] ([COURSE_ID])
ON DELETE SET DEFAULT
GO
ALTER TABLE [dbo].[GROUPS] CHECK CONSTRAINT [FK_GROUPS_ID_COURSES]
GO
ALTER TABLE [dbo].[STUDENTS]  WITH CHECK ADD  CONSTRAINT [FK_STUDENTS_GROUPS] FOREIGN KEY([GROUP_ID])
REFERENCES [dbo].[GROUPS] ([GROUP_ID])
ON DELETE SET DEFAULT
GO
ALTER TABLE [dbo].[STUDENTS] CHECK CONSTRAINT [FK_STUDENTS_GROUPS]
GO
USE [master]
GO
ALTER DATABASE [HogwartsDB] SET  READ_WRITE 
GO
