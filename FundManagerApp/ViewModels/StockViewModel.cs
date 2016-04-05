using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundManagerApp.ViewModels
{
    class StockViewModel
    {
        private Models.Stock _stock;
        public const decimal BondTolerance = 100000;
        public const decimal EquityTolerance = 200000;
        
        // not the best way to expose properties in ViewModel                
        public Models.Stock Stock { get { return _stock; }}

        
        public bool IsHighlighted
        {
            get 
            {
                if (Stock.MarketValue < 0) return true;

                switch (Stock.StockType)
                {
                    case FundManagerApp.Models.StockType.Bond:
                        return Stock.TransactionCost > BondTolerance;
                    case FundManagerApp.Models.StockType.Equity:
                        return Stock.TransactionCost > EquityTolerance;                                        
                }

                return false;
            }            
        }

        public StockViewModel(Models.Stock stock)
        {            
            _stock = stock;
        }
    }
}
