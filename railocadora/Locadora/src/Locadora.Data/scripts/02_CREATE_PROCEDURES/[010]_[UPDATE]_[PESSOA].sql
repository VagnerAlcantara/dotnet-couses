use TesteEntrevista
GO

IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'PROC_PESSOA_UPDATE')
                    AND type IN ( N'P', N'PC' ) ) 
BEGIN
	DROP PROCEDURE PROC_PESSOA_UPDATE;
END
GO

CREATE PROCEDURE PROC_PESSOA_UPDATE 
	@id int,
	@cpf varchar(15),
	@nome  varchar(100),
	@datanascimento date,
	@telefone varchar(20),
	@email varchar(50)
AS
BEGIN
	
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	
	BEGIN TRY
		
		BEGIN TRANSACTION;

		-- INSTRUÇÕES SQL -- INÍCIO
		UPDATE [dbo].[Pessoa]
		   SET [Cpf] = @cpf
			  ,[Nome] = @Nome
			  ,[DataNascimento] = @DataNascimento
			  ,[Telefone] = @Telefone
			  ,[Email] = @Email
		 WHERE 
			id = @id

		-- INSTRUÇÕES SQL -- FIM
		
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