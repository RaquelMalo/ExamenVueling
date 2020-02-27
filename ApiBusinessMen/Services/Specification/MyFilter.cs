using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiBusinessMen.Models;

namespace ApiBusinessMen.Services.Specification
{
    public class MyFilter
    {
        public IEnumerable<Transactions> GetElements(IEnumerable<Transactions> trans, ISpecification<Transactions> specification) =>
            trans.Where(specification.IsSatisfiedBy).ToList();
    }
}