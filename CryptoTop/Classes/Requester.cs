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
        static string ApiKey = Properties.Settings.Default.apiKey;
        
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
                HttpResponseMessage response = await _client.GetAsync($"assets?apiKey={ApiKey}");
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
