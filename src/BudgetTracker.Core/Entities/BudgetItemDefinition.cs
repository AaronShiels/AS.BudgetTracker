using BudgetTracker.Core.Calculations;
using BudgetTracker.Core.Lookups;
using BudgetTracker.Core.Queries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.Entities
{
    public class BudgetItemDefinition
    {
        protected BudgetItemDefinition() { }

        public BudgetItemDefinition(string description, decimal amount, Frequency frequency, DateTime nextDateDue, string transactionIdentifier = null)
        {
            Id = Guid.NewGuid();
            DateCreated = DateTimeOffset.Now;
            Payments = new List<BudgetItemPayment>();

            Description = description;
            Amount = amount;
            Frequency = frequency;
            TransactionIdentifier = transactionIdentifier;

            Payments.Add(new BudgetItemPayment(nextDateDue));
        }

        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public decimal Amount { get; set; }
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

        public void UpdateSchedule(DateTime today)
        {
            if (Frequency == Frequency.OneOff)
                return;

            var mostRecentDueDate = Payments.Max(p => p.DateDue);
            while (mostRecentDueDate < today)
            {
                var nextDueDate = mostRecentDueDate.GetNextDate(Frequency);
                Payments.Add(new BudgetItemPayment(nextDueDate));

                mostRecentDueDate = nextDueDate;
            }
        }

        public virtual ICollection<BudgetItemPayment> Payments { get; set; }

        public class ByAll : IQuery<BudgetItemDefinition>
        {
            public IQueryable<BudgetItemDefinition> Filter(IQueryable<BudgetItemDefinition> items)
            {
                return items;
            }
        }
    }
}
