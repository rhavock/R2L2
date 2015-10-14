using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace R2L2.Domain
{
    public class Cliente:IDomain<Cliente>
    {
        public ObjectId Id { get; set; }
        public double Desconto { get; set; }
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public int Cpf { get; set; }

        public void Adicionar(IRepositorio<Cliente> irepositorio)
        {
            var clienteBase = Obter(x => x.Cpf, Cpf, irepositorio);
            if (clienteBase.Cpf == Cpf)
                throw new DomainException(string.Format("O cliente {0} já existe", Nome));
            irepositorio.Adicionar(this);
        }

        public void Atualizar(IRepositorio<Cliente> irepositorio)
        {
            Id = Obter(x => x.Cpf, Cpf, irepositorio).Id;
            irepositorio.Atualizar(this, x => x.Cpf == Cpf);
        }

        public Cliente Obter<TipoDado>(Expression<Func<Cliente, TipoDado>> expressao, TipoDado valor, IRepositorio<Cliente> irepositorio)
        {
           return irepositorio.Obter(this, expressao, valor);
        }

        public void Apagar(IRepositorio<Cliente> irepositorio)
        {
            irepositorio.Apagar(this, x => x.Id == Id);
        }

        public List<Cliente> Listar(IRepositorio<Cliente> irepositorio)
        {
            return irepositorio.Listar(this);
        }

        public List<Cliente> Listar(Expression<Func<Cliente, bool>> query, IRepositorio<Cliente> irepositorio)
        {
            return irepositorio.Listar(this,query);
        }
    }
}