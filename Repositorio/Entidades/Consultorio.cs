using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Entidades
{
    public class Consultorio:EntidadeBase
    {
        public string Nome { get; set; }

        public List<HorarioAgenda> HorarioAgendaList { get; set; }
    }
}
