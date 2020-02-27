using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBusinessMen.Services.Calculator
{
    public interface IAlgorithm
    {
        decimal CalculateRate(string currency);
    }
}
