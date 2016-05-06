using Siteware.Prototipo.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using Siteware.Prototipo.DAL.Entity.TypeConfiguration;

namespace Siteware.Prototipo.DAL.Entity.Context
{
    public class PrototipoDbContext : DbContext
    {
        public System.Data.Entity.DbSet<Promocao> Promocaos { get; set; }
        public System.Data.Entity.DbSet<Produto> Produtoes { get; set; }

        public PrototipoDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProdutoTypeConfiguration());
            modelBuilder.Configurations.Add(new PromocaoTypeConfiguration());
        }
    }
}
