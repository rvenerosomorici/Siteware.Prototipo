using AutoMapper;
using Siteware.Prototipo.Dominio;
using Siteware.Prototipo.Web.ViewModels.Produtos;
using Siteware.Prototipo.Web.ViewModels.Promocao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siteware.Prototipo.Web.Automapper
{
    public class DomainToViewModelProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Promocao, PromocaoShowViewModel>();
            Mapper.CreateMap<Promocao, PromocaoValidationViewModel>();
            Mapper.CreateMap<Produto, ProdutoShowViewModel>();
            Mapper.CreateMap<Produto, ProdutoValidationViewModel>();
        }
    }
}
