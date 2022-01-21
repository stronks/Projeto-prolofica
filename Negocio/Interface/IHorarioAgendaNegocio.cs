using Dominio.Agendamento;
using Repositorio.Entidades;
using System.Collections.Generic;

namespace Repositorio.Interface
{
    public interface IHorarioAgendaNegocio
    {
        void Atualiza(HorarioAgenda consultorio);
        void Deleta(long id);
        void Insere(CadastroHorarioRequest consultorio);
        IEnumerable<ConsultaAgendadas> RecuperaTodos();
    }
}