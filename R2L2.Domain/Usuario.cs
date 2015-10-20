using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Bson;

namespace R2L2.Domain
{
    public class Usuario
    {
        public ObjectId Id { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Imagem { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public void Adicionar(IRepositorio<Usuario> irepositorio)
        {
            var usuarioBase = Obter(x => x.Login, Login, irepositorio);
            if (usuarioBase.Login == Login)
                throw new DomainException(string.Format("O Login {0} já está sendo utilizado", Login));
            irepositorio.Adicionar(this);
        }

        public void Atualizar(IRepositorio<Usuario> irepositorio)
        {
            Id = Obter(x => x.Login, Login, irepositorio).Id;
            irepositorio.Atualizar(this, x => x.Login == Login);
        }

        public Usuario Obter<TipoDado>(Expression<Func<Usuario, TipoDado>> expressao, TipoDado valor, IRepositorio<Usuario> irepositorio)
        {
            return irepositorio.Obter(this, expressao, valor);
        }

        public void Apagar(IRepositorio<Usuario> irepositorio)
        {
            irepositorio.Apagar(this, x => x.Id == Id);
        }
        public List<Usuario> Listar(IRepositorio<Usuario> irepositorio)
        {
            return irepositorio.Listar(this);
        }

        public List<Usuario> Listar(Expression<Func<Usuario,bool>> query, IRepositorio<Usuario> irepositorio)
        {
            return irepositorio.Listar(this, query);
        }
    }
}