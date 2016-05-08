using Siteware.Prototipo.Dominio;
using Siteware.Prototipo.Repositorios.Base.Entity;
using Siteware.Prototipo.DAL.Entity.Context;

namespace Siteware.Prototipo.Repositorio.Entity
{
    public class ProdutoRepositorio : RepositorioGenericoEntity<Produto, int>
    {
        public ProdutoRepositorio(PrototipoDbContext contexto) 
            : base(contexto)
        {
        }
    }
}
