USE [master]
GO
/****** Object:  Database [Devsu]    Script Date: 19/07/2023 02:01:42 a. m. ******/
CREATE DATABASE [Devsu]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Devsu', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Devsu.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Devsu_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Devsu_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Devsu] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Devsu].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Devsu] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Devsu] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Devsu] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Devsu] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Devsu] SET ARITHABORT OFF 
GO
ALTER DATABASE [Devsu] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Devsu] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Devsu] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Devsu] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Devsu] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Devsu] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Devsu] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Devsu] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Devsu] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Devsu] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Devsu] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Devsu] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Devsu] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Devsu] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Devsu] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Devsu] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Devsu] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Devsu] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Devsu] SET  MULTI_USER 
GO
ALTER DATABASE [Devsu] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Devsu] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Devsu] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Devsu] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Devsu] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Devsu] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Devsu] SET QUERY_STORE = ON
GO
ALTER DATABASE [Devsu] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Devsu]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 19/07/2023 02:01:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
	[Genero] [varchar](20) NULL,
	[Edad] [int] NULL,
	[Identificacion] [varchar](20) NULL,
	[Direccion] [varchar](500) NULL,
	[Telefono] [varchar](20) NULL,
	[Contrasenia] [varchar](50) NULL,
	[Estado] [char](5) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuentas]    Script Date: 19/07/2023 02:01:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuentas](
	[Numero] [bigint] NOT NULL,
	[Tipo] [varchar](200) NULL,
	[SaldoInicial] [decimal](18, 6) NULL,
	[ClienteId] [bigint] NULL,
	[Estado] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimientos]    Script Date: 19/07/2023 02:01:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimientos](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NULL,
	[Tipo] [varchar](10) NULL,
	[Valor] [decimal](18, 6) NULL,
	[Saldo] [decimal](18, 6) NULL,
	[CuentaNumero] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Movimientos] ADD  DEFAULT (getdate()) FOR [Fecha]
GO
ALTER TABLE [dbo].[Cuentas]  WITH CHECK ADD  CONSTRAINT [FK_CLIENTE] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([Id])
GO
ALTER TABLE [dbo].[Cuentas] CHECK CONSTRAINT [FK_CLIENTE]
GO
ALTER TABLE [dbo].[Movimientos]  WITH CHECK ADD  CONSTRAINT [FK_CUENTA] FOREIGN KEY([CuentaNumero])
REFERENCES [dbo].[Cuentas] ([Numero])
GO
ALTER TABLE [dbo].[Movimientos] CHECK CONSTRAINT [FK_CUENTA]
GO
/****** Object:  Trigger [dbo].[trgAfterInsertMovimientosCreditos]    Script Date: 19/07/2023 02:01:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Ricardo Munoz>
-- Create date: <18/07/2023>
-- Description:	<Trigger para actualizar la cuenta cuando se tenga un registro nuevo de Deposito>
-- =============================================
CREATE TRIGGER [dbo].[trgAfterInsertMovimientosCreditos]
ON [dbo].[Movimientos]
AFTER INSERT
AS
BEGIN
    -- Actualizar el saldo en la tabla "cuentas"
    UPDATE cuentas
    SET SaldoInicial = SaldoInicial + i.Valor  -- Aquí suponemos que el monto es negativo para retiros, si es positivo para depósitos, debes cambiar el signo.
    FROM cuentas c
    INNER JOIN inserted i ON c.Numero = i.CuentaNumero and i.Tipo='Credito';
END;
GO
ALTER TABLE [dbo].[Movimientos] ENABLE TRIGGER [trgAfterInsertMovimientosCreditos]
GO
/****** Object:  Trigger [dbo].[trgAfterInsertMovimientosDebitos]    Script Date: 19/07/2023 02:01:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Ricardo Munoz>
-- Create date: <18/07/2023>
-- Description:	<Trigger para actualizar la cuenta cuando se tenga un registro nuevo de Deposito>
-- =============================================
CREATE TRIGGER [dbo].[trgAfterInsertMovimientosDebitos]
ON [dbo].[Movimientos]
AFTER INSERT
AS
BEGIN
    -- Actualizar el saldo en la tabla "cuentas"
    UPDATE cuentas
    SET SaldoInicial = c.SaldoInicial + i.Valor  -- Aquí suponemos que el monto es negativo para retiros, si es positivo para depósitos, debes cambiar el signo.
    FROM cuentas c
    INNER JOIN inserted i ON c.Numero = i.CuentaNumero and i.Tipo='Debito';
END;
GO
ALTER TABLE [dbo].[Movimientos] ENABLE TRIGGER [trgAfterInsertMovimientosDebitos]
GO
USE [master]
GO
ALTER DATABASE [Devsu] SET  READ_WRITE 
GO
