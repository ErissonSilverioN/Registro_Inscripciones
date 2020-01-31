

Create DataBase RegistroInscripcionesDB
Go

Use RegistroInscripcionesDB

Create Table Personas(
PersonaId int Primary Key Identity,
Nombre varchar(15),
Telefono varchar(13),
Cedula varchar(15),
Direccion varchar(max),
FechaNacimiento datetime,
Balance decimal
);

Create Table Inscripciones(
InscripcionId int Primary Key Identity,
PersonaId int Not Null,
Comentario varchar(max),
Monto decimal,
Fecha DateTime,
Foreign Key (PersonaId) References Personas(PersonaId)
)




