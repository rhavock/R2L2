using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace R2L2.Domain
{
    public class Produto : IDomain<Produto>
    {
        public ObjectId Id { get; set; }
        public string CodigoBarras { get; set; }
        public string Descricao { get; set; }
        public int Estoque { get; set; }
        public int EstoqueMin { get; set; }
        public string Localizacao { get; set; }
        public double Oferta { get; set; }
        public double Valor { get; set; }
        public string Marca { get; set; }



        public void Adicionar(IRepositorio<Produto> iprodutorepositorio)
        {
            try
            {
                var produtoBase = Obter(CodigoBarras, iprodutorepositorio);
                if (produtoBase.CodigoBarras == CodigoBarras)
                    throw new DomainException(string.Format("O Produto {0} já existe", CodigoBarras));
                iprodutorepositorio.Adicionar(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Atualizar(IRepositorio<Produto> iprodutorepositorio)
        {
            var produtoBase = Obter(CodigoBarras, iprodutorepositorio);
            Id = produtoBase.Id;
            iprodutorepositorio.Atualizar(this, x => x.CodigoBarras == CodigoBarras);
        }

        public Produto Obter(string codigoBarras, IRepositorio<Produto> iprodutorepositorio)
        {
            return iprodutorepositorio.Obter(this, x => x.CodigoBarras, codigoBarras);
        }

        public Produto Obter<TipoDado>(Expression<Func<Produto, TipoDado>> expressao, TipoDado valor, IRepositorio<Produto> iprodutorepositorio)
        {
            return iprodutorepositorio.Obter(this, expressao, valor);
        }

        public void Apagar(IRepositorio<Produto> iprodutorepositorio)
        {
            iprodutorepositorio.Apagar(this, x => x.Id == Id);
        }

        public List<Produto> Listar(IRepositorio<Produto> iprodutorepositorio)
        {
            return iprodutorepositorio.Listar(this);
        }

        public List<Produto> Listar(Expression<Func<Produto, bool>> query, IRepositorio<Produto> irepositorio)
        {
            return irepositorio.Listar(this, query);
        }
    }
}