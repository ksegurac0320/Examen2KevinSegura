-- =============================================
-- Author:        <Kevin Segura>
-- Create date: <16/04/22>
-- Description:    <Procedimiento que inserta >
-- =============================================
CREATE PROCEDURE [dbo].[SolicitudInsertar]
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
			INSERT INTO dbo.Solicitud   /*Inserto en la base tabla Solicitud... cont en values*/
			(	IdCliente
				,IdServicio
				,Cantidad
				,Monto
				,FechaEntrega
				,UsuarioEntrega
				,Observaciones
			)
			VALUES /*Los valores...*/
			(	@IdCliente
				,@IdServicio
				,@Cantidad
				,@Monto
				,@FechaEntrega
				,@UsuarioEntrega
				,@Observaciones
			)

			COMMIT TRANSACTION TRASA
			/*Si no hay error*/
			SELECT 0 AS CodeError, '' AS MsgError
	END TRY
	/*Si  hay error*/
	BEGIN CATCH
			SELECT
				ERROR_NUMBER() AS CodeError,
				ERROR_MESSAGE() AS MsgError
			ROLLBACK TRANSACTION TRASA
	END CATCH

	/******/
END