-- =============================================
-- Author:        <Kevin Segura>
-- Create date: <16/04/22>
-- Description:    <Procedimiento que devuelve un listado especifico >
-- =============================================
CREATE PROCEDURE [dbo].[SolicitudObtener]
	@IdSolicitud INT = NULL
AS
BEGIN
	SET NOCOUNT ON

	SELECT
		S.IdSolicitud 
		,S.Cantidad
		,S.Monto
		,S.FechaEntrega
		,S.UsuarioEntrega
		,S.Observaciones
		,C.IdCliente
		,C.Nombre
		,C.PrimerApellido
		,C.SegundoApellido
		,E.IdServicio
		,E.NombreServicio


	FROM
		dbo.Solicitud S  /*Se les nombra con una mayuscula para llamar lo que se necesita de otra tabla y saber de que tabla es en el select (visto en estructura)*/
		INNER JOIN dbo.Cliente C
			ON S.IdCliente = C.IdCliente
		INNER JOIN dbo.Servicio E
			ON S.IdServicio = E.IdServicio
	WHERE (@IdSolicitud IS NULL OR S.IdSolicitud = @IdSolicitud)

/*****/
END
