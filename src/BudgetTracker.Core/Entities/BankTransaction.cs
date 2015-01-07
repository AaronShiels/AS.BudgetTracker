using BudgetTracker.Core.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.Entities
{
    public class BankTransaction
    {
        public Guid Id { get; set; }
        public DateTimeOffset DateSynced { get; set; }
        public DateTime DateOccurred { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }

        public bool IsCredit()
        {
            return Amount >= 0;
        }

        public bool IsDebit()
        {
            return Amount < 0;
        }

        public class All : IQuery<BankTransaction>
        {
            public IQueryable<BankTransaction> Filter(IQueryable<BankTransaction> items)
            {
                return items;
            }
        }
    }
}
