/* =========================================================
   RECREACIÓN COMPLETA DE LA BASE DE DATOS
========================================================= */
USE master;
GO

ALTER DATABASE LAFAGE_DB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO

DROP DATABASE LAFAGE_DB;
GO

CREATE DATABASE LAFAGE_DB;
GO

USE LAFAGE_DB;
GO


/* =========================================================
   CREACIÓN DE SCHEMAS (DDD)
========================================================= */
IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = 'personas')
    EXEC('CREATE SCHEMA personas');
GO

IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = 'catalogo')
    EXEC('CREATE SCHEMA catalogo');
GO

IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = 'ventas')
    EXEC('CREATE SCHEMA ventas');
GO

IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = 'auditoria')
    EXEC('CREATE SCHEMA auditoria');
GO

/* =========================================================
   PERSONAS
========================================================= */
CREATE TABLE personas.Persona (
    IdPersona INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Direccion VARCHAR(100),
    Telefono VARCHAR(20),
    Email VARCHAR(100),
    NumeroIdentificacion VARCHAR(20),
    FechaRegistro DATETIME DEFAULT GETDATE()
);
GO

ALTER TABLE personas.Persona
ADD Activo BIT NOT NULL DEFAULT 1;
GO

/* =========================================================
   CATÁLOGO
========================================================= */
CREATE TABLE catalogo.LineaProducto (
    IdLineaProducto INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(50) NOT NULL
);
GO

ALTER TABLE catalogo.LineaProducto
ADD Activo BIT NOT NULL DEFAULT 1;
GO

CREATE TABLE catalogo.Producto (
    IdProducto INT IDENTITY(1,1) PRIMARY KEY,
    IdLineaProducto INT NOT NULL,
    Descripcion VARCHAR(50) NOT NULL,
    Stock INT NOT NULL,
    FechaProduccion DATE,
    Precio DECIMAL(10,2) NOT NULL,
    Activo BIT DEFAULT 1,
    CONSTRAINT FK_Producto_LineaProducto
        FOREIGN KEY (IdLineaProducto)
        REFERENCES catalogo.LineaProducto(IdLineaProducto)
);
GO

/* =========================================================
   VENTAS
========================================================= */
CREATE TABLE ventas.Cliente (
    IdCliente INT IDENTITY(1,1) PRIMARY KEY,
    IdPersona INT NOT NULL,
    NIT VARCHAR(20),
    Activo BIT DEFAULT 1,
    CONSTRAINT FK_Cliente_Persona
        FOREIGN KEY (IdPersona)
        REFERENCES personas.Persona(IdPersona)
);
GO

CREATE TABLE ventas.AsesorComercial (
    IdAsesorComercial INT IDENTITY(1,1) PRIMARY KEY,
    IdPersona INT NOT NULL,
    Meta DECIMAL(10,2),
    Activo BIT DEFAULT 1,
    CONSTRAINT FK_Asesor_Persona
        FOREIGN KEY (IdPersona)
        REFERENCES personas.Persona(IdPersona)
);
GO

CREATE TABLE ventas.OrdenVenta (
    IdOrdenVenta INT IDENTITY(1,1) PRIMARY KEY,
    IdCliente INT NOT NULL,
    IdAsesorComercial INT NOT NULL,
    FechaOrden DATETIME NOT NULL DEFAULT GETDATE(),
    Observaciones VARCHAR(100),
    EstadoOrden VARCHAR(20),
    CONSTRAINT FK_OrdenVenta_Cliente
        FOREIGN KEY (IdCliente)
        REFERENCES ventas.Cliente(IdCliente),
    CONSTRAINT FK_OrdenVenta_Asesor
        FOREIGN KEY (IdAsesorComercial)
        REFERENCES ventas.AsesorComercial(IdAsesorComercial)
);
GO

CREATE TABLE ventas.LineaOrdenVenta (
    IdLineaOrdenVenta INT IDENTITY(1,1) PRIMARY KEY,
    IdOrdenVenta INT NOT NULL,
    IdProducto INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    Descuento DECIMAL(10,2) DEFAULT 0,
    CONSTRAINT FK_LineaOrdenVenta_Orden
        FOREIGN KEY (IdOrdenVenta)
        REFERENCES ventas.OrdenVenta(IdOrdenVenta),
    CONSTRAINT FK_LineaOrdenVenta_Producto
        FOREIGN KEY (IdProducto)
        REFERENCES catalogo.Producto(IdProducto)
);
GO

/* =========================================================
   AUDITORÍA
========================================================= */
CREATE TABLE auditoria.AuditoriaCambio (
    IdAuditoria INT IDENTITY(1,1) PRIMARY KEY,
    TablaAfectada VARCHAR(50),
    CampoAfectado VARCHAR(50),
    IdRegistro INT,
    ValorAnterior VARCHAR(100),
    ValorNuevo VARCHAR(100),
    FechaCambio DATETIME DEFAULT GETDATE()
);
GO

/* =========================================================
   ÍNDICES PRINCIPALES
========================================================= */
CREATE NONCLUSTERED INDEX IX_Producto_LineaProducto
ON catalogo.Producto(IdLineaProducto);

CREATE NONCLUSTERED INDEX IX_Producto_Activo
ON catalogo.Producto(Activo)
WHERE Activo = 1;

CREATE NONCLUSTERED INDEX IX_Cliente_Persona
ON ventas.Cliente(IdPersona);

CREATE NONCLUSTERED INDEX IX_Asesor_Persona
ON ventas.AsesorComercial(IdPersona);

CREATE NONCLUSTERED INDEX IX_OrdenVenta_Cliente
ON ventas.OrdenVenta(IdCliente);

CREATE NONCLUSTERED INDEX IX_OrdenVenta_Asesor
ON ventas.OrdenVenta(IdAsesorComercial);

CREATE NONCLUSTERED INDEX IX_LineaOrdenVenta_Orden
ON ventas.LineaOrdenVenta(IdOrdenVenta);

CREATE NONCLUSTERED INDEX IX_LineaOrdenVenta_Producto
ON ventas.LineaOrdenVenta(IdProducto);
GO
