using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace Prologica
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive*",
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                "~/Scripts/knockout-3.5.0.js",
                "~/Scripts/jquery-3.4.1.min.js",
                "~/Content/StyleAgenda.css"));


            bundles.Add(new ScriptBundle("~/bundles/pages"));


            bundles.Add(new ScriptBundle("~/bundles/medicos").Include(
                       "~/Scripts/RequestsKnockout/MedicoJS.js"));


            bundles.Add(new ScriptBundle("~/bundles/consultorios").Include(
                       "~/Scripts/RequestsKnockout/ConsultorioJS.js"));


            bundles.Add(new ScriptBundle("~/bundles/pacientes").Include(
                       "~/Scripts/RequestsKnockout/PacienteJS.js"));


            bundles.Add(new ScriptBundle("~/bundles/horarioagenda").Include(
                       "~/Scripts/RequestsKnockout/HorarioAgendaJS.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Scripts/sammy-{version}.js",
                "~/Scripts/app/common.js",
                "~/Scripts/bootstrap.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Content/bootstrap.css",
                 "~/Content/Site.css"));
        }
    }
}
