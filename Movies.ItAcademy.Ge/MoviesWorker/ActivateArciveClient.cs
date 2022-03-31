using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MoviesWorker
{
    public class ActivateArciveClient
    {
        private readonly ILogger<ActivateArciveClient> _logger;

        public ActivateArciveClient(ILogger<ActivateArciveClient> logger)
        {
            _logger = logger;
        }


        public async Task ActivateTickets()
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
              {
                  return true;
              };

            using var client = new HttpClient(httpClientHandler);
            try
            {
                client.BaseAddress = new Uri("https://localhost:44353/");               
                var response = await client.GetAsync("Admin/CheckActive");                

                if (response.IsSuccessStatusCode)
                {
                    var result =await response.Content.ReadAsStringAsync();
                    _logger.LogInformation(result);
                }

            }
            catch (Exception ex)
            {

                _logger.LogError(ex.ToString());
            }

        }
    }
}
