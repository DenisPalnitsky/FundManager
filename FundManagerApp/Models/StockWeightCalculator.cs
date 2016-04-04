using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagerApp.Models
{
    class StockWeightCalculator  : IStockWeightCalculator
    {
        readonly IFundSummaryProvider _fundSummary;

        public StockWeightCalculator(IFundSummaryProvider fund)
        {
            _fundSummary = fund;
        }

        public decimal CalculateStockWeight(decimal marketValue)
        {
            if (_fundSummary.TotalMarketValue == 0)
                throw new ArgumentException("Total market value is zero");
         
            return marketValue / (_fundSummary.TotalMarketValue / 100);
        }
    }
}
