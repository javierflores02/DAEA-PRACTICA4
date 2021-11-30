CREATE TABLE AUTOR(
	IdAutor int primary key,
	Nombre varchar(100),
	Nacionalidad varchar(100),
);

CREATE TABLE LIBRO(
	IdLibro int primary key,
	Codigo int,
	Titulo varchar(100),
    ISBN varchar(30),
    Editorial varchar(60),
    NumPags tinyint,
	IdAutor int,
	foreign key (IdAutor) references AUTOR (IdAutor)
);

CREATE TABLE USUARIO(
	IdUsuario int primary key,
	NumUsuario int,
	NIF varchar(20),
	Nombre varchar(100),
	Direccion varchar(255),
	Telefono varchar(20),
);

CREATE TABLE PRESTAMO(
	IdPrestamo int primary key,
	IdLibro int,
	IdUsuario int,
	FecPrestamo datetime,
	FecDevolucion datetime,
	foreign key (IdLibro) references LIBRO (IdLibro),
	foreign key (IdUsuario) references USUARIO (IdUsuario)
);