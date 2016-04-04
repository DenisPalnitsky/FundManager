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
    class StockFactoryTest
    {
                  
        [TestCase(StockType.Bond)]
        [TestCase(StockType.Equity)]
        public void CreateStock_returns_initialized_stock(StockType stockType)
        {
            // Arrange 
            StockFactory stockFactory = new StockFactory(Mock.Of<IStockWeightCalculator>(),
                Mock.Of<ICommissionProvider>());

            // Act
            var actualStock = stockFactory.CreateStock(stockType, 1, 2, String.Empty);

            // Assert
            AssertStockFieldsAreInitialized(stockType, 1, 2, actualStock);            
        }

        private static void AssertStockFieldsAreInitialized(
            StockType expectedStockType, 
            decimal expectedPrice, 
            int expectedQuantity, 
            Stock actualStock)
        {
            Assert.AreEqual(expectedStockType, actualStock.StockType);
            Assert.AreEqual(expectedPrice, actualStock.Price);
            Assert.AreEqual(expectedQuantity, actualStock.Quantity);
        }


        [TestCase(StockType.Bond)]
        [TestCase(StockType.Equity)]
        public void CreateEquity_takes_commistion_from_CommissionProvider(StockType stockType)
        {
            // Arrange
            var commissionProviderMock = new Mock<ICommissionProvider>(MockBehavior.Strict);
            commissionProviderMock.Setup(c => c[stockType]).Returns(10);
                        
            StockFactory stockFactory = new StockFactory(
                Mock.Of<IStockWeightCalculator>(),
                commissionProviderMock.Object);

            // Act 
            var stock = stockFactory.CreateStock(stockType, 1, 2, "");

            // Assert 
            Assert.AreEqual(10, stock.Comission);
        }

        [Test]
        public void CreateMethods_throws_ArgumentException_when_preice_or_quntity_less_then_zero()
        {
            StockFactory stockFactory = new StockFactory(Mock.Of<IStockWeightCalculator>(),
               Mock.Of<ICommissionProvider>());

            Assert.Throws<ArgumentException>(() => stockFactory.CreateStock(StockType.Bond, -1, 1, String.Empty));
            Assert.Throws<ArgumentException>(() => stockFactory.CreateStock(StockType.Equity, -1, 1, String.Empty));

            Assert.Throws<ArgumentException>(() => stockFactory.CreateStock(StockType.Bond, 1, -1, String.Empty));
            Assert.Throws<ArgumentException>(() => stockFactory.CreateStock(StockType.Equity, 1, -1, String.Empty));
        }
    }
}
