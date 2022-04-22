-- =============================================
-- Author:        <Kevin Segura>
-- Create date: <16/04/22>
-- Description:    <Procedimiento listar >
-- =============================================
CREATE PROCEDURE [dbo].[ClienteListar]
	AS
	BEGIN
	SET NOCOUNT ON
	SELECT 	IdCliente,Nombre,PrimerApellido,SegundoApellido FROM dbo.Cliente

	END
