using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Prologica.App_Start
{
    public class DependencyInjection
    {
        public static void Run()
        {
            //Configure AutoFac  
            AutofacConfig.Initialize(GlobalConfiguration.Configuration);
        }
    }
}