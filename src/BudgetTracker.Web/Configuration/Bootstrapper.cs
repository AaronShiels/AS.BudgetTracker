using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using SquishIt.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetTracker.Web.Configuration
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            BundleConfig.RegisterBundlePipeline(pipelines);

            base.ApplicationStartup(container, pipelines);
        }

        protected override void ConfigureApplicationContainer(Nancy.TinyIoc.TinyIoCContainer container)
        {
            CompositionConfig.RegisterExports(container);

            base.ConfigureApplicationContainer(container);
        }
    }
}