using Dapper;
using System.Data.Common;

namespace  GerenciadorUsuarioService.Infra.SQL.SqlCommand
{
    public class EnderecoSqlCommand
    {
        public DbTransaction _transaction;
        public string _sql = string.Empty;
        internal CommandDefinition GetCommandSelectByCEP(string cep)
        {
            _sql = @"SELECT 
                       [des_titulo] AS TITULO
                      ,[des_lograd] AS LOGRADOURO
                      ,[des_comple] AS COMPLEMENTO 
                      ,[des_bairro] AS BAIRRO
                      ,[des_munici] AS MUNICIPIONOME
                      ,[des_sigunf] AS UF
                      ,[nro_cep]	AS CEP
	                FROM 
                       [CEP] WITH (NOLOCK)
                    WHERE 
                       [NRO_CEP] = @CEP ";

            object param = new
            {
                @CEP = cep
            };

            return new CommandDefinition(_sql, parameters: param, transaction: this._transaction, commandType: System.Data.CommandType.Text);
        }
    }
}
