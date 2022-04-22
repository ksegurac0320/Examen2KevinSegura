-- =============================================
-- Author:        <Kevin Segura>
-- Create date: <16/04/22>
-- Description:    <Procedimiento que inserta >
-- =============================================
CREATE PROCEDURE [dbo].[ClienteInsertar]
	@Identificacion VARCHAR (128),
	@IdTipoIdentificacion INT,
	@Nombre VARCHAR (128),
	@PrimerApellido VARCHAR (128),
	@SegundoApellido VARCHAR (128),
	@FechaNacimiento DATETIME,
	@Nacionalidad INT,
	@FechaDefuncion DATETIME,
	@Genero CHAR (1),
	@NombreApellidosPadre VARCHAR (200),
	@NombreApellidosMadre VARCHAR (200),
	@Pasaporte VARCHAR (50),
	@CuentaIBAN VARCHAR(50),
	@CorreoNotifica VARCHAR(128)
AS 
BEGIN
	SET NOCOUNT ON
	BEGIN TRANSACTION TRASA
		BEGIN TRY
			INSERT INTO dbo.Cliente  /*Inserto en la base tabla Cliente... cont en values*/
			(	Identificacion
				,IdTipoIdentificacion
				,Nombre
				,PrimerApellido
				,SegundoApellido
				,FechaNacimiento
				,Nacionalidad 
				,FechaDefuncion
				,Genero
				,NombreApellidosPadre
				,NombreApellidosMadre
				,Pasaporte
				,CuentaIBAN
				,CorreoNotifica
			)
			VALUES
			(
				@Identificacion
				,@IdTipoIdentificacion
				,@Nombre
				,@PrimerApellido
				,@SegundoApellido
				,@FechaNacimiento
				,@Nacionalidad
				,@FechaDefuncion
				,@Genero
				,@NombreApellidosPadre
				,@NombreApellidosMadre
				,@Pasaporte
				,@CuentaIBAN
				,@CorreoNotifica
			)
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

/***/
END
