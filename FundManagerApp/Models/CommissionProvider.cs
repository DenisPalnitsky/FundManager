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
                        return 0.5M;

                    case StockType.Equity:
                        return 2;

                    default:
                        throw new NotSupportedException("This stock type is not supported");
                }
            }
        }
    }
}
