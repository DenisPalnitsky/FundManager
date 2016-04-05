using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagerApp.ViewModels
{
    class FundSummaryViewModel : BindableBase
    {
        SummaryViewModel _overall;
        SummaryViewModel _equity;
        SummaryViewModel _bond;

        public SummaryViewModel EquitySummary
        {
            get { return _equity; }
            set { SetProperty(ref _equity, value); }
        }

        public SummaryViewModel BondSummary
        {
            get { return _bond; }
            set { SetProperty(ref _bond, value); }
        }

        public SummaryViewModel OverallSummary
        {
            get { return _overall; }
            set { SetProperty(ref  _overall, value); }
        }
    }
}
