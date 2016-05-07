namespace Siteware.Prototipo.Dominio
{
    public partial class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public virtual Promocao Promocao { get; set; }
        public int IdPromocao { get; set; }
    }
}
