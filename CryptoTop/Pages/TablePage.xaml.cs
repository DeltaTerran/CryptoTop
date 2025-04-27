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

        }
        private void _topCurrencies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as CurrencyWindow;
            if (mainWindow != null)
            {
                mainWindow.MainFrameInstance.Navigate(new DetailPage());
            }

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
        
    }

}
