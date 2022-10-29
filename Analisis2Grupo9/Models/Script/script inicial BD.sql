create database analisis2_2022;

use analisis2_2022;

/*agregar la cadena de conexion 
actualizando la BD desde el modelo
*/

CREATE TABLE Puesto (
    id_puesto int identity(1,1) primary key,
    codigo varchar(255),
    nombre varchar(255),
    estado int
);

CREATE TABLE Empleado (
    id_empleado int identity(1,1),
	id_puesto int,
    codigo varchar(255),
    nombre varchar(255),
    apellido varchar(255),
    usuario varchar(255),
	password varchar(255),
	PRIMARY KEY (id_empleado),
    CONSTRAINT FK_empleadopuesto FOREIGN KEY (id_puesto)
    REFERENCES Puesto(id_puesto)
);


CREATE TABLE Estado_Ticket (
    id_estado_ticket int identity(1,1) primary key,
    nombre varchar(255),
    estado int
);

CREATE TABLE Categoria_Ticket (
    id_categoria_ticket int identity(1,1) primary key,
    codigo varchar(255),
    nombre varchar(255),
	estado int
);

CREATE TABLE Categoria_Insumo (
    id_categoria_insumo int identity(1,1) primary key,
    codigo varchar(255),
    nombre varchar(255),
    estado int
);

CREATE TABLE Insumo (
    id_insumo int identity(1,1),
	id_categoria_insumo int,
    codigo varchar(255),
    descripcion varchar(255),
    cantidad int,
	estado int,
	PRIMARY KEY (id_insumo),
    CONSTRAINT FK_insumocatinsumo FOREIGN KEY (id_categoria_insumo)
    REFERENCES Categoria_Insumo(id_categoria_insumo)
);

CREATE TABLE Ticket (
    id_ticket int identity(1,1),
    id_empleado_solicitud int,
	id_empleado_asignacion int null,
    id_categoria_ticket int,
	id_estado_ticket int,
	fecha_solicitud datetime,
	titulo varchar(100),
	descripcion varchar(255),
	PRIMARY KEY (id_ticket),
    CONSTRAINT FK_ticketempsoli FOREIGN KEY (id_empleado_solicitud)
    REFERENCES Empleado(id_empleado),
	CONSTRAINT FK_ticketempasig FOREIGN KEY (id_empleado_asignacion)
    REFERENCES Empleado(id_empleado),
	CONSTRAINT FK_ticketcatticket FOREIGN KEY (id_categoria_ticket)
    REFERENCES Categoria_Ticket(id_categoria_ticket),
	CONSTRAINT FK_ticketestadoticket FOREIGN KEY (id_estado_ticket)
    REFERENCES Estado_Ticket(id_estado_ticket)
);

CREATE TABLE Ticket_Seguimiento (
    id_ticket_seguimiento int identity(1,1),
    id_empleado int,
	id_ticket int,
	fecha_seguimiento datetime,
	descripcion_seguimiento varchar(255),
	fecha_inicio_seguimiento datetime,
	fecha_fin_seguimiento datetime,
	PRIMARY KEY (id_ticket_seguimiento),
    CONSTRAINT FK_ticketsegemp FOREIGN KEY (id_empleado)
    REFERENCES Empleado(id_empleado),
	CONSTRAINT FK_ticketsegticket FOREIGN KEY (id_ticket)
    REFERENCES Ticket(id_ticket)
);

CREATE TABLE Requisicion_Interna (
    id_requisicion int identity(1,1),
    id_ticket_seguimiento int,
	id_insumo int,
	cantidad int,
	fecha_solicitud datetime,
	PRIMARY KEY (id_requisicion),
	CONSTRAINT FK_reqintticket FOREIGN KEY (id_ticket_seguimiento)
    REFERENCES Ticket_Seguimiento(id_ticket_seguimiento),
	CONSTRAINT FK_reqintinsumo FOREIGN KEY (id_insumo)
    REFERENCES Insumo(id_insumo)
);