using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.Exchange.Models;

namespace Vavatech.Exchange.Services
{
    public interface IExchangeService
    {
        List<ExchangeTable> GetExchangeTables();

        List<ExchangeRate> GetExchangeRates(DateTime exchangeDate);

        Task<List<ExchangeTable>> GetExchangeTablesAsync(); 

    }
}
