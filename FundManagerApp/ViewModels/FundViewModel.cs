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
                return _fund.Stocks.Select(s => new StockViewModel(s));
            }
        }

        public ICommand AddEquity;
        public ICommand AddBond;

        public FundViewModel ( )
        {
            //_fund.AddStock(StockType.Bond, 1000, 100);
            //_fund.AddStock(StockType.Equity, 500, 200);
            //_fund.AddStock(StockType.Equity, 700, 400);

            CommandsDeclaration();
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
        }

    }
}
