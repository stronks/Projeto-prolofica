using Dominio.Agendamento;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using Prologica.Models;
using Prologica.Utils;
using Repositorio.Entidades;
using Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Prologica.Controllers
{

    public class HorarioAgendaController : ApiController
    {
        private readonly IHorarioAgendaNegocio _horarioAgendaNegocio;
        public HorarioAgendaController(IHorarioAgendaNegocio horarioAgendaNegocio)
        {
            _horarioAgendaNegocio = horarioAgendaNegocio;
        }


        [HttpGet]
        [Route("api/HorarioAgenda")]
        public IEnumerable<ConsultaAgendadas> Get()
        {
            var result = _horarioAgendaNegocio.RecuperaTodos();
            return result;
        }

        [HttpPost]
        [Route("api/HorarioAgenda/Insere")]
        public IHttpActionResult Insere(CadastroHorarioRequest HorarioAgenda)
        {
            try
            {
                _horarioAgendaNegocio.Insere(HorarioAgenda);
                return Ok(_horarioAgendaNegocio.RecuperaTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPut]
        [Route("api/HorarioAgenda/Update")]
        public IHttpActionResult Update(HorarioAgenda HorarioAgenda)
        {
            try
            {
                _horarioAgendaNegocio.Atualiza(HorarioAgenda);
                return Ok(_horarioAgendaNegocio.RecuperaTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/HorarioAgenda/Delete/{id}")]
        public IHttpActionResult Delete(long id)
        {
            try
            {
                _horarioAgendaNegocio.Deleta(id);
                return Ok(_horarioAgendaNegocio.RecuperaTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}