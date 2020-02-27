using System.Collections.Generic;
using ApiBusinessMen.Models;

namespace ApiBusinessMen.Services.Persistence
{
    public interface IWriteJson
    {
        void PersistTransactions(IEnumerable<Transactions> listTrans);
        void PersistRates(IEnumerable<Rates> listRates);
    }
}
