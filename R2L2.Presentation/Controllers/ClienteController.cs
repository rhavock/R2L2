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

        public JsonResult Obter(string Cpf)
        {
            var cliente = new ClienteModel().CriarModel(new Cliente().Obter<int>(e => e.Cpf, Convert.ToInt32(Cpf), new Repositorio<Cliente>()));
            return Json(cliente, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Adicionar(ClienteModel cliente)
        {

            try
            {
                Cliente clienteDominio = cliente.CriarDominio();
                clienteDominio.Adicionar(new Repositorio<Cliente>());

                return Json(new { erro = false, Mensagem = string.Format("Cliente {0} Adicionado!", cliente.Nome) });
            }
            catch (Exception ex)
            {
                return Json(new { erro = true, Mensagem = ex.Message });
            }
        }

        public JsonResult Atualizar(ClienteModel cliente)
        {
            try
            {
                Cliente clienteDominio = cliente.CriarDominio();
                clienteDominio.Atualizar(new Repositorio<Cliente>());

                return Json(new { erro = false, Mensagem = string.Format("Cliente {0} Atualizado!", cliente.Nome) });
            }
            catch (Exception ex)
            {
                return Json(new { erro = true, Mensagem = ex.Message });
            }
        }

        public JsonResult Apagar(ClienteModel cliente)
        {
            try
            {
                Cliente clienteDominio = cliente.CriarDominio();
                clienteDominio.Id = clienteDominio.Obter(x=>x.Cpf,cliente.Cpf, new Repositorio<Cliente>()).Id;
                clienteDominio.Apagar(new Repositorio<Cliente>());

                return Json(new { erro = false, Mensagem = string.Format("Produto {0} Apagado!", cliente.Nome) });
            }
            catch (Exception ex)
            {
                return Json(new { erro = true, Mensagem = ex.Message });
            }
        }
    }
}
