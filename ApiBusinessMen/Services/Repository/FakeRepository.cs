using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ApiBusinessMen.Models;

namespace ApiBusinessMen.Services.Repository
{
    public class FakeRepository : IRepository
    {
        public async Task<IEnumerable<Rates>> GetRates()
        {
            var rates = new List<Rates>()
            {
                new Rates()
                {
                    From = "CAD",
                    To = "AUD",
                    Rate = 1.3m
                },
                new Rates()
                {
                    From = "AUD",
                    To = "CAD",
                    Rate = 0.77m
                },
                new Rates()
                {
                    From = "CAD",
                    To = "EUR",
                    Rate = 0.95m
                },
                new Rates()
                {
                    From = "EUR",
                    To = "CAD",
                    Rate = 1.05m
                },
                new Rates()
                {
                    From = "AUD",
                    To = "USD",
                    Rate = 1.07m
                },
                new Rates()
                {
                    From = "USD",
                    To = "AUD",
                    Rate = 0.93m
                }
            };
            var task1 = Task.Run<IEnumerable<Rates>>(() => rates);
            return await task1.ConfigureAwait(false);
        }

        public async Task<IEnumerable<Transactions>> GetTransactions()
        {
            var transactions = new List<Transactions>()
            {
                new Transactions()
                {
                    Sku = "Y0530",
                    Amount = 23.5m,
                    Currency = "EUR"
                },
                new Transactions()
                {
                    Sku = "Z4111",
                    Amount = 13.5m,
                    Currency = "CAD"
                },
                new Transactions()
                {
                    Sku = "S2935",
                    Amount = 30.5m,
                    Currency = "AUD"
                },
                new Transactions()
                {
                    Sku = "Y0530",
                    Amount = 41m,
                    Currency = "USD"
                }
            };
            var task1 = Task.Run<IEnumerable<Transactions>>(() => transactions);
            return await task1.ConfigureAwait(false);
        }
    }
}