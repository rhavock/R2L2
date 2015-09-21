using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using R2L2.Domain;
using R2L2.Infra;
using System.Collections.Generic;

namespace R2L2.Tests
{
    [TestClass]
    public class ProdutoTests
    {
        private Produto produto;
        [TestInitialize]
        public void IniciaProduto()
        {
            produto = new Produto();
        }

        [TestMethod]
        public void AdicionarProdutoTest()
        {
            produto = new Produto
            {
                CodigoBarras = "12312312",
                Descricao = "Cano",
                Estoque = 10,
                EstoqueMin = 2,
                Localizacao = "A1",
                Oferta = 0,
                Valor = 10
            };
            produto.Adicionar(new Repositorio<Produto>());
        }

        [TestMethod]
        public void AtualizarProdutoTest()
        {
            produto = new Produto
            {
                CodigoBarras = "12312312",
                Descricao = "Pipoca",
                Estoque = 10,
                EstoqueMin = 2,
                Localizacao = "A1",
                Oferta = 0,
                Valor = 10
            };
            produto.Atualizar(new Repositorio<Produto>());
        }

        [TestMethod]
        public void ObterListaProdutoTest()
        {
            List<Produto> prods = produto.Listar(new Repositorio<Produto>());
            Assert.IsTrue(prods.Count > 0);
        }

        [TestMethod]
        public void ObterProdutoTest()
        {
            produto = produto.Obter(x => x.Descricao, "Cano", new Repositorio<Produto>());
        }

        [TestMethod]
        public void ApagarProdutoTest()
        {
            produto = produto.Obter(x => x.Descricao, "Cano", new Repositorio<Produto>());
            produto.Apagar(new Repositorio<Produto>());
        }
        

      
    }
}
