using BudgetTracker.Core.Context;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetTracker.Web.Modules
{
    public class HelloModule : NancyModule
    {
        public HelloModule(IBudgetTrackerDbContext db)
        {
            Get["/"] = _ => View["Index"];
        }
    }
}