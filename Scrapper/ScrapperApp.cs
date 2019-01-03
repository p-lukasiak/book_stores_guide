using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TeltIt.BSG.Scrapper.Spiders;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace TeltIt.BSG.Scrapper
{
    public static class ScrapperApp
    {
        [FunctionName("RunSpiders")]
        public static async Task Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info($"C# HTTP trigger function executed at: {DateTime.Now}");

            // Start all spiders to extract the current catalogues from the sites
            // czytam.pl
            var czytamPlThread = new Thread(StartCzytamPl);
            czytamPlThread.Start();
                      
        }

        private static void StartCzytamPl()
        {
            // Create and start spider for czytam.pl
            var czytamSpider = new CzytamPl();
            czytamSpider.Start();
        }
    }
}
