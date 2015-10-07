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
    public class ProdutoController:Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Listar()
        {
            var produtos = new ProdutoModel().CriarModel(new Produto().Listar(new Repositorio<Produto>()));
            return Json(produtos, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Obter(string CodigoBarras)
        {
            var produto = new ProdutoModel().CriarModel(new Produto().Obter(CodigoBarras, new Repositorio<Produto>()));
            return Json(produto, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Adicionar(ProdutoModel produto)
        {

            try
            {
                Produto produtoDominio = produto.CriarDominio();
                produtoDominio.Adicionar(new Repositorio<Produto>());

                return Json(new { erro = false, Mensagem = string.Format("Produto {0} Adicionado!",produto.Descricao) });
            }
            catch (Exception ex)
            {
                return Json(new { erro = true, Mensagem = ex.Message });                
            }           
        }

        public JsonResult Atualizar(ProdutoModel produto)
        {
            try
            {
                Produto produtoDominio = produto.CriarDominio();
                produtoDominio.Atualizar(new Repositorio<Produto>());

                return Json(new { erro = false, Mensagem = string.Format("Produto {0} Atualizado!", produto.Descricao) });
            }
            catch (Exception ex)
            {
                return Json(new { erro = true, Mensagem = ex.Message });
            }
        }

        public JsonResult Apagar(ProdutoModel produto)
        {
            try
            {
                Produto produtoDominio = produto.CriarDominio();
                produtoDominio.Id = produtoDominio.Obter(produto.CodigoBarras, new Repositorio<Produto>()).Id;
                produtoDominio.Apagar(new Repositorio<Produto>());

                return Json(new { erro = false, Mensagem = string.Format("Produto {0} Apagado!", produto.Descricao) });
            }
            catch(Exception ex)
            {
                return Json(new { erro = true, Mensagem = ex.Message });
            }
        }
        public ActionResult AdicionarProduto()
        {
            return PartialView("Adicionar");
        }
    }
}
