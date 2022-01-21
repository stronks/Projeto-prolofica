using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Agendamento
{
    public  class ListaHorariosAgendados
    {
        public ListaHorariosAgendados()
        {
            horariosAgendados = new List<Horarios>();
        }
        List<Horarios> horariosAgendados { get; set; }
    }

    public class Horarios
    {
        public long id { get; set; }
        public string nomeMedico { get; set; }

        public string nomePaciente { get; set; }

        public string nomeConsultorio { get; set; }

        public string DataHora { get; set; }
    }
}
