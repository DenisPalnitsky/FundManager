using FundManagerApp.Models;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FundManagerApp.ViewModels
{
    class FundViewModel : BindableBase
    {
        Fund _fund = new Fund();

        NewStockViewModel _newStockViewModel;

        public NewStockViewModel NewStockViewModel
        {
            get { return _newStockViewModel; }
            set { SetProperty(ref _newStockViewModel, value); }
        }

        public IEnumerable<StockViewModel> Stocks
        {
            get
            {
                return _fund.Stocks.Select(s => new StockViewModel(s)).ToList();
            }
        }

        public ICommand AddEquity { get; private set; }
        public ICommand AddBond { get; private set; }
        public FundSummaryViewModel FundSummaryViewModel  { get; private set; }


        public FundViewModel ( )
        {
            _fund.OnStockListChanged += Fund_OnStockListChanged;         
            CommandsDeclaration();
            FundSummaryViewModel = new FundSummaryViewModel();
            RecalculateSummaries();  
        }

        void Fund_OnStockListChanged(object sender, EventArgs e)
        {
            OnPropertyChanged(() => Stocks);
            RecalculateSummaries();  
        }

        private void RecalculateSummaries()
        {
            SummaryFactory summaryFactory = new SummaryFactory(_fund.Stocks);

            FundSummaryViewModel.BondSummary = summaryFactory.CreateSummary(StockType.Bond);
            FundSummaryViewModel.EquitySummary = summaryFactory.CreateSummary(StockType.Equity);
            FundSummaryViewModel.OverallSummary = summaryFactory.CreateSummary();
        }
        

        private void CommandsDeclaration()
        {                        
            AddEquity = new DelegateCommand(
                () => NewStockViewModel = new NewStockViewModel(StockType.Equity, AddStockToFund));

            AddBond = new DelegateCommand(
                () => NewStockViewModel = new NewStockViewModel(StockType.Bond, AddStockToFund));
        }

        private void AddStockToFund(NewStockViewModel newStock)
        {
            _fund.AddStock(newStock.StockType, newStock.Price, newStock.Quantity);            
            NewStockViewModel = null;
        }

    }
}
