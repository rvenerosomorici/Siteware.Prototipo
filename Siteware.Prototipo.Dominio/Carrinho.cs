using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siteware.Prototipo.Dominio
{
    public class Carrinho
    {
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public decimal ValorUnitario { get; set; }
        public string Promocao { get; set; }
        public int QuantidadeCompra { get; set; }
        public int QuantidadeFinal { get; set; }
        public decimal ValorCompra { get; set; }
    }
}
