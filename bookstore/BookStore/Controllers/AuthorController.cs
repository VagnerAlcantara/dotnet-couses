using BookStore.Domain;
using BookStore.Repositories.Contracts;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    [RoutePrefix("autores")]
    //[LogActionFilter]
    public class AuthorController : Controller
    {
        private IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [Route("listar")]
        public ActionResult Index()
        {
            var autores = _authorRepository.Get();

            return View(autores);
        }

        [Route("criar")]
        public ActionResult Create()
        {
            return View();
        }

        [Route("criar")]
        [HttpPost]
        public ActionResult Create(Autor autor)
        {
            if (_authorRepository.Create(autor))
                return RedirectToAction("Index");

            return View(autor);
        }

        [Route("editar/{id:int}")]
        public ActionResult Edit(int id)
        {
            var autor = _authorRepository.Get(id);

            return View(autor);
        }

        [Route("editar/{id:int}")]
        [HttpPost]
        public ActionResult Edit(Autor autor)
        {
            if (_authorRepository.Update(autor))
                return RedirectToAction("Index");

            return View(autor);
        }

        [Route("excluir/{id:int}")]
        public ActionResult Delete(int id)
        {
            var autor = _authorRepository.Get(id);

            return View(autor);
        }

        [Route("excluir/{id:int}")]
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            _authorRepository.Delete(id);

            return RedirectToAction("Index");
        }
    }
}