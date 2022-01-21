using Autofac;
using Prologica.App_Start;
using Repositorio.Entidades;
using Repositorio.Interface;
using Repositorio.Interfaces;
using Repositorio.Repositorios;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Prologica
{
    public class MvcApplication : HttpApplication
    {

        protected void Application_Start()
        {



            DependencyInjection.Run();


            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


    }
}
