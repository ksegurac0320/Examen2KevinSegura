-- =============================================
-- Author:        <Kevin Segura>
-- Create date: <15/04/22>
-- Description:    <Procedimiento  listar >
-- =============================================
CREATE PROCEDURE [dbo].[ServicioListar]
	AS
	BEGIN
	SET NOCOUNT ON
	SELECT 	IdServicio	,NombreServicio FROM dbo.Servicio
	END