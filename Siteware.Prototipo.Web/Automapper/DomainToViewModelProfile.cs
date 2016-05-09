using AutoMapper;
using Siteware.Prototipo.Dominio;
using Siteware.Prototipo.Web.ViewModels.Carrinho;
using Siteware.Prototipo.Web.ViewModels.Produtos;
using Siteware.Prototipo.Web.ViewModels.Promocao;
using System.Linq;

namespace Siteware.Prototipo.Web.Automapper
{
    public class DomainToViewModelProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Promocao, PromocaoShowViewModel>();
            Mapper.CreateMap<Promocao, PromocaoValidationViewModel>();
            Mapper.CreateMap<Produto, ProdutoShowViewModel>()
                .ForMember(p=>p.NomePromocao, opt =>
                {
                    opt.MapFrom(src =>
                        src.Promocao.Nome
                    );
                }) ;
            Mapper.CreateMap<Produto, ProdutoValidationViewModel>();
            Mapper.CreateMap<Carrinho, CarrinhoShowViewModel>();
            Mapper.CreateMap<Carrinho, CarrinhoValidationViewModel>();
        }
    }
}
