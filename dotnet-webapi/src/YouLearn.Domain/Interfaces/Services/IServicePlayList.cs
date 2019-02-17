using System;
using System.Collections.Generic;
using YouLearn.Domain.Arguments.Base;
using YouLearn.Domain.Arguments.PlayList;

namespace YouLearn.Domain.Interfaces.Services
{
    public interface IServicePlayList : IServiceBase
    {
        IEnumerable<PlayListResponse> Listar(Guid idUsuario);
        PlayListResponse Adicionar(AdicionarPlayListRequest request, Guid idUsuario);
        ResponseBase Excluir(Guid id);
    }
}
