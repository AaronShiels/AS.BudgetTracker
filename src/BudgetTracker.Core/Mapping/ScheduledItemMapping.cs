﻿using BudgetTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.Mapping
{
    public class ScheduledItemMapping : EntityTypeConfiguration<ScheduledItem>
    {
        public ScheduledItemMapping()
        {
            ToTable("ScheduledItems");
            HasKey(e => e.Id);
        }
    }
}
