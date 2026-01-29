USE master;
GO

IF DB_ID('LAFAGE_DW') IS NOT NULL
BEGIN
    ALTER DATABASE LAFAGE_DW SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE LAFAGE_DW;
END
GO

CREATE DATABASE LAFAGE_DW;
GO

USE LAFAGE_DW;
GO

CREATE SCHEMA dim;
GO

CREATE SCHEMA fact;
GO

CREATE TABLE dim.Fecha (
    FechaKey INT PRIMARY KEY,         -- YYYYMMDD
    Fecha DATE NOT NULL,
    Anio INT NOT NULL,
    Mes INT NOT NULL,
    NombreMes VARCHAR(20),
    Trimestre INT,
    DiaSemana VARCHAR(20)
);
GO

CREATE TABLE dim.Cliente (
    ClienteKey INT IDENTITY(1,1) PRIMARY KEY,
    IdCliente_OLTP INT NOT NULL,
    NombreCliente VARCHAR(150),
    NIT VARCHAR(20),
    Activo BIT
);
GO

CREATE TABLE dim.AsesorComercial (
    AsesorKey INT IDENTITY(1,1) PRIMARY KEY,
    IdAsesor_OLTP INT NOT NULL,
    NombreAsesor VARCHAR(150),
    Meta DECIMAL(12,2),
    Activo BIT
);
GO

CREATE TABLE dim.Producto (
    ProductoKey INT IDENTITY(1,1) PRIMARY KEY,
    IdProducto_OLTP INT NOT NULL,
    NombreProducto VARCHAR(150),
    LineaProducto VARCHAR(100),
    PrecioActual DECIMAL(10,2),
    Activo BIT
);
GO

CREATE TABLE fact.Ventas (
    FactVentaKey BIGINT IDENTITY(1,1) PRIMARY KEY,

    FechaKey INT NOT NULL,
    ClienteKey INT NOT NULL,
    ProductoKey INT NOT NULL,
    AsesorKey INT NOT NULL,

    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    Descuento DECIMAL(10,2) NOT NULL,
    TotalLinea AS ((Cantidad * PrecioUnitario) - Descuento) PERSISTED,

    EstadoOrden VARCHAR(30),

    CONSTRAINT FK_Ventas_Fecha FOREIGN KEY (FechaKey)
        REFERENCES dim.Fecha(FechaKey),

    CONSTRAINT FK_Ventas_Cliente FOREIGN KEY (ClienteKey)
        REFERENCES dim.Cliente(ClienteKey),

    CONSTRAINT FK_Ventas_Producto FOREIGN KEY (ProductoKey)
        REFERENCES dim.Producto(ProductoKey),

    CONSTRAINT FK_Ventas_Asesor FOREIGN KEY (AsesorKey)
        REFERENCES dim.AsesorComercial(AsesorKey)
);
GO

CREATE NONCLUSTERED INDEX IX_Ventas_Fecha
ON fact.Ventas (FechaKey);

CREATE NONCLUSTERED INDEX IX_Ventas_Cliente
ON fact.Ventas (ClienteKey);

CREATE NONCLUSTERED INDEX IX_Ventas_Producto
ON fact.Ventas (ProductoKey);

CREATE NONCLUSTERED INDEX IX_Ventas_Asesor
ON fact.Ventas (AsesorKey);
GO
