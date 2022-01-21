using Repositorio.Entidades;
using System.Collections.Generic;

namespace Repositorio.Interface
{
    public interface IConsultorioNegocio
    {
        void Atualiza(Consultorio consultorio);
        void Deleta(long id);
        void Insere(Consultorio consultorio);
        IEnumerable<Consultorio> RecuperaTodos();
    }
}