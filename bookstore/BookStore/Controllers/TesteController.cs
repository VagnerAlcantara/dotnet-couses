using BookStore.Filters;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    [RoutePrefix("teste")]
    [Route("{action=MinhaAction3}")]// Trocando a action padrão index, por MinhaAction3
    [LogActionFilter]
    public class TesteController : Controller
    {
        public string Index()
        {
            return "Index";
        }
        [Route("minharota/{id?}")]
        public string MinhaAction(int? id)
        {
            if (id.HasValue)
                return $"OK! - {id}";
            else
                return $"OK!";
        }

        //Ignorando route prefix
        [Route("~/minharotaignorada")]
        public string MinhaAction2()
        {
            return $"OK!";
        }

        //Ignorando route prefix
        [Route("MinhaAction3")]
        [HttpGet]
        public string MinhaAction3()
        {
            return $"OK!";
        }
    }
}