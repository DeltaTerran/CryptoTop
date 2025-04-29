using CryptoTop.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CryptoTop
{
    /// <summary>
    /// Логика взаимодействия для DetailPage.xaml
    /// </summary>
    public partial class DetailPage : Page
    {
        public Currencies DisplayedCurrency { get; set; }

        public DetailPage()
        {
            InitializeComponent();
            
            
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CurrencyWindow.ReturnToTable<TablePage>();
        }

        

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LName.Content = DisplayedCurrency.id;
            PriceInfo.Content = Parser(DisplayedCurrency.priceUsd,"$");
            VolumeInfo.Content = Parser(DisplayedCurrency.volumeUsd24Hr, "$");
            PriceChangeInfo.Content = Parser(DisplayedCurrency.changePercent24Hr, "%");
            MarketInfo.Content = DisplayedCurrency.explorer;
        }

        private string Parser(string str, string symbol)
        {
           return Math.Round(double.Parse(str, CultureInfo.InvariantCulture), 2) + symbol;
        }

        private void MarketInfo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo(DisplayedCurrency.explorer)
            {
                UseShellExecute = true
            });
        }
    }
}
