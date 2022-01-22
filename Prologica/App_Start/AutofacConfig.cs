using AEC.Repositorio;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Repositorio.Entidades;
using Repositorio.Interface;
using Repositorio.Interfaces;
using Repositorio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Mvc;

namespace Prologica.App_Start
{
    public class AutofacConfig
    {
        public static System.ComponentModel.IContainer Container;
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);


            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); //Set the MVC DependencyResolver
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container); //Set the WebApi DependencyResolver
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly‌​());

             RegistraClassesConnectionStringDependencia(builder);
             RegistraClassesRepositoriosInjecaoDependencia(builder, connectionString);
             RegistraClassesNegocioInjecaoDependencia(builder);


            var container = builder.Build();
            return container;
        }


        private static void RegistraClassesRepositoriosInjecaoDependencia(ContainerBuilder builder, string connectionString)
        {

            builder.RegisterType<RepositorioBase<Medico>>()
                .As<IRepositorioBase<Medico>>()
                .WithParameter("connectionString", connectionString)            
                .InstancePerLifetimeScope();


            builder.RegisterType<RepositorioBase<Paciente>>()
                .As<IRepositorioBase<Paciente>>()
                .WithParameter("connectionString", connectionString)
                .InstancePerLifetimeScope();


            builder.RegisterType<RepositorioBase<Consultorio>>()
                .As<IRepositorioBase<Consultorio>>()
                .WithParameter("connectionString", connectionString)
                .InstancePerLifetimeScope();


            builder.RegisterType<RepositorioBase<HorarioAgenda>>()
                .As<IRepositorioBase<HorarioAgenda>>()
                .WithParameter("connectionString", connectionString)
                .InstancePerLifetimeScope();
        }

        private static void RegistraClassesNegocioInjecaoDependencia(ContainerBuilder builder)
        {
            builder.RegisterType<MedicoNegocio>()
                .As<IMedicoNegocio>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ConsultorioNegocio>()
                .As<IConsultorioNegocio>()
                .InstancePerLifetimeScope();

            builder.RegisterType<HorarioAgendaNegocio>()
                .As<IHorarioAgendaNegocio>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PacienteNegocio>()
                .As<IPacienteNegocio>()
                .InstancePerLifetimeScope();

        }
        private static void RegistraClassesConnectionStringDependencia(ContainerBuilder builder)
        {
            string ttt = "teste";
            builder.RegisterType<ConexaoBancoDadosRepositorio>()
               
                .As<IConexaoBancoDadosRepositorio>()
                .InstancePerLifetimeScope();

        }

    }
}