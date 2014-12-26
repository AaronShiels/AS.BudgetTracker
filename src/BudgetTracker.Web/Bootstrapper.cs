using BudgetTracker.Core.Context;
using Nancy;
using SquishIt.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetTracker.Web
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(Nancy.TinyIoc.TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            Bundle.Css()
                .Add("~/Content/bootstrap.css")
                .Add("~/Content/font-awesome.css")
                .Add("~/Content/site.css")
                .AsCached("styles", "~/Content/styles");

            Bundle.JavaScript()
                .Add("~/Scripts/jquery-1.9.0.js")
                .Add("~/Scripts/bootstrap.js")
                .Add("~/Scripts/angular.js")
                .AsCached("js", "~/Scripts/js");
        }

        protected override void ConfigureApplicationContainer(Nancy.TinyIoc.TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register<IBudgetTrackerDbContext>(new BudgetTrackerDbContext());
        }
    }
}