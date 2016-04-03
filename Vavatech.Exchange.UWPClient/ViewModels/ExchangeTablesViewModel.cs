using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Vavatech.Exchange.Models;
using Vavatech.Exchange.Services;
using Vavatech.Exchange.UWPClient.Commands;

namespace Vavatech.Exchange.UWPClient.ViewModels
{
    public class ExchangeTablesViewModel : BaseViewModel
    {
        private List<ExchangeTable> _ExchangeTables;
        public List<ExchangeTable> ExchangeTables
        {
            get
            {
                return _ExchangeTables;
            }

            set
            {
                _ExchangeTables = value;

                OnPropertyChanged("ExchangeTables");
            }
        }

        private ExchangeTable _SelectedExchangeTable;

        public ExchangeTable SelectedExchangeTable
        {
            get { return _SelectedExchangeTable; }
            set
            {
                if (_SelectedExchangeTable != value)
                {
                    _SelectedExchangeTable = value;

                    OnPropertyChanged("SelectedExchangeTable");

                    OnPropertyChanged("BuyCommand");

                }
            }
        }



        public IExchangeService ExchangeService { get; set; }

        public ICommand BuyCommand { get; set; }

        public ExchangeTablesViewModel()
        {
            // this.ExchangeService = new MockExchangeService();

            // Unity
            this.ExchangeService = new NBPExchangeService();

            this.BuyCommand = new RelayCommand(() => Buy(), ()=>CanBuy());

            
        }

        public void Buy()
        {
            Debug.WriteLine("kupuj!");
        }

        public bool CanBuy()
        {
            return SelectedExchangeTable!=null;
        }

        public async Task Load()
        {
            this.ExchangeTables = await this.ExchangeService.GetExchangeTablesAsync();

        }


        

    }
}
