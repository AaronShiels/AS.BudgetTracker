using BudgetTracker.Core.Context;
using BudgetTracker.Core.Entities;
using BudgetTracker.Core.Queries;
using Nancy;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetTracker.Web.Modules
{
    public class HelloModule : NancyModule
    {
        private readonly IBudgetTrackerDbContext _db;

        public HelloModule(IBudgetTrackerDbContext db)
        {
            _db = db;

            Get["/"] = _ => View["Index"];
            Get["/test"] = _ =>
            {
                var transactions = _db.Query(new BankTransaction.All()).ToList();
                return JsonConvert.SerializeObject(transactions);
            };
        }
    }
}