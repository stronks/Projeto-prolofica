using Prologica.Utils;
using Repositorio.Entidades;
using Repositorio.Interface;
using System;
using System.Collections.Generic;

using System.Web.Http;

namespace Prologica.Controllers
{

    public class MedicoController : ApiController
    {
        private readonly IMedicoNegocio _medicoNegocio;
        public MedicoController(IMedicoNegocio medicoNegocio)
        {
            _medicoNegocio = medicoNegocio;
        }

        [HttpGet]
        [Route("api/Medico")]
        public IEnumerable<Medico> Get()
        {
            var result = _medicoNegocio.RecuperaTodos();
            return result;
        }

        [HttpPost]
        [Route("api/Medico/Insere")]
        public IHttpActionResult Insere(Medico Medico)
        {
            try
            {
                _medicoNegocio.Insere(Medico);
                return Ok(Mapper.MapperMedico(_medicoNegocio.RecuperaTodos()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPut]
        [Route("api/Medico/Update")]
        public IHttpActionResult Update(Medico Medico)
        {
            try
            {
                _medicoNegocio.Atualiza(Medico);
                return Ok(Mapper.MapperMedico(_medicoNegocio.RecuperaTodos()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/Medico/Delete/{id}")]
        public IHttpActionResult Delete(long id)
        {
            try
            {
                _medicoNegocio.Deleta(id);
                return Ok(Mapper.MapperMedico(_medicoNegocio.RecuperaTodos()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}