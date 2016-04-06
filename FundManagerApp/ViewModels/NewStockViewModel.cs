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
    class NewStockViewModel : BindableBase
    {
        private decimal _price;
        private int _quantity;

        public decimal Price
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }        

        public int Quantity
        {
            get { return _quantity; }
            set { SetProperty(ref _quantity, value); }
        }

        public StockType StockType { get; private set; }

        public DelegateCommand AddItem { get; private set; }
        
        public NewStockViewModel(StockType stockType, Action<NewStockViewModel> addItemAction)
        {
            StockType = stockType;
            AddItem = new DelegateCommand(()=> addItemAction(this), ()=> Quantity > 0);
        }

        protected override bool SetProperty<T>(ref T storage, T value, string propertyName = null)
        {            
            var result = base.SetProperty<T>(ref storage, value, propertyName);
            AddItem.RaiseCanExecuteChanged();
            return result;
        }
    }
}
