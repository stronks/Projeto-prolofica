using Repositorio.Interface;
using Repositorio.Interfaces;
using System.Collections.Generic;

namespace Repositorio.Entidades
{
    public class PacienteNegocio : IPacienteNegocio
    {

        private readonly IRepositorioBase<Paciente> _pacienteRepositorio;
        public PacienteNegocio(IRepositorioBase<Paciente> pacienteRepositorio)
        {
            _pacienteRepositorio = pacienteRepositorio;
        }


        public IEnumerable<Paciente> RecuperaTodos()
        {
            return _pacienteRepositorio.RecuperaTodos();
        }
        public void Atualiza(Paciente paciente)
        {

            var pacienteAtualizar = _pacienteRepositorio.ObtemPeloId(paciente.Id);
            pacienteAtualizar.Nome = paciente.Nome;
            _pacienteRepositorio.Atualiza(pacienteAtualizar);
        }
        public void Insere(Paciente paciente)
        {
            _pacienteRepositorio.Insere(paciente);
        }
        public void Deleta(long id)
        {
            _pacienteRepositorio.Deleta(id);
        }
    }
}
