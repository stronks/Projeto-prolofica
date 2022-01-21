using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Prologica.Models
{
    // Models returned by AccountController actions.
    public class PacienteViewModel
    {
        public string Nome { get; set; }

 
        public long Id { get; set; }
    }

  
}
