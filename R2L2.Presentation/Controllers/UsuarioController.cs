using System;
using System.Web.Mvc;
using R2L2.Domain;
using R2L2.Infra;
using R2L2.Presentation.Models;

namespace R2L2.Presentation.Controllers
{
    public class UsuarioController : Controller
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

        public JsonResult Obter(string Login)
        {
            var usuario = new UsuarioModel().CriarModel(new Usuario().Obter(e => e.Login, Login, new Repositorio<Usuario>()));
            return Json(usuario, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Adicionar(UsuarioModel usuariomodel)
        {
            try
            {
                var usuarioDominio = usuariomodel.CriarDominio();
                usuarioDominio.Adicionar(new Repositorio<Usuario>());
                return Json(new { erro = false, mensagem = string.Format("Usuario {0} adicionado com sucesso!", usuariomodel.Nome) });
            }
            catch (System.Exception ex)
            {
                return Json(new { erro = true, mensagem = ex.Message });
            }
        }
        public JsonResult Atualizar(UsuarioModel usuariomodel)
        {
            try
            {
                var usuarioDominio = usuariomodel.CriarDominio();
                usuarioDominio.Atualizar(new Repositorio<Usuario>());
                return Json(new { erro = false, mensagem = string.Format("Usuario {0} atualizado!", usuariomodel.Nome) });
            }
            catch (System.Exception ex)
            {

                return Json(new { erro = true, mensagem = ex.Message });
            }
        }

        public JsonResult Apagar(UsuarioModel usuarioModel)
        {
            try
            {
                var usuarioDominio = usuarioModel.CriarDominio();
                usuarioDominio.Id = usuarioDominio.Obter(x => x.Login, usuarioModel.Login, new Repositorio<Usuario>()).Id;
                usuarioDominio.Apagar(new Repositorio<Usuario>());

                return Json(new { erro = false, Mensagem = string.Format("Usuário {0} apagado!",usuarioModel.Nome) });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    erro = true,
                    Mensagem = ex.Message
                });
            }
        }
        public ActionResult AdicionarUsuario()
        {
            return PartialView("Adicionar");
        }
    }
}
