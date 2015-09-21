using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using R2L2.Domain;
using R2L2.Infra;

namespace R2L2.Tests
{
    [TestClass]
    public class TestPedido
    {
        Pedido pedido = new Pedido();
        [TestInitialize]
        public void IniciaPedido()
        {
            pedido = new Pedido()
            {
                TipoVenda = TipoVenda.Rapida,
                DataPedido = DateTime.Now
            };
            

            pedido.AdicionaCliente(new Cliente { Nome = "Venda Rápida" });

            if (pedido.ValidarProdutos("12312312"))
            {
                pedido.AdicionaProduto(new Produto().Obter("12312312", new Repositorio<Produto>()), 10);
            }
            if (pedido.ValidarProdutos("12312312"))
            {
                pedido.AdicionaProduto(new Produto().Obter("12312312",new Repositorio<Produto>()), 1);
            }
            
        }

        [TestMethod]
        public void QuantidadeValorTotal()
        {
            Assert.AreEqual(200, pedido.ValorTotal);
            Assert.AreEqual(2, pedido.QuantidadeTotal);
        }

        [TestMethod]
        public void VerificarMovimentacaoEstoque()
        {
            foreach (var prod in pedido.Produtos)
            {
                Assert.AreEqual(1, prod.Estoque);
            }            
        }

        [TestMethod]
        public void ValorComOferta()
        {
            Assert.AreEqual(275, pedido.ValorTotalOferta);
        }

        [TestMethod]
        public void DescontoCliente()
        {
            IniciaPedido();
            pedido.ValorTotalOferta = 0;
            pedido.TipoVenda = TipoVenda.Cliente;
            pedido.Cliente = new Cliente { Nome = "Rodrigo", Desconto = 50.0 };
            pedido.RecalculaDesconto();

            Assert.AreEqual(100, pedido.ValorTotalOferta);
        }

        [TestMethod]
        public void AdicionaPedidoTest()
        {

            while(new Produto().Obter("12312312",new Repositorio<Produto>()).Estoque > 0)
            {
                var pedid = new Pedido()
                {
                    TipoVenda = TipoVenda.Rapida
                };

                pedid.AdicionaCliente(new Cliente { Nome = "Venda Rápida" });

                if (pedid.ValidarProdutos("12312312"))
                {
                    pedid.AdicionaProduto(new Produto().Obter("12312312", new Repositorio<Produto>()), 2);
                }
                pedid.RealizarVenda(new Repositorio<Pedido>(), new Repositorio<Produto>());
            }            
        }

        [TestMethod]
        public void ListarPedidosTest()
        {
            var todospedidos = new Pedido().Listar(new Repositorio<Pedido>());
        }


    }
}
