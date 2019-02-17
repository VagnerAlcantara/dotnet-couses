using GerenciadorUsuarioService.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace GerenciadorUsuarioService.Dominio.Interfaces
{
    public interface IInstituicaoOrigemRepository 
    {
        InstituicaoOrigem ObterInstituicaoOrigemPorId(int id);
        IEnumerable<InstituicaoOrigem> ObterTodos();
    }
}
