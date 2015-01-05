using BudgetTracker.Core.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.Entities
{
    public abstract class Identifier
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public decimal Amount { get; set; }
        public string TransactionIdentifier { get; set; }

        public bool IsCredit()
        {
            return Amount >= 0;
        }

        public bool IsDebit()
        {
            return Amount < 0;
        }

        public abstract DateTime? GetDateNextDue();
    }
}
