USE [master]
GO
/****** Object:  Database [GimnasioMetroFlex]    Script Date: 18/6/2022 14:57:17 ******/
CREATE DATABASE [GimnasioMetroFlex]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GimnasioMetroFlex', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\GimnasioMetroFlex.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GimnasioMetroFlex_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\GimnasioMetroFlex_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [GimnasioMetroFlex] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GimnasioMetroFlex].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GimnasioMetroFlex] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GimnasioMetroFlex] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GimnasioMetroFlex] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GimnasioMetroFlex] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GimnasioMetroFlex] SET ARITHABORT OFF 
GO
ALTER DATABASE [GimnasioMetroFlex] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GimnasioMetroFlex] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GimnasioMetroFlex] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GimnasioMetroFlex] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GimnasioMetroFlex] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GimnasioMetroFlex] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GimnasioMetroFlex] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GimnasioMetroFlex] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GimnasioMetroFlex] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GimnasioMetroFlex] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GimnasioMetroFlex] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GimnasioMetroFlex] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GimnasioMetroFlex] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GimnasioMetroFlex] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GimnasioMetroFlex] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GimnasioMetroFlex] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GimnasioMetroFlex] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GimnasioMetroFlex] SET RECOVERY FULL 
GO
ALTER DATABASE [GimnasioMetroFlex] SET  MULTI_USER 
GO
ALTER DATABASE [GimnasioMetroFlex] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GimnasioMetroFlex] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GimnasioMetroFlex] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GimnasioMetroFlex] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GimnasioMetroFlex] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GimnasioMetroFlex] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'GimnasioMetroFlex', N'ON'
GO
ALTER DATABASE [GimnasioMetroFlex] SET QUERY_STORE = OFF
GO
USE [GimnasioMetroFlex]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sociosGym](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[apellido] [varchar](50) NULL,
	[sexo] [varchar](50) NULL,
	[pase] [int] NULL,
	[pago] [int] NULL,
	[estatus] [int] NULL,
	[fecha_ingreso] [date] NULL,
	[dni] [int] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[sociosGym] ON 

INSERT [dbo].[sociosGym] ([id], [nombre], [apellido], [sexo], [pase], [pago], [estatus], [fecha_ingreso], [dni]) VALUES (1, N'Ronnie', N'Coleman', N'MASCULINO', 1, 1, 0, CAST(N'2022-6-4' AS Date), 24625100)
INSERT [dbo].[sociosGym] ([id], [nombre], [apellido], [sexo], [pase], [pago], [estatus], [fecha_ingreso], [dni]) VALUES (2, N'Jay', N'Cutler', N'MASCULINO', 0, 0, 0, CAST(N'2022-6-4' AS Date), 32782642)
INSERT [dbo].[sociosGym] ([id], [nombre], [apellido], [sexo], [pase], [pago], [estatus], [fecha_ingreso], [dni]) VALUES (3, N'Tom', N'Platz', N'MASCULINO', 2, 2, 0, CAST(N'2022-6-4' AS Date), 17998120)
INSERT [dbo].[sociosGym] ([id], [nombre], [apellido], [sexo], [pase], [pago], [estatus], [fecha_ingreso], [dni]) VALUES (4, N'Chris', N'Bumstead', N'MASCULINO', 2, 2, 0, CAST(N'2022-6-4' AS Date), 35147890)
INSERT [dbo].[sociosGym] ([id], [nombre], [apellido], [sexo], [pase], [pago], [estatus], [fecha_ingreso], [dni]) VALUES (5, N'Larry', N'Wheels', N'MASCULINO', 0, 0, 0, CAST(N'2022-6-4' AS Date), 36529123)
INSERT [dbo].[sociosGym] ([id], [nombre], [apellido], [sexo], [pase], [pago], [estatus], [fecha_ingreso], [dni]) VALUES (6, N'Noelia', N'Cvitanovic', N'FEMENINO', 2, 2, 0, CAST(N'2022-6-4' AS Date), 42897456)
SET IDENTITY_INSERT [dbo].[sociosGym] OFF
GO
USE [master]
GO
ALTER DATABASE [GimnasioMetroFlex] SET  READ_WRITE 
GO


