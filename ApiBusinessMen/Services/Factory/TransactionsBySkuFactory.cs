using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ApiBusinessMen.Models;
using ApiBusinessMen.Services.Specification;
using ApiBusinessMen.ViewModels;
using Newtonsoft.Json;

namespace ApiBusinessMen.Services.Factory
{
    public class TransactionsBySkuFactory : ITransactionsBySkuFactory
    {
        public List<TransactionsBySku> Create(string sku)
        {
            var listBySku = new List<TransactionsBySku>();
            var specification = new TransactionsBySkuSpecification(sku);
            var pathFile = AppDomain.CurrentDomain.BaseDirectory + $"App_Data\\transactionsWS.json";
            var list = JsonConvert.DeserializeObject<List<Transactions>>(File.ReadAllText(pathFile));
            //var filteredList = list.Where(t => t.Sku == sku);
            var filteredList = new MyFilter().GetElements(list, specification);
            
            var i = 0;
            foreach (var item in filteredList)
            {
                //if (!specification.IsSatisfiedBy(item)) continue;
                i++;
                var element = new TransactionsBySku
                {
                    Num = Convert.ToString(i),
                    Sku = item.Sku,
                    Amount = item.Amount,
                    Currency = item.Currency
                };
                listBySku.Add(element);
            }

            return listBySku;
        }
    }
}