DECLARE @i INT = 1;

WHILE @i <= 200
BEGIN
    INSERT INTO personas.Persona
    (
        Nombre,
        Apellido,
        Direccion,
        FechaRegistro
    )
    VALUES
    (
        CONCAT('Nombre', @i),
        CONCAT('Apellido', @i),
        CONCAT('Direccion', @i),
        DATEADD(YEAR, -25 - (@i % 20), GETDATE())
    );

    SET @i += 1;
END;
GO

SELECT *
FROM personas.Persona