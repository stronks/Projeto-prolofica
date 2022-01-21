using Prologica.Utils;
using Repositorio.Entidades;
using Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Prologica.Controllers
{

    public class ConsultorioController : ApiController
    {
        private readonly IConsultorioNegocio _consultorioNegocio;
        public ConsultorioController(IConsultorioNegocio consultorioNegocio)
        {
            _consultorioNegocio = consultorioNegocio;
        }



        [HttpGet]
        [Route("api/Consultorio")]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(Mapper.MapperConsultorio(_consultorioNegocio.RecuperaTodos()));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/Consultorio/Insere")]
        public IHttpActionResult Insere(Consultorio consultorio)
        {
            try
            {
                 _consultorioNegocio.Insere(consultorio);
                return Ok(Mapper.MapperConsultorio(_consultorioNegocio.RecuperaTodos()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPut]
        [Route("api/Consultorio/Update")]
        public IHttpActionResult Update(Consultorio consultorio)
        {
            try
            {
                _consultorioNegocio.Atualiza(consultorio);
                return Ok(Mapper.MapperConsultorio(_consultorioNegocio.RecuperaTodos()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/Consultorio/Delete/{id}")]
        public IHttpActionResult Delete(long id)
        {
            try
            {
                _consultorioNegocio.Deleta(id);
                return Ok(Mapper.MapperConsultorio(_consultorioNegocio.RecuperaTodos()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}