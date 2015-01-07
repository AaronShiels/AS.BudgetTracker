using BudgetTracker.Core.Lookups;
using BudgetTracker.Core.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.Entities
{
    public class BudgetItemPayment
    {
        public Guid Id { get; set; }
        public Guid DefinitionId { get; set; }
        public DateTime DateDue { get; set; }
        public DateTime? DatePaid { get; set; }

        public virtual BudgetItemDefinition Definition { get; set; }

        public void Pay(DateTime paymentDate)
        {
            DatePaid = paymentDate.Date;
            
            var nextDateDue = GetDateNextDue(Definition.Frequency);

            if (nextDateDue.HasValue)
                Definition.Payments.Add(new BudgetItemPayment
                {
                    Id = Guid.NewGuid(),
                    DateDue = nextDateDue.Value
                });
        }

        private DateTime? GetDateNextDue(Frequency frequency)
        {
            switch (frequency)
            {
                case Frequency.Weekly:
                    return DateDue.AddDays(7);
                case Frequency.Fortnightly:
                    return DateDue.AddDays(14);
                case Frequency.Monthly:
                    return DateDue.AddMonths(1);
                case Frequency.HalfYearly:
                    return DateDue.AddMonths(6);
                case Frequency.Yearly:
                    return DateDue.AddYears(1);
                default:
                    return null;
            }
        }
    }
}
