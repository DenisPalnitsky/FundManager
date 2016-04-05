using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundManagerApp.ViewModels
{
    class SummaryViewModel
    {
        public string Title { get; set; }

        public int TotalNumber { get; set; }
        public decimal TotalStockWeight { get; set; }
        public decimal TotalMarketValue { get; set; }
    }
}
