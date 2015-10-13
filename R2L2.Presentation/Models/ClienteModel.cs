using System;
using System.Collections.Generic;
using R2L2.Domain;

namespace R2L2.Presentation.Models
{
    public class ClienteModel
    {
        public double Desconto { get; set; }
        public string Nome { get; set; }
        public int Cpf { get; set; }
        public string Bairro { get; set; }
        public int Cep { get; set; }
        public string Cidade { get; set; }
        public int Numero { get; set; }
        public string Referencia { get; set; }
        public string Rua { get; set; }
        public string UF { get; set; }
        public ClienteModel()
        {
        }

        internal IEnumerable<ClienteModel> CriarModel(List<Cliente> list)
        {
            foreach (var item in list)
            {
                yield return new ClienteModel
                {
                    Desconto = item.Desconto,
                    Bairro = item.Endereco.Bairro,
                    Cep = item.Endereco.Cep,
                    Cidade = item.Endereco.Cidade,
                    Cpf = item.Cpf,
                    Nome = item.Nome,
                    Numero = item.Endereco.Numero,
                    Referencia = item.Endereco.Referencia,
                    Rua = item.Endereco.Rua,
                    UF = item.Endereco.UF
                };
            }
        }

        internal Cliente CriarDominio()
        {
            return new Cliente
            {
                Nome = this.Nome,
                Cpf = this.Cpf,
                Desconto = this.Desconto,
                Endereco = new Endereco
                {
                    Bairro = this.Bairro,
                    Cep = this.Cep,
                    Cidade = this.Cidade,
                    Numero = this.Numero,
                    Referencia = this.Referencia,
                    Rua = this.Rua,
                    UF = this.UF
                }
            };
        }

        internal ClienteModel CriarModel(Cliente cliente)
        {
            Desconto = cliente.Desconto;
            Nome = cliente.Nome;
            Cpf = cliente.Cpf;
            Bairro = cliente.Endereco.Bairro;
            Cep = cliente.Endereco.Cep;
            Cidade = cliente.Endereco.Cidade;
            Numero = cliente.Endereco.Numero;
            Referencia = cliente.Endereco.Referencia;
            Rua = cliente.Endereco.Rua;
            UF = cliente.Endereco.UF;
            return this;
        }
    }
    
}