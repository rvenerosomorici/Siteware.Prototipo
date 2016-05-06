using System.Collections.Generic;

namespace Siteware.Prototipo.Dominio
{
    public class Promocao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Parametros { get; set; }

        public virtual List<Produto> Produtos { get; set; }
    }
}
