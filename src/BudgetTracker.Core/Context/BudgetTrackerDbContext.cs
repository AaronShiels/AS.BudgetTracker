﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.Context
{
    public class BudgetTrackerDbContext : IBudgetTrackerDbContext
    {
        public string DoSomething()
        {
            return "YOLO";
        }
    }
}