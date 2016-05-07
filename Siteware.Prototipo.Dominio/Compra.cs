using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siteware.Prototipo.Dominio
{
    public class Compra
    {
        public virtual Produto Produto { get; set; }
        public int IdProduto { get; set; }
        public int QuantidadeInicial { get; set; }
        public decimal ValorInicial { get; set; }
        public int QuantidadeFinal { get; set; }
        public decimal ValorFinal { get; set; }
    }
}
