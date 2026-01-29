CREATE OR ALTER PROCEDURE personas.spActualizarCliente
(
    @IdCliente INT,
    @NIT VARCHAR(20),
    @Activo BIT
)
AS
BEGIN
    UPDATE ventas.Cliente
    SET NIT = @NIT,
        Activo = @Activo
    WHERE IdCliente = @IdCliente;
END;
GO
