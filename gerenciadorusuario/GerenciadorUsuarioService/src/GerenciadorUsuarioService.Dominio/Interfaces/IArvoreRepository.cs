using GerenciadorUsuarioService.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace GerenciadorUsuarioService.Dominio.Interfaces
{
    public interface IArvoreRepository 
    {
        Arvore ObterArvorePorId(string id);
        Arvore ObterArvorePorNome(string nome);
        IEnumerable<Arvore> ObterTodos();
    }
}
