using Repositorio.Interface;
using Repositorio.Interfaces;
using System.Collections.Generic;

namespace Repositorio.Entidades
{
    public class ConsultorioNegocio: IConsultorioNegocio
    {


        private readonly IRepositorioBase<Consultorio> _consultorioRepositorio;
        public ConsultorioNegocio(IRepositorioBase<Consultorio> consultorioRepositorio)
        {
            _consultorioRepositorio = consultorioRepositorio;
        }


        public IEnumerable<Consultorio> RecuperaTodos()
        {
            return _consultorioRepositorio.RecuperaTodos();
        }
        public void Atualiza(Consultorio consultorio)
        {
            var ConsultorioAtualizar = _consultorioRepositorio.ObtemPeloId(consultorio.Id);
            ConsultorioAtualizar.Nome = consultorio.Nome;

            _consultorioRepositorio.Atualiza(ConsultorioAtualizar);
        }
        public void Insere(Consultorio consultorio)
        {
            _consultorioRepositorio.Insere(consultorio);
        }
        public void Deleta(long id)
        {
            _consultorioRepositorio.Deleta(id);
        }
    }
}
