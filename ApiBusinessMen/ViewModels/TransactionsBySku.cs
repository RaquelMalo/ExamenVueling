using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiBusinessMen.ViewModels
{
    public class TransactionsBySku
    {
        public string Num { get; set; }
        public string Sku { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}