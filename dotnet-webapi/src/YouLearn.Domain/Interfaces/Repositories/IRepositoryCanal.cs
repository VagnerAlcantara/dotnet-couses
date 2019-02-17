using System;
using System.Collections.Generic;
using YouLearn.Domain.Entities;

namespace YouLearn.Domain.Interfaces.Repositories
{
    public interface IRepositoryCanal
    {
        Canal Obter(Guid id);
        IEnumerable<Canal> Listar(Guid idUsuario);
        Canal Adicionar(Canal canal);
        void Excluir(Guid id);
    }
}
