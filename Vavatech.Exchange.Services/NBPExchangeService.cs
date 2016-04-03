using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Vavatech.Exchange.Models;

namespace Vavatech.Exchange.Services
{
    public class NBPExchangeService : IExchangeService
    {

        private const string uri = "http://www.nbp.pl/kursy/xml/dir.txt";


        public List<ExchangeRate> GetExchangeRates(DateTime exchangeDate)
        {
            throw new NotImplementedException();
        }

        public List<ExchangeTable> GetExchangeTables()
        {
            throw new NotImplementedException();
        }

        public async Task<List<ExchangeTable>> GetExchangeTablesAsync()
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            var response = await client.SendAsync(request);

            using (HttpContent content = response.Content)
            {
                string result = await content.ReadAsStringAsync();

                // parsowanie

                var items = Regex.Split(result, "\r\n");


                var exchangeTables = items
                    .Where(item => !string.IsNullOrEmpty(item))
                    .Select(item =>
                    new ExchangeTable
                    {
                       Number = item.Substring(0, 5),
                       ExchangeDate = DateTime.ParseExact(item.Substring(5, 6), "yyMMdd", CultureInfo.InvariantCulture),
                    }).ToList();

                return exchangeTables;


            }


        }
    }
}
