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
    public class StockWeightCalculatorTest
    {
        class FundSummaryProviderStub : IFundSummaryProvider
        {
            public FundSummaryProviderStub(decimal totalMarketValue)
            {
                TotalMarketValue = totalMarketValue;
            }

            public decimal TotalMarketValue
            {
                get; private set;
            }
        }

        [Test]
        public void CalculateStockWeight_returns_percentage_of_particular_stock()
        {
            // Arrange 
            StockWeightCalculator stockWeightCalculator = new StockWeightCalculator(new FundSummaryProviderStub(100));

            // Act
            var stockWeight = stockWeightCalculator.CalculateStockWeight(10);

            // Assert 
            Assert.AreEqual(10, stockWeight);
        }

        [Test]
        public void CalculateStockWeight_throws_exception_if_TotalMarketValue_is_zero()
        {
            // Arrange 
            StockWeightCalculator stockWeightCalculator = new StockWeightCalculator(new FundSummaryProviderStub(0));

            // Act, Assert
            Assert.Throws<ArgumentException>(() => stockWeightCalculator.CalculateStockWeight(10));
        }
    }
}
