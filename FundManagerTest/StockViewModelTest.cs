﻿using FundManagerApp.Models;
using FundManagerApp.ViewModels;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagerTest
{
    [TestFixture]
    public class StockViewModelTest
    {
        [Test]
        public void IsHighlighted_retuns_false_by_default()
        {
            // Arrange
            StockViewModel vm = new StockViewModel(new Stock(StockType.Bond, 10000, 1000, 10, String.Empty, Mock.Of<IStockWeightCalculator>()));

            // Act, Assert
            Assert.IsFalse(vm.IsHighlighted);            
        }

        [Test]
        public void IsHighlighted_retuns_true_when_MarketValue_less_then_zero()
        {
            // Arrange
            StockViewModel vm = new StockViewModel(new Stock(StockType.Bond, -100, 100, 10, String.Empty, Mock.Of<IStockWeightCalculator>()));

            // Act, Assert
            Assert.IsTrue(vm.IsHighlighted);
        }

        [Test]
        public void IsHighlighted_retuns_true_when_TransactionCost_less_then_tolerance_for_Bond()
        {
            // Arrange
            StockViewModel vm = new StockViewModel(new Stock(StockType.Bond, 1000, 99, 1, String.Empty, Mock.Of<IStockWeightCalculator>()));

            // Act, Assert
            Assert.IsTrue(vm.IsHighlighted);
        }

        [Test]
        public void IsHighlighted_retuns_true_when_TransactionCost_less_then_tolerance_for_Equity()
        {
            // Arrange
            StockViewModel vm = new StockViewModel(new Stock(StockType.Equity, 199, 1000, 1, String.Empty, Mock.Of<IStockWeightCalculator>()));

            // Act, Assert
            Assert.IsTrue(vm.IsHighlighted);
        }
    }
}
