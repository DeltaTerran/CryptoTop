using CryptoTop.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var mainWindow = Application.Current.MainWindow as CurrencyWindow;
            if (mainWindow != null)
            {
                mainWindow.MainFrameInstance.Navigate(new TablePage());
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            PriceInfo.Content = DisplayedCurrency.priceUsd;
            VolumeInfo.Content = DisplayedCurrency.volumeUsd24Hr;
            PriceChangeInfo.Content = DisplayedCurrency.changePercent24Hr;
            MarketInfo.Content = DisplayedCurrency.explorer;
        }

        private void MarketInfo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo(DisplayedCurrency.explorer)
                {
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
