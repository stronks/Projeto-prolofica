using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominio.Agendamento
{
    public class CadastroHorarioRequest
    {
    public string DataHoraMarcada { get; set; }
    public DadosPadroesCadastro Medico { get; set; }
    public DadosPadroesCadastro Paciente { get; set; }
    public DadosPadroesCadastro Consultorio { get; set; }
}

    public class DadosPadroesCadastro
    {
        public long id { get; set; }
        public long name { get; set; }

    }
}