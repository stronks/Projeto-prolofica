using Repositorio.Interface;
using Repositorio.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace Repositorio.Entidades
{
    public class MedicoNegocio: IMedicoNegocio
    {

        private readonly IRepositorioBase<Medico> _medicoRepositorio;
        public MedicoNegocio(IRepositorioBase<Medico> medicoRepositorio)
        {
            _medicoRepositorio = medicoRepositorio;
        }

        public IEnumerable<Medico> RecuperaTodos()
        {
           return _medicoRepositorio.RecuperaTodos();
        }
        public void Atualiza(Medico medico)
        {
            var medicoAtualizar = _medicoRepositorio.ObtemPeloId(medico.Id);
            medicoAtualizar.Nome = medico.Nome;
            _medicoRepositorio.Atualiza(medicoAtualizar);
        }
        public void  Insere(Medico medico)
        {
            _medicoRepositorio.Insere(medico);
        }
        public void Deleta(long id)
        {
            _medicoRepositorio.Deleta(id);
        }
    }
}
