using BudgetTracker.Core.Lookups;
using BudgetTracker.Core.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.Entities
{
    public class ScheduledIdentifier : Identifier
    {
        public DateTime DateLastDue { get; set; }
        public DateTime? DateLastPaid { get; set; }
        public Frequency Frequency { get; set; }

        public override DateTime? GetDateNextDue()
        {
            switch (Frequency)
            {
                case Frequency.Weekly:
                    return DateLastDue.AddDays(7);
                case Frequency.Fortnightly:
                    return DateLastDue.AddDays(14);
                case Frequency.Monthly:
                    return DateLastDue.AddMonths(1);
                case Frequency.HalfYearly:
                    return DateLastDue.AddMonths(6);
                case Frequency.Yearly:
                    return DateLastDue.AddYears(1);
                default:
                    return null;
            }
        }

        public class All : IQuery<ScheduledIdentifier>
        {
            public IQueryable<ScheduledIdentifier> Filter(IQueryable<ScheduledIdentifier> items)
            {
                return items;
            }
        }
    }
}
