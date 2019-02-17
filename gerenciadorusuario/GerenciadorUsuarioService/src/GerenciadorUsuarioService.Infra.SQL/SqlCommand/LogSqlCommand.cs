using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  GerenciadorUsuarioService.Infra.SQL.SqlCommand
{
    public class LogSqlCommand
    {
        public DbTransaction _transaction;
        public string _sql = string.Empty;

        internal CommandDefinition GetCommandInsert(Dominio.Entidades.Log log)
        {

            _sql = @"INSERT INTO [dbo].[LOG_LDPMAN_MANAGER_LLMG]
                           ([LLMG_IDLDAP_RESPONSAVEL_ALTERACAO]
                           ,[LLMG_NM_RESPONSAVEL_ALTERACAO]
                           ,[LLMG_DT]
                           ,[LLMG_ID_ACAO]
                           ,[LLMG_IDLDAP_USUARIO_ALTERADO]
                           ,[LLMG_NM_USUARIO_ALTERADO]
                           ,[LLMG_RG_USUARIO_ALTERADO]
                           ,[LLMG_CPF_USUARIO_ALTERADO])
                     VALUES
                           (@LLMG_IDLDAP_RESPONSAVEL_ALTERACAO
                           ,@LLMG_NM_RESPONSAVEL_ALTERACAO
                           ,@LLMG_DT
                           ,@LLMG_ID_ACAO
                           ,@LLMG_IDLDAP_USUARIO_ALTERADO
                           ,@LLMG_NM_USUARIO_ALTERADO
                           ,@LLMG_RG_USUARIO_ALTERADO
                           ,@LLMG_CPF_USUARIO_ALTERADO)
                    SELECT  SCOPE_IDENTITY()";

            object param = new
            {
                @LLMG_IDLDAP_RESPONSAVEL_ALTERACAO = log.IdResponsavelAlteracao
                           ,
                @LLMG_NM_RESPONSAVEL_ALTERACAO = log.NomeResponsavelAlteracao
                           ,
                @LLMG_DT = DateTime.Now
                           ,
                @LLMG_ID_ACAO = log.LogAcaoId
                           ,
                @LLMG_IDLDAP_USUARIO_ALTERADO = log.IdUsuarioAlterado
                           ,
                @LLMG_NM_USUARIO_ALTERADO = log.NomeUsuarioAlterado
                           ,
                @LLMG_RG_USUARIO_ALTERADO = log.RgUsuarioAlterado
                           ,
                @LLMG_CPF_USUARIO_ALTERADO = log.CpfUsuarioAlterado
            };

            return new CommandDefinition(_sql, parameters: param, transaction: this._transaction, commandType: System.Data.CommandType.Text);
        }
        internal CommandDefinition GetCommandInsertCamposAlterados(Dominio.Entidades.LogCamposAlterados logCampos)
        {

            _sql = @"INSERT INTO [dbo].[LOG_LDPMAN_CAMPOS_ALTERADOS_LLCA]
                           ([CAAL_ID_LOG_LDPMAN_MANAGER]
                           ,[CAAL_CAMPO_ALTERADO]
                           ,[CAAL_VALOR_CAMPO_DE]
                           ,[CAAL_VALOR_CAMPO_PARA])
                     VALUES
                           (@CAAL_ID_LOG_LDPMAN_MANAGER
                           ,@CAAL_CAMPO_ALTERADO
                           ,@CAAL_VALOR_CAMPO_DE
                           ,@CAAL_VALOR_CAMPO_PARA)
                        
                    SELECT  SCOPE_IDENTITY()";

            object param = new
            {
                @CAAL_ID_LOG_LDPMAN_MANAGER = logCampos.IdLog
                           ,
                @CAAL_CAMPO_ALTERADO = logCampos.Campo
                           ,
                @CAAL_VALOR_CAMPO_DE = logCampos.De
                           ,
                @CAAL_VALOR_CAMPO_PARA = logCampos.Para
            };

            return new CommandDefinition(_sql, parameters: param, transaction: this._transaction, commandType: System.Data.CommandType.Text);
        }
        internal CommandDefinition GetCommandFilter(Dominio.Entidades.Log log)
        {
            _sql = @"SELECT    
                               [LLMG_ID]							AS Id
                              ,[LLMG_IDLDAP_RESPONSAVEL_ALTERACAO]	AS IdResponsavelAlteracao
                              ,[LLMG_NM_RESPONSAVEL_ALTERACAO]		AS NomeResponsavelAlteracao
                              ,[LLMG_DT]							AS DataAcao
                              ,[LLMG_ID_ACAO]						AS LogAcaoId
                              ,[LLMG_IDLDAP_USUARIO_ALTERADO]		AS IdUsuarioAlterado
                              ,[LLMG_NM_USUARIO_ALTERADO]			AS NomeUsuarioAlterado
                              ,[LLMG_CPF_USUARIO_ALTERADO]	 		AS CpfUsuarioAlterado
                              ,[LLMG_RG_USUARIO_ALTERADO]			AS RgUsuarioAlterado
                          FROM [dbo].[LOG_LDPMAN_MANAGER_LLMG] LLMG WITH (NOLOCK)
                          WHERE
		                        (
			                        ([LLMG_IDLDAP_USUARIO_ALTERADO] = (SELECT CONVERT(INT, @IDLDAP)))
			                        OR
			                        (@IDLDAP IS NULL)
	                            )
	                        AND
	                           (
			                        ([LLMG_NM_USUARIO_ALTERADO] LIKE '%'+ @NOME +'%')
			                        OR
			                        (@NOME IS NULL)
	                            )
	                        AND
		                        (
			                        ([LLMG_CPF_USUARIO_ALTERADO] = @CPF)
			                        OR
			                        (@CPF IS NULL)
	                            )
	                        AND
		                        (
			                        ([LLMG_RG_USUARIO_ALTERADO] = @RG)
			                        OR
			                        (@RG IS NULL)
	                            )
                            AND
		                        (
			                        ((SELECT CONVERT(DATE, LLMG_DT, 103)) >= (SELECT CONVERT(DATE, @DTINICIO, 103)))
			                        OR
			                        (@DTINICIO IS NULL)
	                            )

	                        AND
		                        (
			                        ((SELECT CONVERT(DATE, [LLMG_DT], 103)) <= (SELECT CONVERT(DATE, @DTFIM, 103)))
			                        OR
			                        (@DTFIM IS NULL)
	                            )
                            AND
								(
									([LLMG_ID_ACAO] = @IDACAO)
									OR
									(@IDACAO IS NULL)
								)
                  ";
            object param = new
         {
             @IDLDAP = log.IdUsuarioAlterado,
             @NOME = log.NomeUsuarioAlterado,
             @CPF = log.CpfUsuarioAlterado,
             @RG = log.RgUsuarioAlterado,
             @DTINICIO = String.IsNullOrEmpty(log.DtInicio) ? null : log.DtInicio,
             @DTFIM = String.IsNullOrEmpty(log.DtFim) ? null : log.DtFim,
             @IDACAO = log.LogAcaoId,
    
         };
            return new CommandDefinition(_sql, parameters: param, transaction: this._transaction, commandType: System.Data.CommandType.Text);
        }
        internal CommandDefinition GetCommandSelectAll()
        {
            _sql = @"SELECT    
                               [LLMG_ID]							AS Id
                              ,[LLMG_IDLDAP_RESPONSAVEL_ALTERACAO]	AS IdResponsavelAlteracao
                              ,[LLMG_NM_RESPONSAVEL_ALTERACAO]		AS NomeResponsavelAlteracao
                              ,[LLMG_DT]							AS DataAcao
                              ,[LLMG_ID_ACAO]						AS LogAcaoId
                              ,[LLMG_IDLDAP_USUARIO_ALTERADO]		AS IdUsuarioAlterado
                              ,[LLMG_NM_USUARIO_ALTERADO]			AS NomeUsuarioAlterado
                              ,[LLMG_CPF_USUARIO_ALTERADO]	 		AS CpfUsuarioAlterado
                              ,[LLMG_RG_USUARIO_ALTERADO]			AS RgUsuarioAlterado
                          FROM [dbo].[LOG_LDPMAN_MANAGER_LLMG] LLMG WITH (NOLOCK)";

            return new CommandDefinition(_sql, null, transaction: this._transaction, commandType: System.Data.CommandType.Text);
        }
        internal CommandDefinition GetCommandCamposAlteradosByIdLog(int idLog)
        {
            _sql = @"SELECT 
	                   [CAAL_ID]					AS Id
                      ,[CAAL_ID_LOG_LDPMAN_MANAGER]	AS IdLog
                      ,[CAAL_CAMPO_ALTERADO]		AS Campo
                      ,[CAAL_VALOR_CAMPO_DE]		AS De
                      ,[CAAL_VALOR_CAMPO_PARA]		AS Para
                  FROM 
	                [dbo].[LOG_LDPMAN_CAMPOS_ALTERADOS_LLCA] WITH (NOLOCK)
                  WHERE
	                [CAAL_ID_LOG_LDPMAN_MANAGER] = @CAAL_ID_LOG_LDPMAN_MANAGER";
           
            object param = new
            {
                @CAAL_ID_LOG_LDPMAN_MANAGER = idLog
            };
            return new CommandDefinition(_sql, parameters: param, transaction: this._transaction, commandType: System.Data.CommandType.Text);
        }
        
        
    }
}
