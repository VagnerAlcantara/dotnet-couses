using Dapper;
using GerenciadorUsuarioService.Infra.SQL.Database;
using System;
using System.Linq;
using  GerenciadorUsuarioService.Infra.SQL.SqlCommand;
using GerenciadorUsuarioService.Dominio.Interfaces;
namespace GerenciadorUsuarioService.Infra.SQL.Repository
{
    public class OrgaoExpeditorRepository : IOrgaoExpeditorRepository
    {
        public Dominio.Entidades.OrgaoExpeditor ObterOrgaoExpeditorPorId(string id)
        {
            using (var cn = SqlDatabaseConnection.GetOpenConnectionGestaoCorp())
            {
                try
                {
                    return cn.Query<Dominio.Entidades.OrgaoExpeditor>(new OrgaoExpeditorSqlCommand().GetCommandSelectById(id)).FirstOrDefault();
                }
                catch (System.Exception ex)
                {
                    throw new Exception(string.Concat("Erro ao obter orgão expeditor: ", ex.Message));
                }
            }
        }

        public System.Collections.Generic.IEnumerable<Dominio.Entidades.OrgaoExpeditor> ObterTodos()
        {
            using (var cn = SqlDatabaseConnection.GetOpenConnectionGestaoCorp())
            {
                try
                {
                    var result = cn.Query<Dominio.Entidades.OrgaoExpeditor>(new OrgaoExpeditorSqlCommand().GetCommandSelectAll());

                    var sortedList = result
                    .OrderBy(i => i.Nome == "Outros")
                    .ThenBy(i => i.Nome == "MRE")
                    .ThenBy(i => i.Nome == "MEX")
                    .ThenBy(i => i.Nome == "MD")
                    .ThenBy(i => i.Nome == "MAR")
                    .ThenBy(i => i.Nome == "MAE")
                    .ThenBy(i => i.Nome == "SSP")


                    .ToList();
                    return sortedList;
                }
                catch (System.Exception ex)
                {
                    throw new Exception(string.Concat("Erro ao obter orgão expeditor: ", ex.Message));
                }
            }
        }
    }
}
