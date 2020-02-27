using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiBusinessMen.ViewModels;

namespace ApiBusinessMen.Services.Calculator
{
    public interface ICalculator
    {
        List<TransactionsBySku> TotalInEuros(List<TransactionsBySku> listIn);
    }
}
