using Nancy;
using Nancy.Bootstrapper;
using SquishIt.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetTracker.Web.Configuration
{
    public class BundleConfig
    {
        public static void RegisterBundlePipeline(IPipelines pipelines)
        {
            RegisterBundles();
            pipelines.BeforeRequest += ctx => RegisterPipeline(ctx);
        }

        private static void RegisterBundles()
        {
            Bundle.Css()
                .Add("~/Content/bootstrap.css")
                .Add("~/Content/font-awesome.css")
                .Add("~/Content/site.css")
                .WithMinifier<SquishIt.Framework.Minifiers.CSS.YuiMinifier>()
                .AsCached("css", "~/Content/css");

            Bundle.JavaScript()
                .Add("~/Scripts/jquery-2.1.1.js")
                .Add("~/Scripts/bootstrap.js")
                .Add("~/Scripts/angular.js")
                .WithMinifier<SquishIt.Framework.Minifiers.JavaScript.MsMinifier>()
                .AsCached("js", "~/Scripts/js");
        }

        private static Response RegisterPipeline(NancyContext ctx)
        {
            ctx.ViewBag.Styles = Bundle.Css().RenderCached("css");
            ctx.ViewBag.Scripts = Bundle.JavaScript().RenderCached("js");
            return null;
        }
    }
}