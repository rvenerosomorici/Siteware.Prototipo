using Siteware.Generica.Entity;
using Siteware.Prototipo.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siteware.Prototipo.DAL.Entity.TypeConfiguration
{
    class PromocaoTypeConfiguration : SitewareEntityAbstractConfig<Promocao>
    {
        protected override void ConfigurarCampos()
        {
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("ID");

            Property(p => p.Nome)
                .IsRequired()
                .HasColumnName("NOME")
                .HasMaxLength(150);

            Property(p => p.Parametros)
                .HasColumnName("PARAMETRO")
                .IsRequired();

            Property(p => p.BasePromocao)
                .HasColumnName("BASE_PROMOCAO")
                .IsRequired();

            Property(p => p.TipoPromocao)
                .HasColumnName("TIPO_PROMOCAO")
                .IsRequired();

            Property(p => p.ValorPromocao)
                .HasColumnName("VALOR_PROMOCAO")
                .IsRequired();

            Property(p => p.BaseResultado)
                .HasColumnName("BASE_RESULTADO")
                .IsRequired();

            Property(p => p.TipoResultado)
                .HasColumnName("TIPO_RESULTADO")
                .IsRequired();

            Property(p => p.ValorResultado)
                .HasColumnName("VALOR_RESULTADO")
                .IsRequired();
        }

        protected override void ConfigurarFK()
        {

        }

        protected override void ConfigurarNome()
        {
            ToTable("PROMOCOES");
        }

        protected override void ConfigurarPK()
        {
            HasKey(p => p.Id);
        }
    }
}
