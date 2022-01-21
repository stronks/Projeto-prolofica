using Repositorio.Entidades;
using System.Collections.Generic;
using System.Data;

namespace Repositorio.Interfaces
{
    public interface IRepositorioBase<TEntidade> where TEntidade : EntidadeBase
    {
        void Atualiza(TEntidade entidade);
        void Deleta(long id);
        void Insere(TEntidade entidade);
        TEntidade ObtemPeloId(long id);
        IEnumerable<ConsultaAgendadas> RecuperaTodasConsultaAgendadas();
        IEnumerable<TEntidade> RecuperaTodos();
    }
}
