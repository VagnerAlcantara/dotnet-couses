using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using YouLearn.API.Controllers.Base;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Arguments.Video;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Interfaces.Transactions;

namespace YouLearn.API.Controllers
{
    public class VideoController : YouLearnBaseController
    {
        private readonly IServiceVideo _serviceVideo;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public VideoController(IUnitOfWork unityOfWork, IServiceVideo serviceVideo, IHttpContextAccessor httpContextAccessor)
            : base(unityOfWork)
        {
            _serviceVideo = serviceVideo;
            _httpContextAccessor = httpContextAccessor;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/v1/Video/Listar/{tags}")]
        public async Task<IActionResult> Listar(string tags)
        {
            try
            {
                var response = _serviceVideo.Listar(tags);

                return await ResponseAsync(response, _serviceVideo);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/v1/Video/Listar/{id:Guid}")]
        public async Task<IActionResult> Listar(Guid id)
        {
            try
            {
                var response = _serviceVideo.Listar(id);

                return await ResponseAsync(response, _serviceVideo);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [HttpPost]
        [Route("api/v1/Video/Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] AdicionarVideoRequest request)
        {
            try
            {
                var usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;

                AutenticarUsuarioResponse autenticarUsuarioResponse = JsonConvert.DeserializeObject<AutenticarUsuarioResponse>(usuarioClaims);

                var response = _serviceVideo.Adicionar(request, autenticarUsuarioResponse.Id);

                return await ResponseAsync(response, _serviceVideo);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}