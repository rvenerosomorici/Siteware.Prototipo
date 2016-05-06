﻿using Siteware.Generica.Entity;
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
                .IsRequired()
                .HasColumnName("NOME")
                .HasMaxLength(150);

            Property(p => p.Preco)
                .IsRequired();
        }

        protected override void ConfigurarFK()
        {
            
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