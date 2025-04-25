using CryptoTop.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;

namespace CryptoTop
{

    public partial class CurrencyWindow : Window
    {
        List<Currencies> _currencyList = new List<Currencies>();

        public CurrencyWindow()
        {
            InitializeComponent();
            try
            {
                if (File.Exists(JsonHandler.FilePath()))
                {
                    try
                    {
                        _currencyList = JsonHandler.CreateList();
                        _topCurrencies.ItemsSource = _currencyList.Take(10);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Нет данных");
            }
            
            
            
            #region Тестовые код


            //Currencies bitCoint = new Currencies("bitcoin", 1, "BTC", 19752815.0000000000000000, 21000000.0000000000000000, 1134508584478.0989721079862315, 7243846863.3409126543165751, 57435.2862859343831301, -0.0461491427646531, 57868.1484672081301126, "https://blockchain.info/werweqrerwerw");
            //Currencies ethereum = new Currencies("ethereum", 2, "ETH", 120703159.4902972300000000, 0, 193777781868.9090343683484662, 2299983274.2853347082736113, 1605.4077017303423284, 1.0200787391906480, 1595.4561307255059976, "https://etherscan.io/");
            //Currencies tether = new Currencies("tether", 3, "USDT", 144640112847.9336500000000000, 0, 144728930413.6819067662333179, 12880285449.0990439390019568, 1.0006140590186184, 0.0140617581020110, 1.0001427460269649, "https://www.omniexplorer.info/asset/31");
            //_currencyList.Add(bitCoint);
            //_currencyList.Add(ethereum);
            //_currencyList.Add(tether);
            //_currencyList = JsonHandler.CreateList();
            #endregion
            
        }

        private void _topCurrencies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            #region Тестовый код
            //var currencies = _topCurrencies.ItemsSource as IEnumerable<Currencies>;
            //var curr = currencies.ElementAt(_topCurrencies.SelectedIndex);
            //PriceInfo.Content = curr.Price;
            //VolumeInfo.Content = curr.Volume;
            //PriceChangeInfo.Content = curr.ChangePercent;
            //MarketInfo.Content = curr.Link;
            //DebugLabelMid.Content = curr.Id.ToString();
            //DebugLabelLeftMid.Content = curr.Price;
            //DebugLabelTopLeft.Content = curr.Volume;
            //DebugLabelTopMid.Content = curr.ChangePercent;
            //DebugLabelBottomLeft.Content = curr.Link;
            #endregion

        }

        private void _topCurrencies_Sorting(object sender, DataGridSortingEventArgs e)
        {
            if (e.Column.Header.ToString() == "Id"
           //(e.Column.SortDirection == ListSortDirection.Ascending ||
           //!e.Column.SortDirection.HasValue)
           )
            {
                e.Handled = true;
                if (e.Column.SortDirection == ListSortDirection.Ascending ||
                !e.Column.SortDirection.HasValue)
                {
                    MessageBox.Show("Good");
                    _topCurrencies.ItemsSource = _currencyList
                        .OrderBy(n => n.id)
                        .Take(10);
                    e.Column.SortDirection = ListSortDirection.Descending;
                }
                else
                {
                    MessageBox.Show("Bad");
                    _topCurrencies.ItemsSource = _currencyList
                        .OrderByDescending(n => n.id)
                        .Take(10);
                    e.Column.SortDirection = ListSortDirection.Ascending;
                }
                _topCurrencies.Items.Refresh();
            }

            if (e.Column.Header.ToString() == "Rank"
            //(e.Column.SortDirection == ListSortDirection.Ascending ||
            //!e.Column.SortDirection.HasValue)
            )
            {
                e.Handled = true;
                if (e.Column.SortDirection == ListSortDirection.Ascending ||
                !e.Column.SortDirection.HasValue)
                {
                    MessageBox.Show("Good");
                    _topCurrencies.ItemsSource = _currencyList
                        .OrderBy(n => ExtractNumber(n.rank))
                        .Take(10);
                    e.Column.SortDirection = ListSortDirection.Descending;
                }
                else
                {
                    MessageBox.Show("Bad");
                    _topCurrencies.ItemsSource = _currencyList
                        .OrderByDescending(n => ExtractNumber(n.rank))
                        .Take(10);
                    e.Column.SortDirection = ListSortDirection.Ascending;
                }
                _topCurrencies.Items.Refresh();
            }
            
        }
        static int ExtractNumber(string str)
        {
            string numberPart = new string(str.Where(char.IsDigit).ToArray());
            if (int.TryParse(numberPart, out int number))
            {
                return number;
            }
            return 0;
        }



        #region тестовые классы
        //public class Currencies
        //{
        //    public Currencies(string id, int rank, string symbol, double supply, double maxSupply, double marketCup, double volume, double price, double changePercent, double vWAP, string link)
        //    {
        //        Id = id;
        //        Rank = rank;
        //        Symbol = symbol;
        //        Supply = supply;
        //        MaxSupply = maxSupply;
        //        MarketCap = marketCup;
        //        Volume = volume;
        //        Price = price;
        //        ChangePercent = changePercent;
        //        VWAP = vWAP;
        //        Link = link;
        //    }
        //    /// <summary>
        //    /// id
        //    /// </summary>
        //    [JsonPropertyName("id")]
        //    public string Id { get; set; } = "";
        //    /// <summary>
        //    /// rank
        //    /// </summary>
        //    [JsonPropertyName("rank")]
        //    public int Rank { get; set; }
        //    /// <summary>
        //    /// symbol
        //    /// </summary>
        //    [JsonPropertyName("symbol")]
        //    public string Symbol { get; set; } = "";
        //    /// <summary>
        //    /// supply
        //    /// </summary>
        //    [JsonPropertyName("supply")]
        //    public double Supply { get; set; }
        //    /// <summary>
        //    /// maxsupply
        //    /// </summary>
        //    [JsonPropertyName("maxsupply")]
        //    public double MaxSupply { get; set; }
        //    /// <summary>
        //    /// marketCapUSD
        //    /// </summary>
        //    [JsonPropertyName("marketCapUSD")]
        //    public double MarketCap { get; set; }
        //    /// <summary>
        //    /// volumeUsd24Hr
        //    /// </summary>
        //    [JsonPropertyName("volumeUsd24Hr")]
        //    public double Volume { get; set; }
        //    /// <summary>
        //    /// priceUsd
        //    /// </summary>
        //    [JsonPropertyName("priceUsd")]
        //    public double Price { get; set; }
        //    /// <summary>
        //    /// changePercent24Hr
        //    /// </summary>
        //    [JsonPropertyName("changePercent24Hr")]
        //    public double ChangePercent { get; set; }
        //    /// <summary>
        //    /// vwap24Hr
        //    /// </summary>
        //    [JsonPropertyName("vwap24Hr")]
        //    public double VWAP { get; set; }
        //    /// <summary>
        //    /// explorer
        //    /// </summary>
        //    [JsonPropertyName("explorer")]
        //    public string Link { get; set; }



        //}
        //public class CurrencyResponse
        //{
        //    public List<Currencies> Data { get; set; }  // Свойство "data" из JSON
        //}

        //private void _topCurrencies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    DebugLabel.Content = _topCurrencies.SelectedValue;
        //}

        //    public class Exchange
        //    {
        //        public string Name { get; set; }
        //        public double Price { get; set; }
        //        public int Volume { get; set; }

        //        public double Change { get; set; }

        //        public string Markets { get; set; }



        //        public Exchange(string name, double price, int volume, double change, string markets)
        //        {
        //            Name = name;
        //            Price = price;
        //            Volume = volume;
        //            Change = change;
        //            Markets = markets;
        //        }
        //    }
        #endregion

        private void DataGetButton_Click(object sender, RoutedEventArgs e)
        {
            Requester.CreateJson();

            _currencyList = JsonHandler.CreateList();
            _topCurrencies.ItemsSource = _currencyList.Take(10);
        }

        private void ChangeAPIButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
