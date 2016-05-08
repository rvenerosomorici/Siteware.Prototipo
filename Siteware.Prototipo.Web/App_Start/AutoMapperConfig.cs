using AutoMapper;
using Siteware.Prototipo.Web.Automapper;

namespace Siteware.Prototipo.Web.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configurar()
        {
            Mapper.AddProfile<DomainToViewModelProfile>();
            Mapper.AddProfile<ViewModelToDomainProfile>();
        }
    }
}
