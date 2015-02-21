using BudgetTracker.Core.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.Calculations
{
    public static class Calculator
    {
        private static DateTime GetIncrement(DateTime date, Frequency frequency, bool forwards)
        {
            switch (frequency)
            {
                case Frequency.Weekly:
                    return forwards ? date.AddDays(7) : date.AddDays(-7);
                case Frequency.Fortnightly:
                    return forwards ? date.AddDays(14) : date.AddDays(-14);
                case Frequency.Monthly:
                    return forwards ? date.AddMonths(1) : date.AddMonths(-1);
                case Frequency.HalfYearly:
                    return forwards ? date.AddMonths(6) : date.AddMonths(-6);
                case Frequency.Yearly:
                    return forwards ? date.AddYears(1) : date.AddYears(-1);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static DateTime GetNextDate(this DateTime date, Frequency frequency)
        {
            return GetIncrement(date, frequency, true);
        }

        public static DateTime GetPreviousDate(this DateTime date, Frequency frequency)
        {
            return GetIncrement(date, frequency, false);
        }
    }
}
