using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siteware.Generica.Entity
{
    public abstract class SitewareEntityAbstractConfig<TEntidade> : EntityTypeConfiguration<TEntidade>
        where TEntidade : class
    {
        public SitewareEntityAbstractConfig()
        {
            ConfigurarNome();
            ConfigurarCampos();
            ConfigurarPK();
            ConfigurarFK();
        }

        protected abstract void ConfigurarFK();

        protected abstract void ConfigurarPK();

        protected abstract void ConfigurarCampos();

        protected abstract void ConfigurarNome();
    }
}
