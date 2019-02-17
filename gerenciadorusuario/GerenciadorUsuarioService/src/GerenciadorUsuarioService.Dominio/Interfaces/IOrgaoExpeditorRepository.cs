using GerenciadorUsuarioService.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace GerenciadorUsuarioService.Dominio.Interfaces
{
    public interface IOrgaoExpeditorRepository 
    {
        OrgaoExpeditor ObterOrgaoExpeditorPorId(string id);
        IEnumerable<OrgaoExpeditor> ObterTodos();
    }
}
