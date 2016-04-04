using FundManagerApp.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagerTest
{
    [TestFixture]
    public class FundTest
    {
        [Test]
        public void AddStock_adds_stock_to_fund()
        {
            // Arrange 
            Fund fund = new Fund();

            // Act
            fund.AddStock(StockType.Bond, 1, 2);

            // Assert
            Assert.AreEqual(1, fund.Stocks.Count());
        }

        [Test]
        public void AddStock_generates_stock_id_in_numerical_order()
        {            
            Fund fund = new Fund();
            
            fund.AddStock(StockType.Bond, 1, 2);
            Assert.That(fund.Stocks.Any(s => s.Name =="Bond1"));

            fund.AddStock(StockType.Bond, 1, 2);
            Assert.That(fund.Stocks.Any(s => s.Name =="Bond2"));

            fund.AddStock(StockType.Equity, 1, 2);
            Assert.That(fund.Stocks.Any(s => s.Name == "Equity1"));

            fund.AddStock(StockType.Equity, 1, 2);
            Assert.That(fund.Stocks.Any(s => s.Name == "Equity2"));            
        }
    }
}
