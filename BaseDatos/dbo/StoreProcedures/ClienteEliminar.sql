-- =============================================
-- Author:        <Kevin Segura>
-- Create date: <16/04/22>
-- Description:    <Procedimiento que elimina >
-- =============================================
CREATE PROCEDURE [dbo].[ClienteEliminar]
	@IdCliente INT
AS 
BEGIN
	SET NOCOUNT ON
	BEGIN TRANSACTION TRASA
		BEGIN TRY

			DELETE FROM dbo.Cliente WHERE IdCliente=@IdCliente

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


/******/
END
