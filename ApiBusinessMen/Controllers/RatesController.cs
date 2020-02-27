using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApiBusinessMen.CrossCutting.Exceptions;
using ApiBusinessMen.Services.Repository;
using Newtonsoft.Json;

namespace ApiBusinessMen.Controllers
{
    public class RatesController : BaseController
    {
        private readonly IRepository _repository;

        public RatesController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: Rates
        public ActionResult Index()
        {
            try
            {
                var result = _repository.GetRates().Result;
                return Content(JsonConvert.SerializeObject(result, Formatting.Indented));
            }
            catch (Exception e)
            {
                throw new RatesControllerException("Rates Controller failed", e);
            }
        }

    }
}
