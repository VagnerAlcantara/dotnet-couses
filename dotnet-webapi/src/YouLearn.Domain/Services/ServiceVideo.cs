using System;
using System.Collections.Generic;
using System.Linq;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using YouLearn.Domain.Arguments.Base;
using YouLearn.Domain.Arguments.Canal;
using YouLearn.Domain.Arguments.Video;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Enum;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Resources;

namespace YouLearn.Domain.Services
{
    public class ServiceVideo : Notifiable, IServiceVideo
    {
        private readonly IRepositoryUsuario _repositoryUsuario;
        private readonly IRepositoryVideo _repositoryVideo;
        private readonly IRepositoryCanal _repositoryCanal;
        private readonly IRepositoryPlayList _repositoryPlayList;

        public ServiceVideo(
            IRepositoryUsuario repositoryUsuario,
            IRepositoryVideo repositoryVideo,
            IRepositoryCanal repositoryCanal,
            IRepositoryPlayList repositoryPlayList)
        {
            _repositoryUsuario = repositoryUsuario;
            _repositoryVideo = repositoryVideo;
            _repositoryCanal = repositoryCanal;
            _repositoryPlayList = repositoryPlayList;
        }

        public AdicionarVideoResponse Adicionar(AdicionarVideoRequest request, Guid idUsuario)
        {
            if (request == null)
            {
                AddNotification("AdicionarVideoRequest", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("AdicionarVideoRequest"));
                return null;
            }

            Usuario usuario = _repositoryUsuario.Obter(idUsuario);

            if (usuario == null)
            {
                AddNotification("IdUsuario", MSG.X0_INVALIDO.ToFormat("IdUsuario"));
                return null;
            }

            Canal canal = _repositoryCanal.Obter(request.IdCanal);

            if (canal == null)
            {
                AddNotification("IdCanal", MSG.X0_INVALIDO.ToFormat("IdCanal"));
                return null;
            }

            PlayList playList = null;
            if (request.IdPlayList != Guid.Empty)
            {
                playList = _repositoryPlayList.Obter(request.IdPlayList);

                if (playList == null)
                {
                    AddNotification("IdPlayList", MSG.X0_INVALIDO.ToFormat("IdPlayList"));
                    return null;
                }
            }

            var video = new Video(
                canal,
                playList,
                request.Titulo,
                request.Descricao,
                request.Tags,
                request.OrdemNaPlayList,
                request.IdVideoYoutube,
                usuario);

            AddNotifications(video);

            if (IsInvalid())
                return null;

            _repositoryVideo.Adicionar(video);

            return new AdicionarVideoResponse() { Id = video.Id };
        }

        public IEnumerable<VideoResponse> Listar(string tags)
        {
            IEnumerable<Video> videos = _repositoryVideo.Listar(tags);

            var response = videos.ToList().Select(x => (VideoResponse)x);

            return response;
        }

        public IEnumerable<VideoResponse> Listar(Guid idPlayList)
        {
            IEnumerable<Video> videos = _repositoryVideo.Listar(idPlayList);

            var response = videos.ToList().Select(x => (VideoResponse)x);

            return response;
        }
    }
}
