USE [master]
GO
/****** Object:  Database [Races]    Script Date: 23/04/2024 12:11:58 ******/
CREATE DATABASE [Races]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'races', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\races.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'races_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\races_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Races] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Races].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Races] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Races] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Races] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Races] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Races] SET ARITHABORT OFF 
GO
ALTER DATABASE [Races] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Races] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Races] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Races] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Races] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Races] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Races] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Races] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Races] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Races] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Races] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Races] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Races] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Races] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Races] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Races] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Races] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Races] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Races] SET  MULTI_USER 
GO
ALTER DATABASE [Races] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Races] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Races] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Races] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Races] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Races] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Races] SET QUERY_STORE = ON
GO
ALTER DATABASE [Races] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Races]
GO
/****** Object:  Table [dbo].[Car]    Script Date: 23/04/2024 12:11:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Car](
	[CarId] [int] IDENTITY(1,1) NOT NULL,
	[Naam] [nvarchar](255) NOT NULL,
	[MaximaleSnelheid] [int] NOT NULL,
	[Cc] [int] NOT NULL,
	[DatumRegistratie] [datetime2](7) NOT NULL,
	[DriverId] [int] NOT NULL,
 CONSTRAINT [PK_Car] PRIMARY KEY CLUSTERED 
(
	[CarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Driver]    Script Date: 23/04/2024 12:11:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Driver](
	[DriverId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](225) NOT NULL,
	[LastName] [nvarchar](512) NOT NULL,
	[CallSign] [nvarchar](512) NOT NULL,
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_Driver] PRIMARY KEY CLUSTERED 
(
	[DriverId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Race]    Script Date: 23/04/2024 12:11:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Race](
	[RaceId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](512) NOT NULL,
	[StartTime] [datetime2](7) NOT NULL,
	[StopTime] [datetime2](7) NULL,
	[DriverId] [int] NULL,
 CONSTRAINT [PK_Race] PRIMARY KEY CLUSTERED 
(
	[RaceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Race_Driver]    Script Date: 23/04/2024 12:11:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Race_Driver](
	[RaceId] [int] NOT NULL,
	[DriverId] [int] NOT NULL,
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_Race_Driver] PRIMARY KEY CLUSTERED 
(
	[RaceId] ASC,
	[DriverId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 23/04/2024 12:11:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](225) NOT NULL,
	[LastName] [nvarchar](512) NOT NULL,
	[CallSign] [nvarchar](512) NOT NULL,
	[BirthDate] [datetime2](7) NOT NULL,
	[UserTypeId] [int] NOT NULL,
	[Password] [nvarchar](512) NOT NULL,
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserType]    Script Date: 23/04/2024 12:11:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserType](
	[UserTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED 
(
	[UserTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Driver] ADD  CONSTRAINT [DF_Driver_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Race_Driver] ADD  CONSTRAINT [DF_Race_Driver_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[UserType] ADD  CONSTRAINT [DF_UserType_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Car]  WITH CHECK ADD  CONSTRAINT [FK_Car_Driver] FOREIGN KEY([DriverId])
REFERENCES [dbo].[Driver] ([DriverId])
GO
ALTER TABLE [dbo].[Car] CHECK CONSTRAINT [FK_Car_Driver]
GO
ALTER TABLE [dbo].[Race]  WITH CHECK ADD  CONSTRAINT [FK_Race_Driver] FOREIGN KEY([DriverId])
REFERENCES [dbo].[Driver] ([DriverId])
GO
ALTER TABLE [dbo].[Race] CHECK CONSTRAINT [FK_Race_Driver]
GO
ALTER TABLE [dbo].[Race_Driver]  WITH CHECK ADD  CONSTRAINT [FK_Race_Driver_Driver] FOREIGN KEY([DriverId])
REFERENCES [dbo].[Driver] ([DriverId])
GO
ALTER TABLE [dbo].[Race_Driver] CHECK CONSTRAINT [FK_Race_Driver_Driver]
GO
ALTER TABLE [dbo].[Race_Driver]  WITH CHECK ADD  CONSTRAINT [FK_Race_Driver_Race] FOREIGN KEY([RaceId])
REFERENCES [dbo].[Race] ([RaceId])
GO
ALTER TABLE [dbo].[Race_Driver] CHECK CONSTRAINT [FK_Race_Driver_Race]
GO
USE [master]
GO
ALTER DATABASE [Races] SET  READ_WRITE 
GO