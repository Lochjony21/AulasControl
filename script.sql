USE [master]
GO
/****** Object:  Database [asignacion]    Script Date: 1/24/2019 2:18:05 PM ******/
CREATE DATABASE [asignacion]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'asignacion', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\asignacion.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'asignacion_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\asignacion_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [asignacion] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [asignacion].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [asignacion] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [asignacion] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [asignacion] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [asignacion] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [asignacion] SET ARITHABORT OFF 
GO
ALTER DATABASE [asignacion] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [asignacion] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [asignacion] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [asignacion] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [asignacion] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [asignacion] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [asignacion] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [asignacion] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [asignacion] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [asignacion] SET  DISABLE_BROKER 
GO
ALTER DATABASE [asignacion] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [asignacion] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [asignacion] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [asignacion] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [asignacion] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [asignacion] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [asignacion] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [asignacion] SET RECOVERY FULL 
GO
ALTER DATABASE [asignacion] SET  MULTI_USER 
GO
ALTER DATABASE [asignacion] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [asignacion] SET DB_CHAINING OFF 
GO
ALTER DATABASE [asignacion] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [asignacion] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [asignacion] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [asignacion] SET QUERY_STORE = OFF
GO
USE [asignacion]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [asignacion]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 1/24/2019 2:18:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[IdBitacora] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[HoraFecha] [datetime] NOT NULL,
	[accion] [varchar](250) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdBitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BloqueHoras]    Script Date: 1/24/2019 2:18:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BloqueHoras](
	[IdBloque] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](25) NOT NULL,
	[HoraInicio] [datetime] NOT NULL,
	[HoraFin] [datetime] NOT NULL,
	[Turno] [varchar](10) NOT NULL,
	[Estado] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdBloque] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carrera]    Script Date: 1/24/2019 2:18:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrera](
	[IdCarrera] [int] IDENTITY(1,1) NOT NULL,
	[IdFacultad] [int] NULL,
	[Nombre] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCarrera] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CorreoUsuario]    Script Date: 1/24/2019 2:18:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CorreoUsuario](
	[IdCorreo] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Correo] [varchar](75) NOT NULL,
	[Estado] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCorreo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Espacio]    Script Date: 1/24/2019 2:18:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Espacio](
	[IdEspacio] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Descripcion] [varchar](250) NOT NULL,
	[Capacidad] [int] NOT NULL,
	[tipo] [varchar](50) NULL,
	[Estado] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEspacio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facultad]    Script Date: 1/24/2019 2:18:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facultad](
	[IdFacultad] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdFacultad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grupo]    Script Date: 1/24/2019 2:18:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grupo](
	[IdGrupo] [int] IDENTITY(1,1) NOT NULL,
	[IdCarrera] [int] NULL,
	[Nombre] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdGrupo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HorariosFijos]    Script Date: 1/24/2019 2:18:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HorariosFijos](
	[IdHorarios] [int] IDENTITY(1,1) NOT NULL,
	[IdBloque] [int] NULL,
	[IdMateria] [int] NULL,
	[IdEspacio] [int] NULL,
	[FechaInicio] [date] NOT NULL,
	[FechaFin] [date] NOT NULL,
	[Estado] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdHorarios] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InscripcionMateria]    Script Date: 1/24/2019 2:18:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InscripcionMateria](
	[IdInscripcion] [int] IDENTITY(1,1) NOT NULL,
	[IdInscrito] [int] NULL,
	[IdMateria] [int] NULL,
	[Estado] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdInscripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[logueo]    Script Date: 1/24/2019 2:18:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[logueo](
	[IdLogueo] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Usuario] [varchar](25) NULL,
	[Clave] [varchar](25) NULL,
	[Estado] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdLogueo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materia]    Script Date: 1/24/2019 2:18:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materia](
	[IdMateria] [int] IDENTITY(1,1) NOT NULL,
	[NombreMateria] [varchar](100) NOT NULL,
	[IdGrupo] [int] NULL,
	[IdUsuario] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMateria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reserva]    Script Date: 1/24/2019 2:18:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserva](
	[IdReserva] [int] IDENTITY(1,1) NOT NULL,
	[CodigoReservante] [int] NOT NULL,
	[IdEspacio] [int] NULL,
	[IdBloque] [int] NULL,
	[Fecha] [datetime] NOT NULL,
	[Estado] [int] NOT NULL,
	[confirmacion] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdReserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TelefonoUsuario]    Script Date: 1/24/2019 2:18:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TelefonoUsuario](
	[IdTelefono] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Telefono] [int] NOT NULL,
	[Estado] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTelefono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 1/24/2019 2:18:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NULL,
	[Tipo] [int] NULL,
	[Estado] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Carrera]  WITH CHECK ADD FOREIGN KEY([IdFacultad])
REFERENCES [dbo].[Facultad] ([IdFacultad])
GO
ALTER TABLE [dbo].[CorreoUsuario]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Grupo]  WITH CHECK ADD FOREIGN KEY([IdCarrera])
REFERENCES [dbo].[Carrera] ([IdCarrera])
GO
ALTER TABLE [dbo].[HorariosFijos]  WITH CHECK ADD FOREIGN KEY([IdBloque])
REFERENCES [dbo].[BloqueHoras] ([IdBloque])
GO
ALTER TABLE [dbo].[HorariosFijos]  WITH CHECK ADD FOREIGN KEY([IdEspacio])
REFERENCES [dbo].[Espacio] ([IdEspacio])
GO
ALTER TABLE [dbo].[HorariosFijos]  WITH CHECK ADD FOREIGN KEY([IdMateria])
REFERENCES [dbo].[Materia] ([IdMateria])
GO
ALTER TABLE [dbo].[InscripcionMateria]  WITH CHECK ADD FOREIGN KEY([IdInscrito])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[InscripcionMateria]  WITH CHECK ADD FOREIGN KEY([IdMateria])
REFERENCES [dbo].[Materia] ([IdMateria])
GO
ALTER TABLE [dbo].[logueo]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Materia]  WITH CHECK ADD FOREIGN KEY([IdGrupo])
REFERENCES [dbo].[Grupo] ([IdGrupo])
GO
ALTER TABLE [dbo].[Materia]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD FOREIGN KEY([IdBloque])
REFERENCES [dbo].[BloqueHoras] ([IdBloque])
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD FOREIGN KEY([IdEspacio])
REFERENCES [dbo].[Espacio] ([IdEspacio])
GO
ALTER TABLE [dbo].[TelefonoUsuario]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
USE [master]
GO
ALTER DATABASE [asignacion] SET  READ_WRITE 
GO
