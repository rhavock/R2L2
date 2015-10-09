using System;
using System.Collections.Generic;
using R2L2.Domain;

namespace R2L2.Presentation.Models
{
    internal class ClienteModel
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
    }
}