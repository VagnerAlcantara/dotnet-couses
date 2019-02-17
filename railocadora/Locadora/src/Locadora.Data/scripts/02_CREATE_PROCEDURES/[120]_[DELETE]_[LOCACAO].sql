use TesteEntrevista
GO

IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'PROC_LOCACAO_DELETE')
                    AND type IN ( N'P', N'PC' ) ) 
BEGIN
	DROP PROCEDURE PROC_LOCACAO_DELETE;
END
GO

CREATE PROCEDURE PROC_LOCACAO_DELETE
	@id int
AS
BEGIN
	
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	
	BEGIN TRY
		
		BEGIN TRANSACTION;

		-- INSTRU��ES SQL -- IN�CIO
		DELETE FROM [dbo].[Locacao]
		 WHERE 
			id = @id

		-- INSTRU��ES SQL -- FIM
		
		IF @@TRANCOUNT > 0 COMMIT TRANSACTION;
		
	END TRY
	
	BEGIN CATCH
		
		IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
		
		DECLARE @ERRORMESSAGE NVARCHAR(4000);
		DECLARE @ERRORSEVERITY INT;
		DECLARE @ERRORSTATE INT;

		SELECT @ERRORMESSAGE = ERROR_MESSAGE(),
			   @ERRORSEVERITY = ERROR_SEVERITY(),
			   @ERRORSTATE = ERROR_STATE();

		RAISERROR (@ERRORMESSAGE,
				   @ERRORSEVERITY,
				   @ERRORSTATE
				   );
			
	END CATCH
END