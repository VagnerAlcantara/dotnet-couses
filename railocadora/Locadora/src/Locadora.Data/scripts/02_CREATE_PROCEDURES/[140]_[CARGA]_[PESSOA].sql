USE TesteEntrevista
GO

if not exists (select top 1 * from Pessoa where Cpf = '35426992843')
begin
EXEC	[dbo].[PROC_CLIENTE_INSERT]
		@id = null,
		@cpf = N'35426992843',
		@nome = N'Vagner',
		@datanascimento = '1988/01/15',
		@telefone = N'11982320699',
		@email = N'vagneralcantara15@gmail.com',
		@matricula = 12345,
		@ativo = 1
end


--select * from Pessoa