using Dapper;
using GerenciadorUsuarioService.Dominio.Entidades;

namespace GerenciadorUsuarioService.Infra.SQL.Interfaces
{
    public interface IUsuarioSqlCommand
    {
        CommandDefinition GetCommandInsert(Usuario usuario);
        CommandDefinition GetCommandUpdate(Usuario usuario);
        CommandDefinition GetCommandDelete(string idLdap);
        CommandDefinition GetCommandResetarSenha(string idLdap, string cpf);

        CommandDefinition GetCommandSelectByIdLdap(string idLdap);

        CommandDefinition GetCommandSelectFiltro(Usuario usuario);

        CommandDefinition GetCommandSelectFiltro(Usuario usuario, Op operador);
        CommandDefinition GetCommandSelectFiltroWithPassword(Usuario usuario);

        CommandDefinition GetCommandSelectByCpf(string cpf);
        CommandDefinition GetCommandSelectByCpfWithPassword(string cpf);

        CommandDefinition GetCommandSelectByNameWithPassword(string name);

        CommandDefinition GetCommandValidaRgCpf(string rg, string cpf, string idLdap, string email);
        CommandDefinition GetCommandAtualizarSenha(string idLdap, string senha);
    }
}
