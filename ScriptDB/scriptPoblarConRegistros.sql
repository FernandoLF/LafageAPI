DECLARE @TotalOrdenes INT = 10000;
DECLARE @Contador INT = 1;

DECLARE @IdCliente INT;
DECLARE @IdAsesor INT;
DECLARE @IdOrden INT;
DECLARE @Lineas INT;
DECLARE @i INT;

WHILE @Contador <= @TotalOrdenes
BEGIN
    -- Cliente aleatorio
    SELECT TOP 1 @IdCliente = IdCliente
    FROM ventas.Cliente
    WHERE Activo = 1
    ORDER BY NEWID();

    -- Asesor aleatorio
    SELECT TOP 1 @IdAsesor = IdAsesorComercial
    FROM ventas.AsesorComercial
    WHERE Activo = 1
    ORDER BY NEWID();

    -- Crear orden
    INSERT INTO ventas.OrdenVenta
    (
        IdCliente,
        IdAsesorComercial,
        FechaOrden,
        Observaciones,
        EstadoOrden
    )
    VALUES
    (
        @IdCliente,
        @IdAsesor,
        DATEADD(DAY, -ABS(CHECKSUM(NEWID())) % 365, GETDATE()),
        'Venta generada para pruebas de rendimiento',
        'CREADA'
    );

    SET @IdOrden = SCOPE_IDENTITY();

    -- Número de líneas por orden (1 a 5)
    SET @Lineas = ABS(CHECKSUM(NEWID())) % 5 + 1;
    SET @i = 1;

    WHILE @i <= @Lineas
    BEGIN
        INSERT INTO ventas.LineaOrdenVenta
        (
            IdOrdenVenta,
            IdProducto,
            Cantidad,
            PrecioUnitario,
            Descuento
        )
        SELECT TOP 1
            @IdOrden,
            p.IdProducto,
            ABS(CHECKSUM(NEWID())) % 5 + 1,
            p.Precio,
            0
        FROM catalogo.Producto p
        WHERE p.Activo = 1
        ORDER BY NEWID();

        SET @i += 1;
    END;

    SET @Contador += 1;
END;
GO
