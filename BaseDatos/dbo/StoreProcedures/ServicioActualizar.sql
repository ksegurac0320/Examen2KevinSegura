-- =============================================
-- Author:        <Kevin Segura>
-- Create date: <15/04/22>
-- Description:    <Procedimiento que actualiza >
-- =============================================
CREATE PROCEDURE [dbo].[ServicioActualizar]
	@IdServicio INT,
	@NombreServicio VARCHAR(128),
	@PlazoEntrega INT,
	@CostoServicio DECIMAL(18, 2),
	@Estado BIT,
	@CuentaContable VARCHAR(50) 

AS 
BEGIN
	SET NOCOUNT ON
	BEGIN TRANSACTION TRASA
		BEGIN TRY

			UPDATE dbo.Servicio SET
				NombreServicio = @NombreServicio
				,PlazoEntrega = @PlazoEntrega
				,CostoServicio = @CostoServicio
				,Estado = @Estado
				,CuentaContable = @CuentaContable
			WHERE IdServicio = @IdServicio

			COMMIT TRANSACTION TRASA
			/*si no hay error*/
			SELECT 0 AS CodeError, '' AS MsgError

		END TRY
		/*di hay error*/
		BEGIN CATCH
			SELECT
				ERROR_NUMBER() AS CodeError,
				ERROR_MESSAGE() AS MsgError
			ROLLBACK TRANSACTION TRASA
		END CATCH
/****/
END