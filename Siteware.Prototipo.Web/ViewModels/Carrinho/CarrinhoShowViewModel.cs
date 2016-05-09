using System.ComponentModel.DataAnnotations;

namespace Siteware.Prototipo.Web.ViewModels.Carrinho
{
    public class CarrinhoShowViewModel
    {
        public int IdProduto { get; set; }
        [Display(Name = "Produto")]
        public string NomeProduto { get; set; }
        [Display(Name = "Valor")]
        public decimal ValorUnitario { get; set; }
        [Display(Name = "Valor Final")]
        public string Promocao { get; set; }
        [Display(Name = "Quantidade de Compra")]
        public int QuantidadeCompra { get; set; }
        [Display(Name = "Quantidade Final")]
        public int QuantidadeFinal { get; set; }
        [Display(Name = "Valor Final")]
        public decimal ValorCompra { get; set; }
    }
}
