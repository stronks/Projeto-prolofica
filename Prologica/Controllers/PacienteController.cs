using Prologica.Utils;
using Repositorio.Entidades;
using Repositorio.Interface;
using System;
using System.Collections.Generic;

using System.Web.Http;

namespace Prologica.Controllers
{

    public class PacienteController : ApiController
    {
        private readonly IPacienteNegocio _pacienteNegocio;
        public PacienteController(IPacienteNegocio pacienteNegocio)
        {
            _pacienteNegocio = pacienteNegocio;
        }


        [HttpGet]
        [Route("api/Paciente")]
        public IEnumerable<Paciente> Get()
        {
            var result = _pacienteNegocio.RecuperaTodos();
            return result;
        }

        [HttpPost]
        [Route("api/Paciente/Insere")]
        public IHttpActionResult Insere(Paciente Paciente)
        {
            try
            {
                _pacienteNegocio.Insere(Paciente);
                return Ok(Mapper.MapperPaciente(_pacienteNegocio.RecuperaTodos()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPut]
        [Route("api/Paciente/Update")]
        public IHttpActionResult Update(Paciente Paciente)
        {
            try
            {
                _pacienteNegocio.Atualiza(Paciente);
                return Ok(Mapper.MapperPaciente(_pacienteNegocio.RecuperaTodos()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/Paciente/Delete/{id}")]
        public IHttpActionResult Delete(long id)
        {
            try
            {
                _pacienteNegocio.Deleta(id);
                return Ok(Mapper.MapperPaciente(_pacienteNegocio.RecuperaTodos()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}