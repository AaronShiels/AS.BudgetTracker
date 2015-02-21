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

        public BudgetItemDefinition(string description, decimal amount, Frequency frequency, DateTime dateFirst, DateTime? dateLast = null, string transactionIdentifier = null)
        {
            Id = Guid.NewGuid();
            DateCreated = DateTimeOffset.Now;
            Description = description;
            Amount = amount;
            DateFirst = dateFirst;
            DateLast = dateLast;
            Frequency = frequency;
            TransactionIdentifier = transactionIdentifier;
        }

        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTime DateFirst { get; set; }
        public DateTime? DateLast { get; set; }
        public decimal Amount { get; set; }
        public Frequency Frequency { get; set; }
        public string TransactionIdentifier { get; set; }
        public virtual ICollection<BudgetItemPayment> Payments { get; set; }

        public bool IsCredit()
        {
            return Amount >= 0;
        }

        public bool IsDebit()
        {
            return Amount < 0;
        }

        public DateTime? GetNextDueDate()
        {
            var nextUnmetDate = DateFirst;

            if (!Payments.Any())
                return nextUnmetDate;

            var topMetPayment = Payments.Max(p => p.DateDue);

            if (topMetPayment >= DateLast)
                return null;

            while (nextUnmetDate <= topMetPayment)
                nextUnmetDate = nextUnmetDate.GetNextDate(Frequency);

            return nextUnmetDate;
        }

        public class ByAll : IQuery<BudgetItemDefinition>
        {
            public IQueryable<BudgetItemDefinition> Filter(IQueryable<BudgetItemDefinition> items)
            {
                return items;
            }
        }
    }
}
