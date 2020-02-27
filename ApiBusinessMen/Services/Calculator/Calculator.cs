using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBusinessMen.CrossCutting.Exceptions;
using ApiBusinessMen.Models;
using ApiBusinessMen.Services.Repository;
using ApiBusinessMen.ViewModels;

namespace ApiBusinessMen.Services.Calculator
{
    public class Calculator : ICalculator
    {
        private readonly IAlgorithm _algorithm;

        public Calculator(IAlgorithm algorithm)
        {
            _algorithm = algorithm;
        }

        /// <summary>
        /// Conversions to EUR
        /// </summary>
        /// <param name="listIn">Model view TransactionsBySku</param>
        /// <returns></returns>
        public List<TransactionsBySku> TotalInEuros(List<TransactionsBySku> listIn)
        {
            decimal total = 0;

            Parallel.ForEach(listIn, trans =>
            {
                var amount = trans.Amount * _algorithm.CalculateRate(trans.Currency);
                //Rounding: Round half to even
                amount = Math.Round(amount, 2, MidpointRounding.ToEven);
                trans.Amount = amount;
                trans.Currency = "EUR";
                total += amount;
            });
            //Add the total value of the transactions for this sku
            if (listIn.Count == 0) return listIn;
            var transactionTotal = new TransactionsBySku
            {
                Num = "TOTAL",
                Sku = listIn.FirstOrDefault()?.Sku,
                Amount = total,
                Currency = "EUR"
            };
            listIn.Add(transactionTotal);

            return listIn;
        }
    }
}