using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundManagerApp.ViewModels
{
    class StockViewModel
    {
        private Models.Stock _stock;

        public string Name { get { return String.Format("{0}{1}", _stock.StockType, _stock.Name); } }

        public decimal Price
        {
            get
            {
                return _stock.Price;
            }
        }

        public decimal Quantity
        {
            get
            {
                return _stock.Quantity;
            }
        }

        public decimal StockWeight
        {
            get
            {
                return _stock.StockWeight;
            }
        }

        public decimal MarketValue
        {
            get
            {
                return _stock.MarketValue;
            }
        }

        public StockViewModel(Models.Stock stock)
        {            
            _stock = stock;
        }
    }
}
