using Repositorio.Entidades;
using System.Collections.Generic;

namespace Repositorio.Interface
{
    public interface IPacienteNegocio
    {
        void Atualiza(Paciente paciente);
        void Deleta(long id);
        void Insere(Paciente paciente);
        IEnumerable<Paciente> RecuperaTodos();
    }
}