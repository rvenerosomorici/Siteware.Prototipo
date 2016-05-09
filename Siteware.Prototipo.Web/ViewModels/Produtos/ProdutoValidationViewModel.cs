using System.ComponentModel.DataAnnotations;

namespace Siteware.Prototipo.Web.ViewModels.Produtos
{
    public class ProdutoValidationViewModel
    {
        [Required(ErrorMessage = "O Id é obrigatório")]
        public int Id { get; set; }
        [Display(Name = "Produto")]
        [Required(ErrorMessage = "O produto é obrigatório")]
        public string Nome { get; set; }
        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O preço é obrigatório")]
        public decimal Preco { get; set; }
        [Display(Name = "Promoção")]
        public int? IdPromocao { get; set; }
    }
}
