using System.Text.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CarApi.Infastructure.Extension
{
    public static class CarPriceExchange
    {
        public static async Task<double> CarGelPrice(string currency)
        {
            Uri uri = new Uri($"https://free.currconv.com/api/v7/convert?q={currency}_GEL&compact=ultra&apiKey=76c3e9f6b62da2d222d3");

            HttpClient httpClient = new HttpClient();

            httpClient.BaseAddress =uri;


            var res =await httpClient.GetByteArrayAsync(uri);

           

            var price = JsonSerializer.Deserialize<Price>(res);

            if (currency == "USD")
            {
                return price.USD_GEL;
            }

            return price.EUR_GEL;

           
        }
    }


    public class Price 
    {

        public double USD_GEL { get; set; }
       public double EUR_GEL { get; set; }

    }

}
