using GerenciadorUsuarioService.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace GerenciadorUsuarioService.Dominio.Interfaces
{
    public interface ICidadeRepository 
    {
        Cidade ObterCidadePorId(string id);
        IEnumerable<Cidade> ObterCidadePorUf(string uf);
        IEnumerable<Cidade> ObterTodos();
    }
}
