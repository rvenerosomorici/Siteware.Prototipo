using Siteware.Prototipo.Repositorios.Base.Entity;
using Siteware.Prototipo.Dominio;
using Siteware.Prototipo.DAL.Entity.Context;

namespace Siteware.Prototipo.Repositorios.Entity
{
    public class PromocaoRepositorio : RepositorioGenericoEntity<Promocao, int>
    {
        public PromocaoRepositorio(PrototipoDbContext contexto) 
            : base(contexto)
        {

        }
    }
}
