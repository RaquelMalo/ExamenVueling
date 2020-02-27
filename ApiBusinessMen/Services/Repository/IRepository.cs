using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiBusinessMen.Models;

namespace ApiBusinessMen.Services.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Transactions>> GetTransactions();
        Task<IEnumerable<Rates>> GetRates();
    }
}
