using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagerApp.Models
{
    class CommissionProvider : ICommissionProvider
    {        
        public decimal this[StockType stockType]
        {
            get 
            {
                switch (stockType)
                {
                    case StockType.Bond:
                        return 0.02M;

                    case StockType.Equity:
                        return 0.005M;

                    default:
                        throw new NotSupportedException("This stock type is not supported");
                }
            }
        }
    }
}
