USE LAFAGE_DW;
GO

/* ============================
   Poblar Dimensiones
   ============================ */

/* dim.Cliente */
INSERT INTO dim.Cliente (IdCliente_OLTP, NombreCliente, NIT, Activo)
SELECT c.idCliente,
       CONCAT(p.nombre, ' ', p.apellido),
       c.nit,
       c.activo
FROM LAFAGE_DB.ventas.Cliente c
JOIN LAFAGE_DB.personas.Persona p ON c.idPersona = p.idPersona
WHERE c.activo = 1;

/* dim.AsesorComercial */
INSERT INTO dim.AsesorComercial (IdAsesor_OLTP, NombreAsesor, Meta, Activo)
SELECT a.idAsesorComercial,
       CONCAT(p.nombre, ' ', p.apellido),
       a.meta,
       a.activo
FROM LAFAGE_DB.ventas.AsesorComercial a
JOIN LAFAGE_DB.personas.Persona p ON a.idPersona = p.idPersona
WHERE a.activo = 1;

/* dim.Producto */
INSERT INTO dim.Producto (IdProducto_OLTP, NombreProducto, LineaProducto, PrecioActual, Activo)
SELECT pr.idProducto,
       pr.descripcion,
       lp.descripcion,
       pr.precio,
       pr.activo
FROM LAFAGE_DB.catalogo.Producto pr
JOIN LAFAGE_DB.catalogo.LineaProducto lp ON pr.idLineaProducto = lp.idLineaProducto
WHERE pr.activo = 1;

/* dim.Fecha (Calendario) */
WITH Dates AS (
    SELECT CAST('2020-01-01' AS DATE) AS Fecha
    UNION ALL
    SELECT DATEADD(DAY, 1, Fecha)
    FROM Dates
    WHERE Fecha < '2030-12-31'
)
INSERT INTO dim.Fecha (FechaKey, Fecha, Anio, Mes, NombreMes, Trimestre, DiaSemana)
SELECT 
    ROW_NUMBER() OVER (ORDER BY Fecha) AS FechaKey,
    Fecha,
    YEAR(Fecha),
    MONTH(Fecha),
    DATENAME(MONTH, Fecha),
    DATEPART(QUARTER, Fecha),
    DATENAME(WEEKDAY, Fecha)
FROM Dates
OPTION (MAXRECURSION 0);

---------------------------------------------------
/* ============================
   Poblar Tabla de Hechos fact.Ventas
   ============================ */

INSERT INTO fact.Ventas (
    FechaKey,
    ClienteKey,
    ProductoKey,
    AsesorKey,
    Cantidad,
    PrecioUnitario,
    Descuento,
    EstadoOrden
)
SELECT 
    f.FechaKey,
    dc.ClienteKey,
    dp.ProductoKey,
    da.AsesorKey,
    dp_oltp.cantidad,
    dp_oltp.precioUnitario,
    dp_oltp.descuento,
    'Completado'
FROM LAFAGE_DB.ventas.ordenVenta p
JOIN LAFAGE_DB.ventas.LineaOrdenVenta dp_oltp ON p.idOrdenVenta = dp_oltp.idOrdenVenta
JOIN dim.Fecha f ON f.Fecha = CAST(p.fechaOrden AS DATE)
JOIN dim.Cliente dc ON dc.IdCliente_OLTP = p.idCliente
JOIN dim.AsesorComercial da ON da.IdAsesor_OLTP = p.idAsesorComercial
JOIN dim.Producto dp ON dp.IdProducto_OLTP = dp_oltp.idProducto;