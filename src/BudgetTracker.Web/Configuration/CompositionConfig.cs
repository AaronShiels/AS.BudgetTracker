using BudgetTracker.Core.Context;
using Nancy.TinyIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetTracker.Web.Configuration
{
    public class CompositionConfig
    {
        public static void RegisterExports(TinyIoCContainer container)
        {
            container.Register<IBudgetTrackerDbContext>(new BudgetTrackerDbContext());
        }
    }
}