using Repositorio.Entidades;
using System.Collections.Generic;

namespace Repositorio.Interface
{
    public interface IMedicoNegocio
    {
        void Atualiza(Medico medico);
        void Deleta(long id);
        void Insere(Medico medico);
        IEnumerable<Medico> RecuperaTodos();
    }
}