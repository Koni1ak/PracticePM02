USE [master]
GO

/****** Object:  Database [Medlab]    Script Date: 17.05.2024 6:53:58 ******/
CREATE DATABASE [Medlab]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Medlab', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Medlab.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Medlab_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Medlab_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Medlab].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Medlab] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Medlab] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Medlab] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Medlab] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Medlab] SET ARITHABORT OFF 
GO

ALTER DATABASE [Medlab] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Medlab] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Medlab] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Medlab] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Medlab] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Medlab] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Medlab] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Medlab] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Medlab] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Medlab] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Medlab] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Medlab] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Medlab] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Medlab] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Medlab] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Medlab] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Medlab] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Medlab] SET RECOVERY FULL 
GO

ALTER DATABASE [Medlab] SET  MULTI_USER 
GO

ALTER DATABASE [Medlab] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Medlab] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Medlab] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Medlab] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [Medlab] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Medlab] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [Medlab] SET QUERY_STORE = OFF
GO

ALTER DATABASE [Medlab] SET  READ_WRITE 
GO


 