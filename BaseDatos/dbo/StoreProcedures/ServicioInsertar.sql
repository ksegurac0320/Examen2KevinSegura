-- =============================================
-- Author:        <Kevin Segura>
-- Create date: <15/04/22>
-- Description:    <Procedimiento que inserta >
-- =============================================
CREATE PROCEDURE [dbo].[ServicioInsertar]
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
			INSERT INTO dbo.Servicio  /*Inserto en la base tabla Servicio... cont en values*/
			(
				NombreServicio
				,PlazoEntrega
				,CostoServicio
				,Estado
				,CuentaContable
			)
			VALUES
			(
				@NombreServicio
				,@PlazoEntrega
				,@CostoServicio
				,@Estado
				,@CuentaContable
			)

			COMMIT TRANSACTION TRASA
			/*si no hya error*/
			SELECT 0 AS CodeError, '' AS MsgError

		END TRY
		/*si hay error*/
		BEGIN CATCH
			SELECT
				ERROR_NUMBER() AS CodeError,
				ERROR_MESSAGE() AS MsgError
			ROLLBACK TRANSACTION TRASA
		END CATCH
/****/
END