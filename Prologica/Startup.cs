using Autofac;
using Microsoft.Owin;
using Owin;
using Repositorio.Entidades;
using Repositorio.Interface;
using Repositorio.Interfaces;
using Repositorio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Prologica
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

        }


    }
}
