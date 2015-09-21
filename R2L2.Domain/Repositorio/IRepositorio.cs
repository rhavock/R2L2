using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace R2L2.Domain
{
    public interface IRepositorio<Classe>
    {
        void Adicionar(Classe classe);
        void Apagar(Classe classe, Expression<Func<Classe, bool>> query);
        void Atualizar(Classe classe, Expression<Func<Classe, bool>> query);
        List<Classe> Listar(Classe classe);
        List<Classe> Listar(Classe classe, Expression<Func<Classe, bool>> query);
        Classe Obter<TipoDado>(Classe classe, Expression<Func<Classe, TipoDado>> query, TipoDado valor);
    }
}