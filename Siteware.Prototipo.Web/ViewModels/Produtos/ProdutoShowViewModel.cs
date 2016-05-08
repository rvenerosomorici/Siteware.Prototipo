using System.ComponentModel.DataAnnotations;

namespace Siteware.Prototipo.Web.ViewModels.Produtos
{
    public class ProdutoShowViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Produto")]
        public string Nome { get; set; }
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }
        [Display(Name = "Promoção")]
        public string NomePromocao { get; set; }
    }
}
