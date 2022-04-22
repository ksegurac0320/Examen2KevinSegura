-- =============================================
-- Author:        <Kevin Segura>
-- Create date: <15/04/22>
-- Description:    <Procedimiento que devuelve un listado >
-- =============================================
CREATE PROCEDURE [dbo].[ServicioObtener]
	@IdServicio INT = NULL
AS
BEGIN
	SET NOCOUNT ON
	SELECT
		IdServicio
		,NombreServicio
		,PlazoEntrega
		,CostoServicio
		,Estado
		,CuentaContable
	FROM dbo.Servicio
	WHERE (@IdServicio IS NULL OR IdServicio = @IdServicio)

/****/	
END
