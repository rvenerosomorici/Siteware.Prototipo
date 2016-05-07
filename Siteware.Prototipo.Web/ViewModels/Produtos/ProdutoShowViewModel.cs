using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int IdPromocao { get; set; }
    }
}
