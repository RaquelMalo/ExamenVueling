using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiBusinessMen.ViewModels;

namespace ApiBusinessMen.Services.Factory
{
    public interface ITransactionsBySkuFactory
    {
        List<TransactionsBySku> Create(string sku);
    }
}
