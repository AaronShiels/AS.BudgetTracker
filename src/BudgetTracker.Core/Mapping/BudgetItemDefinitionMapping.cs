using BudgetTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.Mapping
{
    public class BudgetItemDefinitionMapping : EntityTypeConfiguration<BudgetItemDefinition>
    {
        public BudgetItemDefinitionMapping()
        {
            ToTable("BudgetItemDefinitions");

            HasKey(e => e.Id);
            Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasMany(e => e.Payments).WithRequired(e => e.Definition).HasForeignKey(e => e.DefinitionId);
        }
    }
}
