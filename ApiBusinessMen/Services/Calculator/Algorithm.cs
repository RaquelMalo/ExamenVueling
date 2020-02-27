using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBusinessMen.CrossCutting.Exceptions;
using ApiBusinessMen.Models;
using ApiBusinessMen.Services.Repository;

namespace ApiBusinessMen.Services.Calculator
{
    public class Algorithm : IAlgorithm
    {
        private readonly IEnumerable<Rates> _rateTable;

        public Algorithm(IRepository repository)
        {
            _rateTable = repository.GetRates().Result;
        }

        public decimal CalculateRate(string currency)
        {
            decimal rate = 1;
            //try
            //{
                switch (currency)
                {//This fails when the conversions table changes. Apply Dijkstra Algorithm.
                    case "USD":
                        rate = ReadRates("AUD", "USD") * ReadRates("CAD", "AUD") * ReadRates("EUR", "CAD");
                        break;
                    case "CAD":
                        rate = ReadRates("EUR", "CAD");
                        break;
                    case "AUD":
                        rate = ReadRates("CAD", "AUD") * ReadRates("EUR", "CAD");
                        break;
                    case "EUR":
                        break;
                    default:
                        throw new CalculatorException("Don't have the conversion rate for this currency.");
                }
            //}
            //catch (Exception e)
            //{
            //    throw new
            //}

            return rate;
        }

        private decimal ReadRates(string dst, string orig)
        {
            decimal rate = 0;
            //var rateTable = _repository.GetRates().Result;
            Parallel.ForEach(_rateTable, item =>
            {
                if (item.From.Equals(orig) && item.To.Equals(dst))
                {
                    rate = item.Rate;
                }
            });

            return rate;
        }
    }
}