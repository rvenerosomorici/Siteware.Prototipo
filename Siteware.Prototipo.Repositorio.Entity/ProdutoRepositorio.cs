using Siteware.Prototipo.Dominio;
using Siteware.Prototipo.Repositorios.Base.Entity;
using Siteware.Prototipo.DAL.Entity.Context;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Siteware.Prototipo.Repositorio.Entity
{
    public class ProdutoRepositorio : RepositorioGenericoEntity<Produto, int>
    {
        public ProdutoRepositorio(PrototipoDbContext contexto) 
            : base(contexto)
        {
        }

        public override List<Produto> Selecionar()
        {
            return _contexto.Set<Produto>().Include(p => p.Promocao).ToList();
        }

        public override Produto SelecionarPorId(int id)
        {
            return _contexto.Set<Produto>().Include(p => p.Promocao).SingleOrDefault(p=>p.Id == id);
        }
    }
}
