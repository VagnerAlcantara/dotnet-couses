
using GerenciadorUsuarioService.Dominio.Entidades;
using System;
using System.Collections.Generic;
namespace GerenciadorUsuarioService.Dominio.Interfaces
{
    public interface IEstadoRepository 
    {
        Estado ObterEstadorPorUf(string uf);
        IEnumerable<Estado> ObterTodos();
    }
}
