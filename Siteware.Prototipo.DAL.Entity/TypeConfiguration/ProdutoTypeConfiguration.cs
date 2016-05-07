using Siteware.Generica.Entity;
using Siteware.Prototipo.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siteware.Prototipo.DAL.Entity.TypeConfiguration
{
    class ProdutoTypeConfiguration : SitewareEntityAbstractConfig<Produto>
    {
        protected override void ConfigurarCampos()
        {
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("ID");

            Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            Property(p => p.Preco)
                .IsRequired();

            Property(p => p.IdPromocao)
                .HasColumnName("PROMOCAO_ID")
                .IsRequired();
        }

        protected override void ConfigurarFK()
        {
            HasRequired(p => p.Promocao).WithMany(p => p.Produtos).HasForeignKey(p => p.IdPromocao);
        }

        protected override void ConfigurarNome()
        {
            ToTable("PRODUTOS");
        }

        protected override void ConfigurarPK()
        {
            HasKey(p => p.Id);
        }
    }
}
