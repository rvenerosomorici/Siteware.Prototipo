using System.Data.Entity.ModelConfiguration;

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
