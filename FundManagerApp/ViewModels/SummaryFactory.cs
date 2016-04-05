using FundManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagerApp.ViewModels
{
    class SummaryFactory
    {
        IEnumerable<Stock> _stocks;

        public SummaryFactory(IEnumerable<Stock> stocks) 
        {
            _stocks = stocks;
        }

        public SummaryViewModel CreateSummary(StockType stockType)
        {
            return CreateSummary(_stocks.Where(s => s.StockType == stockType), stockType.ToString());
        }

        public SummaryViewModel CreateSummary()
        {
            return CreateSummary(_stocks, "Overall");
        }

        static SummaryViewModel CreateSummary(IEnumerable<Stock> stocks, string title)
        {
            return new SummaryViewModel()
            {
                Title = title,
                TotalNumber = stocks.Count(),
                TotalMarketValue = stocks.Sum(s => s.MarketValue),
                TotalStockWeight = stocks.Sum(s => s.StockWeight),
            };
        }


    }
}
