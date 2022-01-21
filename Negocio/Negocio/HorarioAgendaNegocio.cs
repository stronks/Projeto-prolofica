using Dominio.Agendamento;
using Repositorio.Interface;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;

namespace Repositorio.Entidades
{
    public class HorarioAgendaNegocio: IHorarioAgendaNegocio
    {


        private readonly IRepositorioBase<HorarioAgenda> _horarioAgendaRepositorio;
        public HorarioAgendaNegocio(IRepositorioBase<HorarioAgenda> horarioAgendaRepositorio)
        {
            _horarioAgendaRepositorio = horarioAgendaRepositorio;
        }


        public IEnumerable<ConsultaAgendadas> RecuperaTodos()
        {
            return _horarioAgendaRepositorio.RecuperaTodasConsultaAgendadas();
        }
        public void Atualiza(HorarioAgenda agendamento)
        {
            _horarioAgendaRepositorio.Atualiza(agendamento);
        }
        public void Insere(CadastroHorarioRequest agendamento)
        {
            DateTime DataHoraMarcada = DateTime.Parse(agendamento.DataHoraMarcada);

            _horarioAgendaRepositorio.Insere(new HorarioAgenda()
            {
                DataHoraMarcada = DataHoraMarcada,
                IdConsultorio = agendamento.Consultorio.id,
                IdMedico = agendamento.Medico.id,
                IdPaciente = agendamento.Paciente.id,
                DataCriacao = DateTime.Now,
                Nome = "Agendamento "+ DataHoraMarcada.ToShortDateString() +" - "+ DataHoraMarcada.ToShortTimeString()
            }); 
        }
        public void Deleta(long id)
        {
            _horarioAgendaRepositorio.Deleta(id);
        }

    }
}
