using Siteware.Prototipo.Repositorios.Base.Entity;
using Siteware.Prototipo.Dominio;
using Siteware.Prototipo.DAL.Entity.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Siteware.Prototipo.Repositorios.Entity
{
    public class PromocaoRepositorio : RepositorioGenericoEntity<Promocao, int>
    {
        public PromocaoRepositorio(PrototipoDbContext contexto) 
            : base(contexto)
        {

        }

        public override List<Promocao> Selecionar()
        {
            return _contexto.Set<Promocao>().Include(p => p.Produtos).ToList();
        }

        public override Promocao SelecionarPorId(int id)
        {
            return _contexto.Set<Promocao>().Include(p => p.Produtos).SingleOrDefault(p => p.Id == id);
        }
    }
}
