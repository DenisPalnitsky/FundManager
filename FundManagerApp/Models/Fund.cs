using System;
using System.Collections.Generic;
using System.Linq;

namespace FundManagerApp.Models
{
    public delegate void StockListChangedEventHandler(object sender, EventArgs e);

    class Fund : IFundSummaryProvider
    {
        private readonly IStockWeightCalculator _stockWeightCalculator;
        private readonly StockFactory _stockFactory;
        private readonly ICommissionProvider _commissionProvider;

        public readonly List<Stock> _stocks = new List<Stock>();

        public IEnumerable<Stock> Stocks
        {
            get { return _stocks; }
        }

        public decimal TotalMarketValue { get { return _stocks.Sum(t => t.MarketValue); } }

        public Fund()
        {
            _stockWeightCalculator = new StockWeightCalculator(this);
            _commissionProvider = new CommissionProvider();
            _stockFactory = new StockFactory(_stockWeightCalculator, _commissionProvider);
        }

        public void AddStock(StockType stockType, decimal price, int quantity)
        {
            _stocks.Add(_stockFactory.CreateStock(stockType, price, quantity, GetStockName(stockType)));
            OnStockListChanged(this, null);
        }

        public event StockListChangedEventHandler OnStockListChanged;

        private string GetStockName(StockType stockType)
        {
            var stockNames = new HashSet<string>(_stocks.Where(s => s.StockType == stockType).Select(s => s.Name));
            int idCandidate = stockNames.Count+1;
            string name = FormatStockName(stockType, idCandidate);

            while (stockNames.Contains(name))
            {
                idCandidate++;
                name = FormatStockName(stockType, idCandidate);
            }

            return name;    
        }

        private static string FormatStockName(StockType stockType, int idCandidate)
        {
            return string.Format("{0}{1}", stockType, idCandidate);            
        }
    }
}
