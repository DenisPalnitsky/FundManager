using FundManagerApp.Models;
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
    public class StockTest
    {
        [Test]
        public void MarketValue_returns_multiplication_of_price_and_quantity()
        {
            // Arrange
            var stock = new Stock(StockType.Bond, 2, 3, 0, String.Empty, Mock.Of<IStockWeightCalculator>());

            // Act, Assert
            Assert.AreEqual(6,  stock.MarketValue );
            
        }
    }
}
