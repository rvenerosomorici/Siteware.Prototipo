using System.Collections.Generic;

namespace Siteware.Prototipo.Dominio
{
    public partial class Promocao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string BasePropriedade { get; set; }
        public string BaseTipo{ get; set; }
        public decimal BaseValor { get; set; }
        public string ResultadoPropriedade { get; set; }
        public string ResultadoTipo { get; set; }
        public decimal ResultadoValor { get; set; }

        public virtual List<Produto> Produtos { get; set; }
    }
}
