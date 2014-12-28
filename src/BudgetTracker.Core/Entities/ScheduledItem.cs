using BudgetTracker.Core.Lookups;
using BudgetTracker.Core.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.Entities
{
    public class ScheduledItem
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public decimal Amount { get; set; }
        public DateTime IntendedLastDueDate { get; set; }
        public DateTime? ActualLastDueDate { get; set; }
        public Frequency Frequency { get; set; }
        public string TransactionIdentifier { get; set; }

        public bool IsCredit()
        {
            return Amount >= 0;
        }

        public bool IsDebit()
        {
            return Amount < 0;
        }

        public DateTime? GetDateNextDue()
        {
            switch (Frequency)
            {
                case Frequency.OnceOff:
                    return (ActualLastDueDate.HasValue ? IntendedLastDueDate : (DateTime?) null);
                case Frequency.Weekly:
                    return IntendedLastDueDate.AddDays(7);
                case Frequency.Fortnightly:
                    return IntendedLastDueDate.AddDays(14);
                case Frequency.Monthly:
                    return IntendedLastDueDate.AddMonths(1);
                case Frequency.HalfYearly:
                    return IntendedLastDueDate.AddMonths(6);
                case Frequency.Yearly:
                    return IntendedLastDueDate.AddYears(1);
                default:
                    return null;
            }
        }

        public class All : IQuery<ScheduledItem>
        {
            public IQueryable<ScheduledItem> Filter(IQueryable<ScheduledItem> items)
            {
                return items;
            }
        }
    }
}
