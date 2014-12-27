using BudgetTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.Mapping
{
    public class TransactionMapping : EntityTypeConfiguration<Transaction>
    {
        public TransactionMapping()
        {
            ToTable("Transactions");
            HasKey(e => e.Id);
        }
    }
}
