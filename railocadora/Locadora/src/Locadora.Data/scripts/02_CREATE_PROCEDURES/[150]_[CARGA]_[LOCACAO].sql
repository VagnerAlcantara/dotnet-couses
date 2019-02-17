USE TesteEntrevista
GO

IF NOT EXISTS (SELECT TOP 1 * FROM LOCACAO WHERE IDFILME = 1 AND IDCLIENTE = 1)
BEGIN
INSERT INTO [dbo].[Locacao]
           ([IdFilme]
           ,[IdCliente]
           ,[DataRetirada]
           ,[DataEntrega])
     VALUES
           (1
           ,1
           ,GETDATE()
           ,GETDATE() + 5)
END
GO
IF NOT EXISTS (SELECT TOP 1 * FROM LOCACAO WHERE IDFILME = 2 AND IDCLIENTE = 1)
BEGIN
INSERT INTO [dbo].[Locacao]
           ([IdFilme]
           ,[IdCliente]
           ,[DataRetirada]
           ,[DataEntrega])
     VALUES
           (2
           ,1
           ,GETDATE()
           ,GETDATE() + 5)
END
GO


--SELECT * FROM LOCACAO 


