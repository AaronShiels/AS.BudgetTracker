using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetTracker.Web
{
    public class HelloWorldModule : NancyModule
    {
        public HelloWorldModule()
        {
            Get["/"] = _ => "Hello World";
        }
    }
}