using System.Web.Mvc;
using R2L2.Domain;
using R2L2.Infra;
using R2L2.Presentation.Models;

namespace R2L2.Presentation.Controllers
{
    public class PedidoController:Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Adicionar()
        {
            return View();
        }

        public JsonResult PesquisarCliente(string clienteSearch)
        {
            if (clienteSearch != "undefined")
            {
                var clientes = new ClienteModel().CriarModel(new Cliente().Listar(x => x.Nome.Contains(clienteSearch), new Repositorio<Cliente>()));
                return Json(clientes, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Mensagem = "Nada encontrado"});
        }
        public JsonResult PesquisarProduto(string produtoSearch)
        {
            if (produtoSearch != "undefined")
            {
                var produtos = new ProdutoModel().CriarModel(new Produto().Listar(x => x.Descricao.Contains(produtoSearch), new Repositorio<Produto>()));
                return Json(produtos, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Mensagem = "Nada encontrado" });
        }

        public JsonResult Listar()
        {
            var pedidos = new PedidoModel().CriarModel(new Pedido().Listar(new Repositorio<Pedido>()));
            return Json(pedidos, JsonRequestBehavior.AllowGet);
        }
    }
}
