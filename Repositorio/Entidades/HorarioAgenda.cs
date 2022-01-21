using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Entidades
{
    public class HorarioAgenda: EntidadeBase
    {
        public DateTime DataHoraMarcada { get; set; }
        public string Nome { get; set; }
        public long IdMedico  { get; set; }
        public long IdPaciente { get; set; }
        public long IdConsultorio { get; set; }
    }
}
