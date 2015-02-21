using BudgetTracker.Core.Context;
using BudgetTracker.Core.Entities;
using BudgetTracker.Core.Queries;
using Magnum.Extensions;
using Nancy;
using Newtonsoft.Json;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BudgetTracker.Core.Calculations;

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
                return transactions;
            };

            Get["/due"] = _ =>
            {
                /*return _db.Query(new BudgetItemPayment.ByUpcoming())
                    .AsQueryable()
                    .Include(p => p.Definition)
                    .ToList()
                    .Select(p => string.Format("{0} is due on {1} for {2:C}", p.Definition.Description, p.DateDue.ToShortDateString(), p.Definition.Amount));
                 */

                return null;
            };

            Get["/budget"] = _ =>
            {
                /*var upcomingPayments = _db.Query(new BudgetItemPayment.ByUpcoming())
                                        .AsQueryable()
                                        .Include(p => p.Definition)
                                        .ToList();

                var today = new DateTime(2014, 12, 26);

                var creditPayments = upcomingPayments.Where(p => p.Definition.IsCredit()).ToList();
                var debitPayments = upcomingPayments.Where(p => p.Definition.IsDebit()).ToList();
                */


                return null;
            };
        }
    }
}