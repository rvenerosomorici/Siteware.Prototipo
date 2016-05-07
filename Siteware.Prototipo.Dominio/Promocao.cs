using System.Collections.Generic;

namespace Siteware.Prototipo.Dominio
{
    public class Promocao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Parametros { get; set; }
        public string BasePromocao { get; set; }
        public string TipoPromocao { get; set; }
        public decimal ValorPromocao { get; set; }
        public string BaseResultado { get; set; }
        public string TipoResultado { get; set; }
        public decimal ValorResultado { get; set; }

        public virtual List<Produto> Produtos { get; set; }
    }
}
