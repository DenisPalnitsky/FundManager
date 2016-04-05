using FundManagerApp.Models;
using FundManagerApp.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagerTest
{
    [TestFixture]
    public class FundViewModelTest
    {
        [Test]
        public void AddEquity_command_creates_NewStockViewModel_with_Equity_as_stock_type()
        {
            FundViewModel fundVM = new FundViewModel();
            fundVM.AddEquity.Execute(null);
            Assert.AreEqual(StockType.Equity, fundVM.NewStockViewModel.StockType);            
        }

        [Test]
        public void AddBond_command_creates_NewStockViewModel_with_Bond_as_stock_type()
        {
            FundViewModel fundVM = new FundViewModel();
            fundVM.AddBond.Execute(null);
            Assert.AreEqual(StockType.Bond, fundVM.NewStockViewModel.StockType);
        }

        [Test]
        public void AddItem_command_in_NewStockViewModel_adds_bond_to_fund()
        {
            FundViewModel fundVM = new FundViewModel();
            
            fundVM.AddBond.Execute(null);
            fundVM.NewStockViewModel.AddItem.Execute();

            Assert.That(fundVM.Stocks.Single().Stock.StockType == StockType.Bond);            
        }

        [Test]
        public void AddItem_command_in_NewStockViewModel_adds_equity_to_fund()
        {
            FundViewModel fundVM = new FundViewModel();

            fundVM.AddEquity.Execute(null);
            fundVM.NewStockViewModel.AddItem.Execute();

            Assert.That(fundVM.Stocks.Single().Stock.StockType == StockType.Equity);
        }
    }
}
