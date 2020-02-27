using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiBusinessMen.Models;

namespace ApiBusinessMen.Services.Specification
{
    public class TransactionsBySkuSpecification : ISpecification<Transactions>
    {
        private readonly string _sku;

        public TransactionsBySkuSpecification(string sku)
        {
            _sku = sku;
        }

        public bool IsSatisfiedBy(Transactions trans)
        {
            return trans.Sku.Equals(_sku);
        }
    }
}