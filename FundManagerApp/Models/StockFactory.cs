using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagerApp.Models
{
    class StockFactory
    {
        readonly ICommissionProvider _commissionProvider;
        readonly IStockWeightCalculator _tradeShareCalculator;

        public StockFactory(
            IStockWeightCalculator tradeShareCalculator,
            ICommissionProvider commissionProvider)
        {
            _commissionProvider = commissionProvider;
            _tradeShareCalculator = tradeShareCalculator;
        }

        public Stock CreateStock(StockType stockType, decimal price, int quantity, string id)
        {
            if (price < 0)
                throw new ArgumentException("Price cannot be less then zero");

            if (quantity < 0)
                throw new ArgumentException("Quantity cannot be less then zero");

            return new Stock(stockType, price, quantity, _commissionProvider[stockType], id, _tradeShareCalculator);            
        }        
    }
}
