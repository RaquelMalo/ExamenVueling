using System;
using System.Net.Http;
using System.Threading.Tasks;
using NLog;
using Polly;

namespace ApiBusinessMen.Services.CheckConnection
{
    public class CheckConnection : ICheckConnection
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public async Task<bool> Check(string url)
        {
            var httpClient = new HttpClient();
            var request = await Policy
                .HandleResult<HttpResponseMessage>(message => !message.IsSuccessStatusCode)
                .WaitAndRetryAsync(3, i => TimeSpan.FromSeconds(1), (result, timeSpan, retryCount, context) =>
                {
                    //Console.WriteLine("Escribir en Log");
                    Logger.Warn($"Request failed with {result.Result.StatusCode}. Waiting {timeSpan} before next retry. Retry attempt {retryCount}");
                })
                .ExecuteAsync(() => httpClient.GetAsync(url));

            return request.IsSuccessStatusCode;
        }
    }
}