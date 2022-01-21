using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Prologica.Models
{
    // Models returned by AccountController actions.
    public class HorarioAgendaViewModel
    {
        public List<MedicoViewModel> medicos { get; set; }
        public List<PacienteViewModel> pacientes { get; set; }
        public List<ConsultorioViewModel> consultorios { get; set; }
    }


}
