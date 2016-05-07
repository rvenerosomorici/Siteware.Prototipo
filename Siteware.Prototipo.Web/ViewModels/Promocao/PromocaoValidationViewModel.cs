using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siteware.Prototipo.Web.ViewModels.Promocao
{
    public class PromocaoValidationViewModel
    {
        [Required(ErrorMessage ="O Id é obrigatório")]
        public int Id { get; set; }
        [Display(Name = "Promoção")]
        [Required(ErrorMessage = "A Promoção é obrigatório")]
        [MaxLength(150, ErrorMessage ="O nome da promoção pode ter no máximo 150 caracteres")]
        public string Nome { get; set; }
        [Display(Name = "Tipo Promoção")]
        [Required(ErrorMessage = "O Tipo Promoção é obrigatório")]
        public string Tipo { get; set; }
        [Display(Name = "Baseado em")]
        [Required(ErrorMessage = "'Baseado em' é obrigatório")]
        public string BasePropriedade { get; set; }
        [Display(Name = "Comparação")]
        [Required(ErrorMessage = "'Comparação' é obrigatório")]
        public string BaseTipo { get; set; }
        [Display(Name = "Valor da Base")]
        [Required(ErrorMessage = "Valor da Base obrigatório")]
        [DataType(DataType.Currency)]
        public decimal BaseValor { get; set; }
        [Display(Name = "Resultado em")]
        [Required(ErrorMessage = "'Resultado em' é obrigatório")]
        public string ResultadoPropriedade { get; set; }
        [Display(Name = "Tipo de Resultado")]
        [Required(ErrorMessage = "Tipo de Resultado é obrigatório")]
        public string ResultadoTipo { get; set; }
        [Display(Name = "Valor do Resultado")]
        [Required(ErrorMessage = "Valor do Resultado é obrigatório")]
        [DataType(DataType.Currency)]
        public decimal ResultadoValor { get; set; }
    }
}
