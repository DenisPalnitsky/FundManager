using FundManagerApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagerApp.ViewModels
{
    class FundViewModel : INotifyPropertyChanged
    {
        Fund _fund = new Fund();

        public IEnumerable<StockViewModel> Stocks
        {
            get
            {
                return _fund.Stocks.Select(s => new StockViewModel(s));
            }
        }

        public FundViewModel ( )
        {
            _fund.AddStock(StockType.Bond, 1000, 100);
            _fund.AddStock(StockType.Equity, 500, 200);
            _fund.AddStock(StockType.Equity, 700, 400);                        
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
