using System;
using System.Collections.Generic;
using R2L2.Domain;

namespace R2L2.Presentation.Models
{
    public class PedidoModel
    {

        public long Numero { get; set; }
        public double Desconto { get; set; }
        public string Nome { get; set; }
        public int Cpf { get; set; }
        public string Bairro { get; set; }
        public int Cep { get; set; }
        public string Cidade { get; set; }
        public int NumeroCasa { get; set; }
        public string Referencia { get; set; }
        public string Rua { get; set; }
        public string UF { get; set; }
        public string Login { get; set; }
        public string NomeUsuario { get; set; }
        public double ValorTotal { get; set; }
        public double DescontoCliente { get; set; }
        public int QuantidadeTotal { get; set; }
        public string DataPedido { get; set; }
        public TipoVenda TipoVenda { get; set; }
        public IEnumerable<ProdutoModel> Produtos { get; set; }
        public double ValorTotalOferta { get; set; }
        public PedidoModel()
        {
        }

        internal IEnumerable<PedidoModel> CriarModel(List<Pedido> list)
        {
            foreach (var item in list)
            {
                if (item.Cliente.Endereco == null)
                    item.Cliente.Endereco = new Endereco();
                yield return new PedidoModel
                {
                    
                    Numero = item.Numero,
                    Bairro = item.Cliente.Endereco.Bairro,
                    Cep = item.Cliente.Endereco.Cep,
                    Cidade = item.Cliente.Endereco.Cidade,
                    Cpf = item.Cliente.Cpf,
                    DataPedido = item.DataPedido.ToUniversalTime().ToShortDateString(),
                    Desconto = item.Desconto,
                    DescontoCliente = item.Cliente.Desconto,
                    Login = item.Usuario.Login,
                    Nome = item.Cliente.Nome,
                    NomeUsuario = item.Usuario.Nome,
                    NumeroCasa = item.Cliente.Endereco.Numero,
                    QuantidadeTotal = item.QuantidadeTotal,
                    Referencia = item.Cliente.Endereco.Referencia,
                    Rua = item.Cliente.Endereco.Rua,
                    TipoVenda = item.TipoVenda,
                    UF = item.Cliente.Endereco.UF,
                    ValorTotal = item.ValorTotal,
                    ValorTotalOferta = item.ValorTotalOferta,
                    Produtos = new ProdutoModel().CriarModel(item.Produtos)

                };
            }
        }
    }
}