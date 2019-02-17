using System;
using System.Collections.Generic;
using YouLearn.Domain.Arguments.Base;
using YouLearn.Domain.Arguments.PlayList;
using YouLearn.Domain.Arguments.Video;

namespace YouLearn.Domain.Interfaces.Services
{
    public interface IServiceVideo : IServiceBase
    {
        AdicionarVideoResponse Adicionar(AdicionarVideoRequest adicionarVideoRequest, Guid idUsuario);
        IEnumerable<VideoResponse> Listar(string tags);
        IEnumerable<VideoResponse> Listar(Guid idPlayList);
    }
}
