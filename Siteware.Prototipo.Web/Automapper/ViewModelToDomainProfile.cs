using AutoMapper;
using Siteware.Prototipo.Dominio;
using Siteware.Prototipo.Web.ViewModels.Carrinho;
using Siteware.Prototipo.Web.ViewModels.Produtos;
using Siteware.Prototipo.Web.ViewModels.Promocao;

namespace Siteware.Prototipo.Web.Automapper
{
    public class ViewModelToDomainProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<PromocaoShowViewModel, Promocao>();
            Mapper.CreateMap<PromocaoValidationViewModel, Promocao>();
            Mapper.CreateMap<ProdutoShowViewModel, Produto>();
            Mapper.CreateMap<ProdutoValidationViewModel, Produto>();
            Mapper.CreateMap<CarrinhoShowViewModel,Carrinho>();
            Mapper.CreateMap<CarrinhoValidationViewModel, Carrinho>();
        }
    }
}
