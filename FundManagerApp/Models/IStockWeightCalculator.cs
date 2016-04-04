using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundManagerApp.Models
{
    interface IStockWeightCalculator
    {
        decimal CalculateStockWeight(decimal marketValue);
    }
}
