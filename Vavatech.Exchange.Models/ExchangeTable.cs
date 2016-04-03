using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.Exchange.Models
{
    public class ExchangeTable : Base
    {
        /// <summary>
        /// Data notowania
        /// </summary>
        public DateTime ExchangeDate { get; set; }

        /// <summary>
        /// Numer tabeli kursu
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Notowania walut
        /// </summary>
        public List<ExchangeRate> ExchangeRates { get; set; }
    }
}
