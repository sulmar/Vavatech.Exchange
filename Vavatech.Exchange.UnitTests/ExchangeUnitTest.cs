using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Vavatech.Exchange.Services;
using System.Collections.Generic;
using Vavatech.Exchange.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Vavatech.Exchange.UnitTests
{
    [TestClass]
    public class ExchangeUnitTest
    {

        [TestMethod]
        public async Task GetExchangeTablesAsyncTest()
        {
            IExchangeService exchangeService = new NBPExchangeService();

            var exchangeTables = await exchangeService.GetExchangeTablesAsync();

            Assert.IsNotNull(exchangeTables);

            Assert.IsTrue(exchangeTables.Any());

        }



        [TestMethod]
        public void GetExchangeTablesTest()
        {
            IExchangeService exchangeService = new MockExchangeService();

            var exchangeTables = exchangeService.GetExchangeTables();

            Assert.IsNotNull(exchangeTables);

            Assert.IsTrue(exchangeTables.Any());

        }

        [TestMethod]
        public void GetExchangeRatesTest()
        {
            var exchangeDate = DateTime.Parse("2016-03-31");

            IExchangeService exchangeService = new NBPExchangeService();

            var exchangeRates = exchangeService.GetExchangeRates(exchangeDate);

            Assert.IsNotNull(exchangeRates);

            Assert.IsTrue(exchangeRates.Any());

            var exchangeRate = exchangeRates.First();

            Assert.IsTrue(exchangeRate.CurrencyRate > 0, "CurrencyRate musi byc wieksze od 0");

            Assert.IsTrue(exchangeRate.Ratio > 0, "Ratio musi byc wieksze od 0");

            Assert.IsTrue(!String.IsNullOrEmpty(exchangeRate.CurrencySymbol));

            Assert.AreEqual(3, exchangeRate.CurrencySymbol.Length);


        }


    }
}
