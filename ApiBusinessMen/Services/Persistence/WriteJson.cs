using System;
using System.Collections.Generic;
using System.IO;
using ApiBusinessMen.Models;
using Newtonsoft.Json;

namespace ApiBusinessMen.Services.Persistence
{
    public class WriteJson : IWriteJson
    {
        private readonly string _path = AppDomain.CurrentDomain.BaseDirectory;

        public void PersistTransactions(IEnumerable<Transactions> listTrans)
        {
            var filePath = _path + $"App_Data\\transactionsWS.json";
            if (!File.Exists(filePath))
                File.Create(filePath).Close();

            using (var sw = new StreamWriter(filePath))
            {
                var jsonStr = JsonConvert.SerializeObject(listTrans, Formatting.Indented);

                sw.Write(jsonStr);
            }
        }

        public void PersistRates(IEnumerable<Rates> listRates)
        {
            var filePath = _path + $"App_Data\\ratesWS.json";
            if (!File.Exists(filePath))
                File.Create(filePath).Close();

            using (var sw = new StreamWriter(filePath))
            {
                var jsonStr = JsonConvert.SerializeObject(listRates, Formatting.Indented);

                sw.Write(jsonStr);
            }
        }
    }
}