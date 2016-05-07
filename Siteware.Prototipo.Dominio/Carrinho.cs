using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siteware.Prototipo.Dominio
{
    public class Carrinho
    {
        public virtual Produto Produto { get; set; }
        public int IdProduto { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}
