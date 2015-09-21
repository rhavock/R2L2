using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace R2L2.Presentation.Models
{
    public class ProdutoModel
    {
        public string CodigoBarras { get; set; }
        public string Descricao { get; set; }
        public int Estoque { get; set; }
        public int EstoqueMin { get; set; }
        public string Localizacao { get; set; }
        public double Oferta { get; set; }
        public double Valor { get; set; }

        public List<ProdutoModel> CriarModel()
        {
            var produtos = new Produto().
        }
    }
}
