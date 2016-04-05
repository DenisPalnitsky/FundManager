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

        [Test]
        public void TransactionCost_returns_multiplication_of_MarketValue_and_commission()
        {
            // Arrange
            var stock = new Stock(StockType.Bond, 10, 10, 0.005M, String.Empty, Mock.Of<IStockWeightCalculator>());

            // Act, Assert
            Assert.AreEqual(0.5, stock.TransactionCost);
        }


        [Test]
        public void StockWeight_returns_value_from_IStockWeightCalculator()
        {
            // Arrange
            var stockWeightCalculatorMock = new Mock<IStockWeightCalculator>(  MockBehavior.Strict );
            decimal expectedWeight = 50;            

            var stock = new Stock(StockType.Bond, 10, 10, 0.005M, String.Empty,
                stockWeightCalculatorMock.Object);
            stockWeightCalculatorMock.Setup(s=>s.CalculateStockWeight(stock.MarketValue)).Returns(expectedWeight);
            
            // Act, Assert
            Assert.AreEqual(expectedWeight, stock.StockWeight);
        }
    }
}
