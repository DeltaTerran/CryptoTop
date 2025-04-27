using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoTop.Classes
{
    public static class Requester
    {
        
        private static string _apiKey = "3e403e7454eb64e1faa6b5dbbd6b78531d9193c2c5391d879622c8d7a266fff3";
        static HttpClient _client = new HttpClient()
        {
            BaseAddress = new Uri("https://rest.coincap.io/v3/")
        };
        
        public static async void CreateJson()
        {
                await RequestJSON();
        }

        private static async Task RequestJSON()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync($"assets?apiKey={_apiKey}");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                using (FileStream json = new FileStream(JsonHandler.FilePath(), FileMode.Create))
                {
                    byte[] buffer = Encoding.Default.GetBytes(responseBody);
                    await json.WriteAsync(buffer, 0, buffer.Length);
                }
            }
            catch (Exception e)
            {

                MessageBox.Show($"Ошибка при выполнении запроса: {e.Message}");
            }
        }
    }
}
