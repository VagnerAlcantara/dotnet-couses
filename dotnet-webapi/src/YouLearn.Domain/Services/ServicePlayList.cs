using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using YouLearn.Domain.Arguments.Base;
using YouLearn.Domain.Arguments.Canal;
using YouLearn.Domain.Arguments.PlayList;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Resources;

namespace YouLearn.Domain.Services
{
    public class ServicePlayList : Notifiable, IServicePlayList
    {
        private readonly IRepositoryPlayList _repositoryPlayList;
        private readonly IRepositoryUsuario _repositoryUsuario;
        private readonly IRepositoryVideo _repositoryVideo;

        public ServicePlayList(IRepositoryUsuario repositoryUsuario, IRepositoryPlayList repositoryPlayList, IRepositoryVideo repositoryVideo)
        {
            _repositoryPlayList = repositoryPlayList;
            _repositoryUsuario = repositoryUsuario;
            _repositoryVideo = repositoryVideo;
        }

        public PlayListResponse Adicionar(AdicionarPlayListRequest request, Guid idUsuario)
        {
            if (request == null)
            {
                AddNotification("AdicionarPlayListRequest", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("AdicionarPlayListRequest"));
                return null;
            }

            if (idUsuario == null)
            {
                AddNotification("IdUsuario", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("IdUsuario"));
                return null;
            }

            var usuario = _repositoryUsuario.Obter(idUsuario);

            if (usuario == null)
            {
                AddNotification("Usuario", MSG.X0_INVALIDO.ToFormat("IdUsuario"));
                return null;
            }

            PlayList playList = new PlayList(request.Nome, usuario);

            AddNotifications(playList);

            if (IsInvalid())
                return null;

            playList = _repositoryPlayList.Adicionar(playList);

            return (PlayListResponse)playList;
        }

        public ResponseBase Excluir(Guid id)
        {
            if (id == null)
            {
                AddNotification("IdPlayList", MSG.X0_E_OBRIGATORIO.ToFormat("IdPlayList"));
                return null;
            }

            var playListExcluir = _repositoryPlayList.Obter(id);

            if (playListExcluir == null)
            {
                AddNotification("PlayList", MSG.X0_INVALIDO.ToFormat("IdPlayList"));
                return null;
            }

            bool existeVideoRelacionado = _repositoryVideo.ExistePlayListAssociado(id);
            if (existeVideoRelacionado)
            {
                AddNotification("PlayList", MSG.NAO_E_POSSIVEL_EXCLUIR_UMA_X0_ASSOCIADA_A_UMA_X1.ToFormat("PlayList", "Video"));
                return null;
            }

            _repositoryPlayList.Excluir(id);

            return new ResponseBase() { Mensagem = MSG.OPERACAO_REALIZADA_COM_SUCESSO };
        }

        public IEnumerable<PlayListResponse> Listar(Guid idUsuario)
        {
            IEnumerable<PlayList> playListCollection = _repositoryPlayList.Listar(idUsuario);

            var response = playListCollection.ToList().Select(x => (PlayListResponse)x);

            return response;
        }
    }
}