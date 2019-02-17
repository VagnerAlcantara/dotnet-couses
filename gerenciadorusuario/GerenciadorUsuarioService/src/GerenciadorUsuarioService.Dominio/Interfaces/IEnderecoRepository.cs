using GerenciadorUsuarioService.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace GerenciadorUsuarioService.Dominio.Interfaces
{
    public interface IEnderecoRepository 
    {
        Endereco ObterPorCep(string cep);

    }
}
