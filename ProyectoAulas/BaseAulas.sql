CREATE DATABASE AulaBase
go

Use AulaBase
go

CREATE TABLE Facultad(
	IdFacultad int IDENTITY(1,1) primary key NOT NULL,
	NombreFacultad varchar(50) NOT NULL)
GO

CREATE TABLE Carrera(
	IdCarrera int IDENTITY(1,1) primary key NOT NULL,
	IdFacultad int foreign key references Facultad(IdFacultad),
	NombreCarrera varchar(200) NOT NULL)
GO

CREATE TABLE Grupo(
	IdGrupo int IDENTITY(1,1) primary key NOT NULL,
	IdCarrera int foreign key references Carrera(IdCarrera),
	NombreGrupo varchar(50) NOT NULL)
GO

CREATE TABLE Bitacora(
	IdBitacora int IDENTITY(1,1) primary key NOT NULL,
	IdUsuario varchar(50) NOT NULL,
	HoraFecha datetime NOT NULL,
	Accion varchar(250) NOT NULL
)
GO

CREATE TABLE Espacio(
	IdEspacio int IDENTITY(1,1) primary key NOT NULL,
	NombreEspacio varchar(100) NOT NULL,
	Descripcion varchar(500) NOT NULL,
	Capacidad int NOT NULL,
	Tipo varchar(100) NOT NULL,
	Estado int NOT NULL)
GO

CREATE TABLE BloqueHoras(
	IdBloque int primary key IDENTITY(1,1) NOT NULL,
	NombreBloque varchar(25) NOT NULL,
	HoraInicio datetime NOT NULL,
	HoraFin datetime NOT NULL,
	Turno varchar(15) NOT NULL,
	Estado int NOT NULL)
GO

CREATE TABLE Reserva(
	IdReserva int primary key IDENTITY(1,1) NOT NULL,
	CodigoReservante varchar(50) NOT NULL,
	IdEspacio int foreign key references Espacio(IdEspacio),
	IdBloque int foreign key references BloqueHoras(IdBloque),
	Fecha datetime NOT NULL,
	Confirmacion varchar(100) NULL,
	Estado int NOT NULL
	)
GO

CREATE TABLE Usuario(
	IdUsuario varchar(50) primary key NOT NULL,
	Nombre varchar(50) NOT NULL,
	Apellido varchar(50) NULL,
	Tipo int NOT NULL,
	Estado int NOT NULL)
GO

CREATE TABLE Logueo(
	IdLogueo int primary key IDENTITY(1,1) NOT NULL,
	IdUsuario varchar(50) foreign key references Usuario(IdUsuario),
	Usuario varchar(25) NULL,
	Clave varchar(25) NULL,
	Tipo int NOT NULL,
	Estado int NOT NULL)

GO

CREATE TABLE TelefonoUsuario(
	IdTelefono int primary key IDENTITY(1,1) NOT NULL,
	IdUsuario varchar(50) foreign key references Usuario(IdUsuario),
	Telefono int NOT NULL,
	Estado int NOT NULL)
GO

CREATE TABLE CorreoUsuario(
	IdCorreo int primary key IDENTITY(1,1) NOT NULL,
	IdUsuario varchar(50) foreign key references Usuario(IdUsuario),
	Correo varchar(75) NOT NULL,
	Estado int NOT NULL)
GO

CREATE TABLE Materia(
	IdMateria int primary key IDENTITY(1,1) NOT NULL,
	NombreMateria varchar(100) NOT NULL,
	IdGrupo int foreign key references Grupo(IdGrupo),
	IdUsuario nvarchar(128))
GO

CREATE TABLE HorariosFijos(
	IdHorarioFijo int primary key IDENTITY(1,1) NOT NULL,	
	IdMateria int foreign key references Materia(IdMateria),
	IdEspacio int foreign key references Espacio(IdEspacio),	
	Estado int NOT NULL )
GO
Create table Horario(
	IdHorario int primary key IDENTITY(1,1) NOT NULL,
	IdHorarioFijo int  foreign key references HorariosFijos(IdHorarioFijo),
	IdBloque int foreign key references BloqueHoras(IdBloque),
	Dia varchar (15),
	Estado int NOT NULL,
)
go

CREATE TABLE InscripcionMateria(
	IdInscripcion int primary key IDENTITY(1,1) NOT NULL,
	IdInscrito nvarchar(128),
	IdMateria int,
	Estado int NOT NULL)
GO