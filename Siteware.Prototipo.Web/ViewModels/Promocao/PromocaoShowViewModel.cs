using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siteware.Prototipo.Web.ViewModels.Promocao
{
    public class PromocaoShowViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Promoção")]
        public string Nome { get; set; }
        [Display(Name = "Tipo Promoção")]
        public string Tipo { get; set; }
        [Display(Name = "Baseado em")]
        public string BasePropriedade { get; set; }
        [Display(Name = "Comparação")]
        public string BaseTipo { get; set; }
        [Display(Name = "Valor da Base")]
        public decimal BaseValor { get; set; }
        [Display(Name = "Resultado em")]
        public string ResultadoPropriedade { get; set; }
        [Display(Name = "Tipo de Resultado")]
        public string ResultadoTipo { get; set; }
        [Display(Name = "Valor do Resultado")]
        public decimal ResultadoValor { get; set; }
    }
}
