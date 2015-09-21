using Microsoft.VisualStudio.TestTools.UnitTesting;
using R2L2.Domain;
using R2L2.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2L2.Tests
{
    [TestClass]
    public class ClienteTest
    {
        [TestMethod]
        public void TestAdicaoCliente()
        {
            var cliente = new Cliente()
            {
                Cpf = 1,
                Desconto = 0,
                Endereco = new Endereco
                {
                    Cep = 04815120,
                    Rua = "Djalma",
                    Numero = 1,
                    Bairro = "Interlagos",
                    Cidade = "São Paulo",
                    UF = "SP",
                    Referencia = "Casa"
                },
                Nome = "Eu"
            };

            cliente.Adicionar(new Repositorio<Cliente>());
        }
    }
}
