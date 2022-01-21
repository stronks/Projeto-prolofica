using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Entidades
{
    public class ConsultaAgendadas : EntidadeBase
    {
        public string DataHoraMarcada { get; set; }
        public string Medico { get; set; }
        public string Consultorio { get; set; }
        public string Paciente { get; set; }
      
    }
}
