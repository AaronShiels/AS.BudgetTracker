using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.Entities
{
    public class OneOffIdentifier : Identifier
    {
        public DateTime DateDue { get; set; }
        public DateTime? DatePaid { get; set; }

        public override DateTime? GetDateNextDue()
        {
            return DatePaid.HasValue ? (DateTime?)null : DateDue;
        }
    }
}
