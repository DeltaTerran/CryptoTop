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
        public Frame MainFrameInstance => _mainFrame;
        public CurrencyWindow()
        {
            InitializeComponent();
            _mainFrame.Navigate(new TablePage());
            JsonHandler.EnsureFileExists();

            
        }
        
        private async void DataGetButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                await Requester.CreateJson();
                MessageBox.Show("Json has been created");
                if (_mainFrame.Content is TablePage tablePage)
                {
                    var currencyList = tablePage.GetCurrencyList();
                    DataGrid topCurrencies = tablePage.GetDataGrid();
                    currencyList = JsonHandler.CreateList();
                    topCurrencies.ItemsSource = currencyList.Take(10);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error: {ex.Message}");
            }
            
            
        }

        private void ChangeAPIButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new APIPage());
            //Properties.Settings.Default.apiKey = "3e403e7454eb64e1faa6b5dbbd6b78531d9193c2c5391d879622c8d7a266fff3";
            //Properties.Settings.Default.Save();
        }
        public static void ReturnToTable<T>() where T : new()
        {
            var mainWindow = Application.Current.MainWindow as CurrencyWindow;
            if (mainWindow != null)
            {
                mainWindow.MainFrameInstance.Navigate(new T());
            }
        }
    }
}
