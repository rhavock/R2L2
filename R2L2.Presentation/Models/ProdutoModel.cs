using System;
using System.Collections;
using System.Collections.Generic;
using R2L2.Domain;

namespace R2L2.Presentation.Models
{
    public class ProdutoModel
    {
        public string CodigoBarras { get; set; }
        public string Descricao { get; set; }
        public int Estoque { get; set; }
        public int EstoqueMin { get; set; }
        public string Localizacao { get; set; }
        public double Oferta { get; set; }
        public double Valor { get; set; }
        public string Marca { get; set; }

        internal Produto CriarDominio()
        {
            return new Produto
            {
                CodigoBarras = CodigoBarras,
                Descricao = Descricao,
                Estoque = Estoque,
                Localizacao = Localizacao,
                Valor = Valor,
                EstoqueMin = EstoqueMin,
                Marca = Marca,
                Oferta = Oferta
            };
        }

        internal ProdutoModel CriarModel(Produto produto)
        {
            CodigoBarras = produto.CodigoBarras;
            Descricao = produto.Descricao;
            Estoque = produto.Estoque;
            Localizacao = produto.Localizacao;
            Valor = produto.Valor;
            EstoqueMin = produto.EstoqueMin;
            Marca = produto.Marca;
            Oferta = produto.Oferta;
            return this;
        }

        internal IEnumerable<ProdutoModel> CriarModel(List<Produto> produtos)
        {
            foreach (var prod in produtos)
            {
                yield return new ProdutoModel
                {
                    CodigoBarras = prod.CodigoBarras,
                    Descricao = prod.Descricao,
                    Estoque = prod.Estoque,
                    Localizacao = prod.Localizacao,
                    Valor = prod.Valor,
                    EstoqueMin = prod.EstoqueMin,
                    Marca = prod.Marca,
                    Oferta = prod.Oferta
                };
            }
        }
    }
}