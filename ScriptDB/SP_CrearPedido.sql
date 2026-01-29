CREATE OR ALTER PROCEDURE ventas.spCrearPedido
(
    @IdCliente INT,
    @IdVendedor INT,
    @IdProducto INT,
    @Cantidad INT,
    @PrecioUnitario DECIMAL(10,2),
    @Descuento DECIMAL(10,2) = 0
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @StockActual INT;
        DECLARE @IdPedido INT;

        -- 1️ Validar stock
        SELECT @StockActual = Stock
        FROM catalogo.Producto
        WHERE IdProducto = @IdProducto
          AND Activo = 1;

        IF @StockActual IS NULL
        BEGIN
            RAISERROR('Producto no existe o está inactivo.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        IF @StockActual < @Cantidad
        BEGIN
            RAISERROR('Stock insuficiente para completar la venta.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- 2️ Crear pedido (Aggregate Root)
        INSERT INTO ventas.Pedido
        (
            IdCliente,
            IdVendedor,
            Fecha,
            Estado,
            Descripcion
        )
        VALUES
        (
            @IdCliente,
            @IdVendedor,
            GETDATE(),
            'CREADO',
            'Pedido generado desde SP'
        );

        SET @IdPedido = SCOPE_IDENTITY();

        --3️Insertar detalle
        INSERT INTO ventas.DetallePedido
        (
            IdPedido,
            IdProducto,
            Cantidad,
            PrecioUnitario,
            Descuento
        )
        VALUES
        (
            @IdPedido,
            @IdProducto,
            @Cantidad,
            @PrecioUnitario,
            @Descuento
        );

        --4️Descontar stock
        UPDATE catalogo.Producto
        SET Stock = Stock - @Cantidad
        WHERE IdProducto = @IdProducto;

        --5️Confirmar pedido
        UPDATE ventas.Pedido
        SET Estado = 'CONFIRMADO'
        WHERE IdPedido = @IdPedido;

        COMMIT TRANSACTION;

        --6️Resultado
        SELECT 
            @IdPedido AS IdPedido,
            'Pedido creado correctamente' AS Mensaje;

    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();

        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO
