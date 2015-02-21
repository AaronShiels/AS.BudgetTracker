using BudgetTracker.Core.Lookups;
using BudgetTracker.Core.Queries;
using BudgetTracker.Core.Calculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.Entities
{
    public class BudgetItemPayment
    {
        protected BudgetItemPayment() { }

        public BudgetItemPayment(DateTime dateDue, DateTime datePaid)
        {
            Id = Guid.NewGuid();
            DateDue = dateDue;
            DatePaid = datePaid;
        }

        public Guid Id { get; set; }
        public Guid DefinitionId { get; set; }
        public DateTime DateDue { get; set; }
        public DateTime DatePaid { get; set; }

        public virtual BudgetItemDefinition Definition { get; set; }
    }
}
