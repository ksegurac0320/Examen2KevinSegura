-- =============================================
-- Author:        <Kevin Segura>
-- Create date: <16/04/22>
-- Description:    <Procedimiento que actualiza >
-- =============================================
CREATE PROCEDURE [dbo].[SolicitudActualizar]
	@IdSolicitud INT,
	@IdCliente INT,
	@IdServicio INT,
	@Cantidad INT,
	@Monto DECIMAL(18,2),
	@FechaEntrega DATETIME,
	@UsuarioEntrega VARCHAR(50),
	@Observaciones VARCHAR(250)
AS
BEGIN
	SET NOCOUNT ON
	BEGIN TRANSACTION TRASA
		BEGIN TRY
			UPDATE dbo.Solicitud SET
				IdCliente= @IdCliente
				,IdServicio= @IdServicio
				,Cantidad=@Cantidad
				,Monto= @Monto
				,FechaEntrega= @FechaEntrega
				,UsuarioEntrega= @UsuarioEntrega
				,Observaciones= @Observaciones
			WHERE IdSolicitud = @IdSolicitud

			COMMIT TRANSACTION TRASA
			/*Si no hay error*/
			SELECT 0 AS CodeError, '' AS MsgError
		END TRY
		/*Si hay error*/
		BEGIN CATCH
			SELECT
				ERROR_NUMBER() AS CodeError,
				ERROR_MESSAGE() AS MsgError
			ROLLBACK TRANSACTION TRASA
		END CATCH


/*****/	
END