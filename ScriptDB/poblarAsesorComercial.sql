INSERT INTO ventas.AsesorComercial
(
    IdPersona,
    Meta,
    Activo
)
SELECT
    p.IdPersona,
    10000 + (p.IdPersona * 50),
    1
FROM personas.Persona p
WHERE p.IdPersona BETWEEN 121 AND 150;
GO

SELECT * 
FROM ventas.AsesorComercial