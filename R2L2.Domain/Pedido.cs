using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace R2L2.Domain
{
    public class Pedido
    {

        private DateTime datapedido;
        public ObjectId id { get; set; }
        public Cliente Cliente { get; set; }
        public Usuario Usuario { get { return new Usuario { Login = "Adm", Nome = "Papai" }; } set { new Usuario { Login = "Adm", Nome = "Papai" }; } }
        public double ValorTotal { get; set; }
        public double Desconto { get; set; }
        public int QuantidadeTotal { get; set; }
        public DateTime DataPedido
        {
            get
          ;
            set;
        }
        public TipoVenda TipoVenda { get; set; }
        public List<Produto> Produtos { get; set; }
        public double ValorTotalOferta { get; set; }
        public long Numero { get; set; }

        public Pedido()
        {
            Produtos = new List<Produto>();

        }

        public void AdicionaProduto(Produto produto, int Quantidade)
        {
            if (Quantidade > produto.Estoque)
                throw new DomainException(string.Format("A quantidade do produto {0} é maior do que o estoque", produto.Descricao));
            Produtos.Add(produto);
            produto.Estoque -= Quantidade;
            QuantidadeTotal += Quantidade;
            ValorTotal += produto.Valor;
            RecalculaDesconto();
        }

        public void AdicionaCliente(Cliente cliente)
        {
            Cliente = cliente;
        }

        public bool ValidarProdutos(string codigoBarras)
        {
            foreach (var produto in Produtos)
            {
                var duplicado = Produtos.Where(x => x.CodigoBarras == codigoBarras);
                if (duplicado.Count() > 0)
                    return false;
            }
            return true;

        }

        public void RealizarVenda(IRepositorio<Pedido> irepositorio, IRepositorio<Produto> irepositorioProduto)
        {
            irepositorio.Adicionar(this);

            foreach (var produto in Produtos)
            {
                irepositorioProduto.Atualizar(produto, x => x.CodigoBarras == produto.CodigoBarras);
            }

        }

        public void RecalculaDesconto()
        {
            foreach (var produto in Produtos)
            {
                var percentual = TipoVenda == TipoVenda.Cliente ? (Cliente.Desconto / 100) : (produto.Oferta / 100);
                ValorTotalOferta += produto.Valor - (percentual * produto.Valor);
            }
        }

        public Pedido Obter<TipoDado>(Expression<Func<Pedido, TipoDado>> expressao, TipoDado valor, IRepositorio<Pedido> irepositorio)
        {
            return irepositorio.Obter(this, expressao, valor);
        }

        public List<Pedido> Listar(Expression<Func<Pedido, bool>> expressao, IRepositorio<Pedido> irepositorio)
        {
            return irepositorio.Listar(this, expressao);
        }
        public List<Pedido> Listar(IRepositorio<Pedido> irepositorio)
        {
            return irepositorio.Listar(this);
        }
    }
}
