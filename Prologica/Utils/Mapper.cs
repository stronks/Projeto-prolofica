using Prologica.Models;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prologica.Utils
{
    public static class Mapper
    {

        public static IEnumerable<ConsultorioViewModel> MapperConsultorio(IEnumerable<Consultorio> entidadeList)
        {
            return entidadeList.ToList().Select(item=> new ConsultorioViewModel()
            {
                Id = item.Id,
                Nome = item.Nome
            });
        }

        public static IEnumerable<MedicoViewModel> MapperMedico(IEnumerable<Medico> entidadeList)
        {
            return entidadeList.ToList().Select(item => new MedicoViewModel()
            {
                Id = item.Id,
                Nome = item.Nome
            });
        }


        public static IEnumerable<PacienteViewModel> MapperPaciente(IEnumerable<Paciente> entidadeList)
        {
            return entidadeList.ToList().Select(item => new PacienteViewModel()
            {
                Id = item.Id,
                Nome = item.Nome
            });
        }


        public static IEnumerable<ConsultaAgendadas> MapperHorarioAgenda(IEnumerable<HorarioAgenda> entidadeList)
        {
            return entidadeList.ToList().Select(item => new ConsultaAgendadas()
            {
            
            });
        }
    }
}