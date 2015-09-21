using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace R2L2.Domain
{
    public interface IDomain<Classe>
    {
        void Adicionar(IRepositorio<Classe> irepositorio);
        void Atualizar(IRepositorio<Classe> irepositorio);
        Classe Obter<TipoDado>(Expression<Func<Classe, TipoDado>> expressao, TipoDado valor, IRepositorio<Classe> irepositorio);
        void Apagar(IRepositorio<Classe> irepositorio);
        List<Classe> Listar(IRepositorio<Classe> irepositorio);
    }
}