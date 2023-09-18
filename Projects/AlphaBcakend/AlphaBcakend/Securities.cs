using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaBcakend
{
    public class Securities
    {
        public string BloombergId { get; set; }
        public string TransactionCode { get; set; }
        public string TradeDate { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
