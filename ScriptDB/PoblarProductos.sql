DECLARE @Linea INT;
DECLARE @i INT = 1;

WHILE @i <= 100
BEGIN
    SELECT TOP 1 @Linea = IdLineaProducto
    FROM catalogo.LineaProducto
    WHERE Activo = 1
    ORDER BY NEWID();

    INSERT INTO catalogo.Producto
    (
        IdLineaProducto,
        Descripcion,
        Stock,
        FechaProduccion,
        Precio,
        Activo
    )
    VALUES
    (
        @Linea,
        CONCAT('Producto ', @i),
        100 + (@i * 2),
        DATEADD(DAY, -@i, GETDATE()),
        50 + (@i * 3),
        1
    );

    SET @i += 1;
END;
GO
