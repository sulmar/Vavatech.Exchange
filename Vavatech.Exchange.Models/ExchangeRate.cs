using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.Exchange.Models
{
    public class ExchangeRate : Base
    {
        public string CurrencySymbol { get; set; }

        public int Ratio { get; set; }

        public decimal CurrencyRate { get; set; }
    }
}
