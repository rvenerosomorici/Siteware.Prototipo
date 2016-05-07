using AutoMapper;
using Siteware.Prototipo.Web.Automapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
