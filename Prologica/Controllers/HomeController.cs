using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Prologica.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Medicos()
        {
            return View();
        }
        public ActionResult Pacientes()
        {
            return View();

        }
        public ActionResult Agendamentos()
        {
            return View();
        }

        public ActionResult Consultorios()
        {
            return View();
        }
        
    }
}
