using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using R2L2.Domain;
using R2L2.Infra;
using R2L2.Presentation.Models;

namespace R2L2.Presentation.Controllers
{
    public class ClienteController:Controller
    {
      
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Listar()
        {
            var clientes = new ClienteModel().CriarModel(new Cliente().Listar(new Repositorio<Cliente>()));
            return Json(clientes, JsonRequestBehavior.AllowGet);
        }
    }
}
