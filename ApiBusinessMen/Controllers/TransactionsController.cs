using System;
using System.Web.Mvc;
using ApiBusinessMen.CrossCutting.Exceptions;
using ApiBusinessMen.Models;
using ApiBusinessMen.Services.Calculator;
using ApiBusinessMen.Services.Factory;
using ApiBusinessMen.Services.Repository;
using Newtonsoft.Json;

namespace ApiBusinessMen.Controllers
{
    public class TransactionsController : BaseController
    {
        private readonly IRepository _repository;
        private readonly ITransactionsBySkuFactory _factory;
        private readonly ICalculator _calculator;

        public TransactionsController(IRepository repository, ITransactionsBySkuFactory factory, ICalculator calculator)
        {
            _repository = repository;
            _factory = factory;
            _calculator = calculator;
        }

        // GET: Transactions
        public ActionResult Index()
        {
            try
            {
                var result = _repository.GetTransactions().Result;
                return Content(JsonConvert.SerializeObject(result, Formatting.Indented));
            }
            catch (Exception e)
            {
                throw new TransactionsControllerException("Failed the list total of transactions.", e);
            }
        }

        // GET: Transactions/GetBySku/Q8348
        public ActionResult GetBySku(string sku)
        {
            try
            {
                //var all = _repository.GetTransactions().Result;
                var filteredList = _factory.Create(sku); //Read json because transactions list changes continuosly
                var result = _calculator.TotalInEuros(filteredList);
                return Content(JsonConvert.SerializeObject(result, Formatting.Indented));
            }
            catch (Exception e)
            {
                throw new TransactionsControllerException($"Failed the list of transactions by {sku}", e);
            }
        }
    }
}
