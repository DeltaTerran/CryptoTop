using CryptoTop.Classes;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для APIPage.xaml
    /// </summary>
    public partial class APIPage : Page
    {
        public APIPage()
        {
            InitializeComponent();
        }
        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            //Properties.Settings.Default.apiKey = "3e403e7454eb64e1faa6b5dbbd6b78531d9193c2c5391d879622c8d7a266fff3";
            Properties.Settings.Default.apiKey = ApiKeyTextBox.Text;
            MessageBox.Show("Key has been changed to: " + ApiKeyTextBox.Text);
            Properties.Settings.Default.Save();
            Requester.SetApiKey(ApiKeyTextBox.Text);
            CurrencyWindow.ReturnToTable<TablePage>();
        }

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {

            CurrencyWindow.ReturnToTable<TablePage>();
        }
    }
}
