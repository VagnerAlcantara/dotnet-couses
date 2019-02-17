using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Interfaces.Transactions;

namespace YouLearn.API.Controllers.Base
{
    public class YouLearnBaseController : Controller
    {
        private readonly IUnitOfWork _unityOfWork;
        private IServiceBase _serviceBase;

        public YouLearnBaseController(IUnitOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public async Task<IActionResult> ResponseAsync(object result, IServiceBase serviceBase)
        {
            _serviceBase = serviceBase;

            if (!serviceBase.Notifications.Any())
            {
                try
                {
                    _unityOfWork.Commit();

                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o administrador - Error:" + ex.Message);
                }
            }
            else
            {
                return BadRequest(new { errors = serviceBase.Notifications });
            }
        }

        public async Task<IActionResult> ResponseExceptionAsync(Exception ex)
        {
            return BadRequest(new { errors = ex.Message, exception = ex.ToString() });
        }

        protected override void Dispose(bool disposing)
        {
            if (_serviceBase != null)
            {
                _serviceBase.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
