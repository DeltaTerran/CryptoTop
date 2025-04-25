using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CryptoTop.Classes
{
    public static class JsonHandler
    {
        private static string _filePath = "C:\\Users\\spaka\\source\\repos\\CryptoTop\\CryptoTop\\Json\\Assets.JSON";
        public static string FilePath()
        {
            return _filePath;
        }
        private static string _jsonFromFile = File.ReadAllText(_filePath);

        public static List<Currencies> CreateList()
        {
            CurrencyResponse response = JsonSerializer.Deserialize<CurrencyResponse>(_jsonFromFile);
            List<Currencies> temp = response.data;
            return temp;
        }
    }
    public class CurrencyResponse
    {
        public List<Currencies> data { get; set; }
        public long timestamp { get; set; }
    }

    public class Currencies
    {
        public string id { get; set; }
        public string rank { get; set; }
        public string symbol { get; set; }
        public string name { get; set; }
        public string supply { get; set; }
        public string maxSupply { get; set; }
        public string marketCapUsd { get; set; }
        public string volumeUsd24Hr { get; set; }
        public string priceUsd { get; set; }
        public string changePercent24Hr { get; set; }
        public string vwap24Hr { get; set; }
        public string explorer { get; set; }
    }
}
