CREATE OR ALTER PROCEDURE personas.spInsertarVendedor
(
    @IdPersona INT,
    @Meta DECIMAL(10,2)
)
AS
BEGIN
    INSERT INTO ventas.Vendedor (IdPersona, Meta, Activo)
    VALUES (@IdPersona, @Meta, 1);
END;
GO
