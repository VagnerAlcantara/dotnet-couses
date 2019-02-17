using System;
using System.Collections.Generic;
using YouLearn.Domain.Entities;

namespace YouLearn.Domain.Interfaces.Repositories
{
    public interface IRepositoryPlayList
    {
        IEnumerable<PlayList> Listar(Guid idUsuario);
        PlayList Obter(Guid id);
        PlayList Adicionar(PlayList playList);
        void Excluir(Guid id);
    }
}
