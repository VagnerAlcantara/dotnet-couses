using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using YouLearn.API.Controllers.Base;
using YouLearn.Domain.Arguments.Canal;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Interfaces.Transactions;

namespace YouLearn.API.Controllers
{
    //[Produces("application/json")]
    //[Route("api/v1/Canal")]
    public class CanalController : YouLearnBaseController
    {
        private readonly IServiceCanal _serviceCanal;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CanalController(IUnitOfWork unityOfWork, IServiceCanal serviceCanal, IHttpContextAccessor httpContextAccessor)
            : base(unityOfWork)
        {
            _serviceCanal = serviceCanal;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [Route("api/v1/Canal/Listar")]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;

                AutenticarUsuarioResponse autenticarUsuarioResponse = JsonConvert.DeserializeObject<AutenticarUsuarioResponse>(usuarioClaims);

                var response = _serviceCanal.Listar(autenticarUsuarioResponse.Id);

                return await ResponseAsync(response, _serviceCanal);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [HttpPost]
        [Route("api/v1/Canal/Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] AdicionarCanalRequest request)
        {
            try
            {
                var usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;

                AutenticarUsuarioResponse autenticarUsuarioResponse = JsonConvert.DeserializeObject<AutenticarUsuarioResponse>(usuarioClaims);

                var response = _serviceCanal.Adicionar(request, autenticarUsuarioResponse.Id);

                return await ResponseAsync(response, _serviceCanal);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [HttpDelete]
        [Route("api/v1/Canal/Excluir/{id:Guid}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            try
            {
                var response = _serviceCanal.Excluir(id);

                return await ResponseAsync(response, _serviceCanal);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}