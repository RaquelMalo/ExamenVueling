using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiBusinessMen.Models;

namespace ApiBusinessMen.Services.Specification
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(Transactions listTrans);
    }
}
