using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.Exchange.Models;

namespace Vavatech.Exchange.Services
{
    public class MockExchangeService : IExchangeService
    {
        private List<ExchangeTable> _ExchangeTables;

        public MockExchangeService()
        {
            this._ExchangeTables = new List<ExchangeTable>
            {
                new ExchangeTable
                {
                    Number = "062/A/NBP/2016",
                    ExchangeDate = DateTime.Parse("2016-03-31"),
                    ExchangeRates = new List<ExchangeRate>
                    {
                        new ExchangeRate
                        {
                            CurrencySymbol = "USD",
                            Ratio = 1,
                            CurrencyRate = 3.7590m,
                        },
                        new ExchangeRate
                        {
                            CurrencySymbol = "CHF",
                            Ratio = 1,
                            CurrencyRate = 3.9040m,
                        },
                        new ExchangeRate
                        {
                            CurrencySymbol = "EUR",
                            Ratio = 1,
                            CurrencyRate = 4.2684m,
                        }
                    }
                },


                 new ExchangeTable
                {
                    Number = "061/A/NBP/2016",
                    ExchangeDate = DateTime.Parse("2016-03-30"),
                    ExchangeRates = new List<ExchangeRate>
                    {
                        new ExchangeRate
                        {
                            CurrencySymbol = "USD",
                            Ratio = 1,
                            CurrencyRate = 3.4590m,
                        },
                        new ExchangeRate
                        {
                            CurrencySymbol = "CHF",
                            Ratio = 1,
                            CurrencyRate = 3.2040m,
                        },
                        new ExchangeRate
                        {
                            CurrencySymbol = "EUR",
                            Ratio = 1,
                            CurrencyRate = 4.1184m,
                        }
                    }
                }
            };
        }

        public List<ExchangeRate> GetExchangeRates(DateTime exchangeDate)
        {

            // Linq za pomocą metod rozszerzających
            var exchangeTable = this._ExchangeTables
                .Where(exchange => exchange.ExchangeDate == exchangeDate)
                .OrderBy(exchange => exchange.ExchangeDate)
                .SingleOrDefault();

            // Linq za pomocą quasi SQL
            //var exchangeTable2 = from exchange in _ExchangeTables
            //                     where exchange.ExchangeDate == exchangeDate
            //                     orderby exchange.ExchangeDate
            //                     select exchange;

            return exchangeTable.ExchangeRates;
        }

        public List<ExchangeTable> GetExchangeTables()
        {
            return _ExchangeTables;
        }

        public Task<List<ExchangeTable>> GetExchangeTablesAsync()
        {
            return Task.Run(() => GetExchangeTables());
        }

        public void Print()
        {

        }
    }
}
