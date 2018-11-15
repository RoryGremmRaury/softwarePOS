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
using System.Data.Entity;
using System.Collections.ObjectModel;
using POSSystem;
using testPOS;

namespace POSSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<OrderItem> OrderItems = new List<OrderItem>();

        public MainWindow()
        {
            InitializeComponent();
            //currentOrderDG.ItemsSource = OrderItems;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void SaleButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void DrinkButton_Click(object sender, RoutedEventArgs e)
        {

            OrderItem item = new OrderItem
            {
                ItemName = "item1",
                Price = ((decimal)5.00),
                Count = 1
            };
            currentOrderDG.Items.Add(item);
        }

        private void FoodButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            SearchBoard kbWindow = new SearchBoard();
            kbWindow.Show();
        }
    }
}
