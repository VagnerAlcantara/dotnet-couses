using System;
using System.Collections.Generic;
using YouLearn.Domain.Arguments.Base;
using YouLearn.Domain.Arguments.Canal;

namespace YouLearn.Domain.Interfaces.Services
{
    public interface IServiceCanal : IServiceBase
    {
        IEnumerable<CanalResponse> Listar(Guid idUsuario);
        CanalResponse Adicionar(AdicionarCanalRequest request, Guid idUsuario);
        ResponseBase Excluir(Guid idCanal);
    }
}
