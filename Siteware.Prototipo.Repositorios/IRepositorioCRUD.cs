using System.Collections.Generic;

namespace Siteware.Prototipo.Repositorios
{
    public interface IRepositorioCRUD<TEntidade, TChave>
        where TEntidade:class
    {
        List<TEntidade> Selecionar();
        TEntidade SelecionarPorId(TChave id);
        void Inserir(TEntidade entidade);
        void Alterar(TEntidade entidade);
        void Excluir(TEntidade entidade);
        void ExcluirPorId(TChave id);
    }
}
