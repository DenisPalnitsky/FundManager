using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundManagerApp.ViewModels
{
    class StockViewModel
    {
        private Models.Stock _stock;

        // not the best way to expose properties in ViewModel                
        public Models.Stock Stock { get { return _stock; }}

        public StockViewModel(Models.Stock stock)
        {            
            _stock = stock;
        }
    }
}
