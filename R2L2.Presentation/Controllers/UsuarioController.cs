using System.Web.Mvc;
using R2L2.Domain;
using R2L2.Infra;
using R2L2.Presentation.Models;

namespace R2L2.Presentation.Controllers
{
    public class UsuarioController:Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Listar()
        {
            var usuarios = new UsuarioModel().CriarModel(new Usuario().Listar(new Repositorio<Usuario>()));
            return Json(usuarios, JsonRequestBehavior.AllowGet);
        }
    }    
}
