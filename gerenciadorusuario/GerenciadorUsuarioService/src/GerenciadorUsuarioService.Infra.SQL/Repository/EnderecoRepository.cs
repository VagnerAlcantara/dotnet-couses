using GerenciadorUsuarioService.Dominio.Interfaces;
using GerenciadorUsuarioService.Infra.SQL.Database;
using System;
using System.Linq;
using Dapper;
using  GerenciadorUsuarioService.Infra.SQL.SqlCommand;

namespace GerenciadorUsuarioService.Infra.SQL.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        public Dominio.Entidades.Endereco ObterPorCep(string cep)
        {
            using (var cn = SqlDatabaseConnection.GetOpenConnectionCep())
            {
                try
                {
                    var result = cn.Query<Dominio.Entidades.Endereco>(new EnderecoSqlCommand().GetCommandSelectByCEP(cep));

                    if (result != null)
                        return result.Where(x => x.CEP.Count() == 8).FirstOrDefault();
                    else
                        return null;
                }
                catch (System.Exception ex)
                {
                    throw new Exception(string.Concat("Erro ao buscar endereço: ", ex.Message));
                }
            }
        }

      
    }
}
