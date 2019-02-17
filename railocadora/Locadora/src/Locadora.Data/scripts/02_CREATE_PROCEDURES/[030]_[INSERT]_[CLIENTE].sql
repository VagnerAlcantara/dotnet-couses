use TesteEntrevista
GO

IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'PROC_CLIENTE_INSERT')
                    AND type IN ( N'P', N'PC' ) ) 
BEGIN
	DROP PROCEDURE PROC_CLIENTE_INSERT;
END
GO

CREATE PROCEDURE PROC_CLIENTE_INSERT 
	@id int output,
	@cpf varchar(15) ,
	@nome  varchar(100),
	@datanascimento date = null,
	@telefone varchar(20),
	@email varchar(50),
	@matricula int,
	@ativo bit
AS
BEGIN
	
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	
	BEGIN TRY
		
		BEGIN TRANSACTION;

		-- INSTRUÇÕES SQL -- INÍCIO

		declare @idpessoa int;


		EXEC [PROC_PESSOA_INSERT] @idpessoa output, @cpf, @nome, @datanascimento, @telefone, @email
		

		INSERT INTO [dbo].[Cliente]
				   ([Matricula]
				   ,[Ativo]
				   ,[IdPessoa])
			 VALUES
				   (@matricula
				   ,@ativo
				   ,@idpessoa)

		SELECT @id = SCOPE_IDENTITY();

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