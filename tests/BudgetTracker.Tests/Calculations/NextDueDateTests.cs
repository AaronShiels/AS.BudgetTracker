using BudgetTracker.Core.Entities;
using BudgetTracker.Core.Lookups;
using Givn;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Tests.Calculations
{
    [TestFixture]
    public class NextDueDateTests
    {
        private Frequency _frequency;
        private decimal _amount;
        private DateTime _startDate;
        private DateTime? _endDate;
        private Collection<BudgetItemPayment> _payments;
        private BudgetItemDefinition _budgetItemDefinition;

        [Test]
        public void NewBudgetItemGivesFirstDate()
        {
            Giv.n(AWeeklySchedule)
               .And(AnAmount)
               .And(AStartingDate)
               .And(NoEndDate)
               .And(NoPaymentsMade);
            Wh.n(UsingABudgetItemDefinition);
            Th.n(FirstDateIsDueDate);
        }

        [Test]
        public void BudgetItemWithPaymentsGivesNextDate()
        {
            Giv.n(AWeeklySchedule)
               .And(AnAmount)
               .And(AStartingDate)
               .And(NoEndDate)
               .And(SomePaymentsMade);
            Wh.n(UsingABudgetItemDefinition);
            Th.n(NextIncrementDateIsDueDate);
        }

        [Test]
        public void BudgetItemWithAllPaymentsGivesNoDate()
        {
            Giv.n(AWeeklySchedule)
               .And(AnAmount)
               .And(AStartingDate)
               .And(AnEndDate)
               .And(AllPaymentsMade);
            Wh.n(UsingABudgetItemDefinition);
            Th.n(NoNextDueDate);
        }

        private void AWeeklySchedule()
        {
            _frequency = Frequency.Weekly;
        }

        private void AnAmount()
        {
            _amount = 10m;
        }

        private void AStartingDate()
        {
            _startDate = new DateTime(2015, 03, 28);
        }

        private void NoEndDate()
        {
            _endDate = null;
        }

        private void AnEndDate()
        {
            _endDate = _startDate.AddDays(28);
        }

        private void NoPaymentsMade()
        {
            _payments = new Collection<BudgetItemPayment>();
        }

        private void SomePaymentsMade()
        {
            _payments = new Collection<BudgetItemPayment>
            {
                new BudgetItemPayment(_startDate, _startDate),
                new BudgetItemPayment(_startDate.AddDays(7), _startDate.AddDays(7)),
                new BudgetItemPayment(_startDate.AddDays(14), _startDate.AddDays(14)),
                new BudgetItemPayment(_startDate.AddDays(21), _startDate.AddDays(21))
            };
        }

        private void AllPaymentsMade()
        {
            _payments = new Collection<BudgetItemPayment>
            {
                new BudgetItemPayment(_startDate, _startDate),
                new BudgetItemPayment(_startDate.AddDays(7), _startDate.AddDays(7)),
                new BudgetItemPayment(_startDate.AddDays(14), _startDate.AddDays(14)),
                new BudgetItemPayment(_startDate.AddDays(21), _startDate.AddDays(21)),
                new BudgetItemPayment(_startDate.AddDays(28), _startDate.AddDays(28))
            };
        }

        private void UsingABudgetItemDefinition()
        {
            _budgetItemDefinition = new BudgetItemDefinition(string.Empty, _amount, _frequency, _startDate, _endDate);
            _budgetItemDefinition.Payments = _payments;
        }

        private void FirstDateIsDueDate()
        {
            _budgetItemDefinition.GetNextDueDate().ShouldBe(_startDate);
        }

        private void NextIncrementDateIsDueDate()
        {
            _budgetItemDefinition.GetNextDueDate().ShouldBe(_startDate.AddDays(28));
        }

        private void NoNextDueDate()
        {
            _budgetItemDefinition.GetNextDueDate().ShouldBe((DateTime?)null);
        }
    }
}
