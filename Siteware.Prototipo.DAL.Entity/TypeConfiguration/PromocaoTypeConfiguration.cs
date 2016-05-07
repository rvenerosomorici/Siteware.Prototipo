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
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            Property(p => p.Tipo)
                .HasColumnName("TIPO")
                .IsRequired();

            Property(p => p.BasePropriedade)
                .HasColumnName("BASE_PROPRIEDADE")
                .IsRequired();

            Property(p => p.BaseTipo)
                .HasColumnName("BASE_TIPO")
                .IsRequired();

            Property(p => p.BaseValor)
                .HasColumnName("BASE_VALOR")
                .IsRequired();

            Property(p => p.ResultadoPropriedade)
                .HasColumnName("RESULTADO_PROPRIEDADE")
                .IsRequired();

            Property(p => p.ResultadoTipo)
                .HasColumnName("RESULTADO_TIPO")
                .IsRequired();

            Property(p => p.ResultadoValor)
                .HasColumnName("RESULTADO_VALOR")
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
