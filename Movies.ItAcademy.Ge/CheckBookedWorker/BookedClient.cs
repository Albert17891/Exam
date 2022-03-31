using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CheckBookedWorker
{
    public class BookedClient
    {
        private readonly ILogger _logger;

        public BookedClient(ILogger<BookedClient> logger)
        {
            _logger = logger;
        }

        public async Task CheckBooked()
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            using (var client = new HttpClient(httpClientHandler))
            {
                try
                {
                    client.BaseAddress = new Uri("https://localhost:44306/");

                    var response = await client.GetAsync("Ticket/CheckBooked");
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
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
}
