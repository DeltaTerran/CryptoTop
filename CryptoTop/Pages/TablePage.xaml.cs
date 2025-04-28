using CryptoTop.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
    /// Логика взаимодействия для TablePage.xaml
    /// </summary>
    public partial class TablePage : Page
    {
        List<Currencies> _currencyList = new List<Currencies>();
        
        public DataGrid GetDataGrid()
        {
            return _topCurrencies;
        }
        public List<Currencies> GetCurrencyList()
        {
            return _currencyList;
        }
        
        public TablePage()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
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
        private void _topCurrencies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currencies = _topCurrencies.ItemsSource as IEnumerable<Currencies>;
            var curr = currencies.ElementAt(_topCurrencies.SelectedIndex);
            var detailPage = new DetailPage();
            var mainWindow = Application.Current.MainWindow as CurrencyWindow;
            detailPage.DisplayedCurrency= curr;
            if (mainWindow != null)
            {
                mainWindow.MainFrameInstance.Navigate(detailPage);
            }
        }

        private void _topCurrencies_Sorting(object sender, DataGridSortingEventArgs e)
        {
            e.Handled = true;

            var isAscending = e.Column.SortDirection != ListSortDirection.Descending;
            var header = e.Column.Header.ToString();

            IOrderedEnumerable<Currencies> sortedItems = null;

            switch (header)
            {
                case "Id":
                    sortedItems = isAscending
                        ? _currencyList.OrderBy(n => n.id)
                        : _currencyList.OrderByDescending(n => n.id);
                    break;

                case "Rank":
                    sortedItems = isAscending
                        ? _currencyList.OrderBy(n => ExtractNumber(n.rank))
                        : _currencyList.OrderByDescending(n => ExtractNumber(n.rank));
                    break;

            }
            if (sortedItems != null)
            {
                _topCurrencies.ItemsSource = sortedItems.Take(10);
                e.Column.SortDirection = isAscending
                    ? ListSortDirection.Descending
                    : ListSortDirection.Ascending;
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

        
    }

}
