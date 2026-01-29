INSERT INTO ventas.Cliente
(
    IdPersona,
    NIT,
    Activo
)
SELECT
    p.IdPersona,
    CONCAT('CF-', p.IdPersona),
    1
FROM personas.Persona p
WHERE p.IdPersona <= 120;
GO

SELECT *
FROM ventas.Cliente