using System.ComponentModel.DataAnnotations;

namespace Siteware.Prototipo.Web.ViewModels.Carrinho
{
    public class CarrinhoValidationViewModel
    {
        [Required]
        public int IdProduto { get; set; }
        [Required]
        [Display(Name = "Produto")]
        public string NomeProduto { get; set; }
        [Required]
        [Display(Name = "Valor")]
        public decimal ValorUnitario { get; set; }
        [Required(ErrorMessage = "A quantidade de compra é obrigatório")]
        [Display(Name = "Quantidade de Compra")]
        public int QuantidadeCompra { get; set; }
    }
}
