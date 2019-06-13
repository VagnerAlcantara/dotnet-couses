USE [Teste]
GO
IF OBJECT_ID('dbo.P_NOVO_RECURSO') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.P_NOVO_RECURSO
    IF OBJECT_ID('dbo.P_NOVO_RECURSO') IS NOT NULL
        PRINT '<<< FALHA APAGANDO A PROCEDURE dbo.P_NOVO_RECURSO >>>'
    ELSE
        PRINT '<<< PROCEDURE dbo.P_NOVO_RECURSO APAGADA >>>'
END
go
SET QUOTED_IDENTIFIER ON
GO
SET NOCOUNT ON 
GO 
-- exec dbo.P_NOVO_RECURSO 
CREATE PROCEDURE dbo.P_NOVO_RECURSO 
AS
BEGIN
	SELECT
		nfi.Cfop,
		SUM(nfi.BaseIcms)		AS 'Valor Total da Base de ICMS',
		SUM(nfi.ValorIcms)		AS 'Valor Total do ICMS',
		SUM(nfi.BaseCalculoIpi) AS 'Valor Total da Base de IPI',
		SUM(nfi.ValorIpi)		AS 'Valor Total do IPI' 	 
	FROM
		[dbo].[NotaFiscal] nf
	inner join
		[dbo].[NotaFiscalItem] nfi on nf.Id = nfi.IdNotaFiscal
	--where
	--	nf.Id = 1010
	group by
		nfi.Cfop
	order by
		nfi.Cfop
END
GO
GRANT EXECUTE ON dbo.P_NOVO_RECURSO TO [public]
go
IF OBJECT_ID('dbo.P_NOVO_RECURSO') IS NOT NULL
    PRINT '<<< PROCEDURE dbo.P_NOVO_RECURSO CRIADA >>>'
ELSE
    PRINT '<<< FALHA NA CRIACAO DA PROCEDURE dbo.P_NOVO_RECURSO >>>'
go


