using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using ApiBusinessMen.CrossCutting.Exceptions;
using ApiBusinessMen.Models;
using ApiBusinessMen.Services.CheckConnection;
using ApiBusinessMen.Services.Persistence;
using Newtonsoft.Json;

namespace ApiBusinessMen.Services.Repository
{
    public class ApiJsonRepository : IRepository
    {
        private readonly ICheckConnection _connection;
        private readonly IWriteJson _writeJson;
        private List<Transactions> _listT;
        private List<Rates> _listR;

        public ApiJsonRepository(ICheckConnection connection, IWriteJson writeJson)
        {
            _connection = connection;
            _writeJson = writeJson;
            _listT = new List<Transactions>();
            _listR = new List<Rates>();
        }

        public async Task<IEnumerable<Transactions>> GetTransactions()
        {
            const string url = "https://quiet-stone-2094.herokuapp.com/transactions.json";
            //if (_connection.Check(url).Result)
            try
            {
                //Read web API
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(url).ConfigureAwait(false);
                    var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    _listT = JsonConvert.DeserializeObject<List<Transactions>>(content);
                    _writeJson.PersistTransactions(_listT);
                }
            }
            //else
            catch(Exception e)
            {
                var pathFile = AppDomain.CurrentDomain.BaseDirectory + $"App_Data\\transactionsWS.json";
                if (File.Exists(pathFile))
                {
                    _listT = JsonConvert.DeserializeObject<List<Transactions>>(File.ReadAllText(pathFile));
                }
                else
                {
                    throw new RepositoryException("Cannot catch the transactions list from the API",e);
                }
            }

            return _listT;
        }

        public async Task<IEnumerable<Rates>> GetRates()
        {
            const string url = "https://quiet-stone-2094.herokuapp.com/rates.json";
            //if (_connection.Check(url).Result)
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(url).ConfigureAwait(false);
                    var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    _listR = JsonConvert.DeserializeObject<List<Rates>>(content);
                    _writeJson.PersistRates(_listR);
                }
            }
            //else
            catch(Exception e)
            {
                var pathFile = AppDomain.CurrentDomain.BaseDirectory + $"App_Data\\ratesWS.json";
                if (File.Exists(pathFile))
                {
                    _listR = JsonConvert.DeserializeObject<List<Rates>>(File.ReadAllText(pathFile));
                }
                else
                {
                    throw new RepositoryException("Cannot catch the rates from the API",e);
                }
            }

            return _listR;
        }
    }
}