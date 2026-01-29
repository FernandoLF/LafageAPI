CREATE OR ALTER PROCEDURE personas.spInsertarCliente
(
    @IdPersona INT,
    @NIT VARCHAR(20)
)
AS
BEGIN
    INSERT INTO ventas.Cliente (IdPersona, NIT, Activo)
    VALUES (@IdPersona, @NIT, 1);
END;
GO
