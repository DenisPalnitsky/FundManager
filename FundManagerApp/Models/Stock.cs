
namespace FundManagerApp.Models
{
    /// <summary>
    /// Represents trade. Actual position in Fund.
    /// </summary>
    class Stock
    {
        readonly IStockWeightCalculator _stockWeightCalculator;

        public string Name { get; private set; }

        public decimal Price { get; private set; }

        public int Quantity { get; private set; }

        public decimal Comission { get; private set; }
        
        public StockType StockType { get; private set; }

        public decimal MarketValue { get { return Price * Quantity; } }

        public decimal TransactionCost { get { return MarketValue * Comission; } }

        public decimal StockWeight { get { return _stockWeightCalculator.CalculateStockWeight(MarketValue); } }

        // Although it's very tempting to create two separate Bond and Equity classes with Stock as base         
        // I can't find a reason for doing it right now. 
        // It's more likely that commmission is variable in time so there is no reason to hardcode it in subclasses
        public Stock (StockType stockType,   decimal price, int quantity, decimal commision, string name, IStockWeightCalculator stockWeightCalculator)
        {
            Price = price;
            Quantity = quantity;
            Comission = commision;
            StockType = stockType;
            Name = name;
            _stockWeightCalculator = stockWeightCalculator;       
        }    
              
    }
}
