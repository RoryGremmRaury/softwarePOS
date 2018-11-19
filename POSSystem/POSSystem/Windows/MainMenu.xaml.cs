using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
using POSSystem.Windows;

namespace POSSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        List<Product> OrderItems = new List<Product>();
        pos_dbEntities dataEntities = new pos_dbEntities();

        public ObservableCollection<Product> productCollection;

        public MainMenu()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            productCollection = new ObservableCollection<Product>(dataEntities.Products);
            DbSet<Product> products = dataEntities.Products;
        }

        private void SaleButton_Click(object sender, RoutedEventArgs e)
        {

            //generating a new product  //can add in logic for setting category later 1- drink 2- food 3-merch
            Product item = new Product
            {
                ProductName = "food Product",
                ProductPrice = ((decimal)5.00),
                ProductCategory = 2,
                ProductID = productCollection.Count + 1
            };
            CurrentOrderDisplay.Items.Add(item);
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            SearchBoard keyboard = new SearchBoard();
            keyboard.Show();
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            OrderItem item = new OrderItem
            {
                ItemName = "OrderItem",
                Price = ((decimal)5.00),
                Count = 1
            };
            CurrentOrderDisplay.Items.Add(item);
        }

        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            var nameQuery = from product in productCollection
                            //where product.ProductID
                            select product.ProductName.ToList();


            //TestOLButton.Content = nameQuery;

            //OrderItem item = new OrderItem
            //{
            //    ItemName = nameQuery.ToString(),
            //    Price = ((decimal)5.00),
            //    Count = 1
            //};
            //CurrentOrderDisplay.Items.Add(item);
        }

        private void FoodButton_Click(object sender, RoutedEventArgs e)
        {
            OrderItem item = new OrderItem
            {
                ItemName = "FoodItem1",
                Price = ((decimal)5.00),
                Count = 1
            };
            CurrentOrderDisplay.Items.Add(item);
        }

        private void DrinkButton_Click(object sender, RoutedEventArgs e)
        {
            OrderItem item = new OrderItem
            {
                ItemName = "DrinkItem1",
                Price = ((decimal)5.00),
                Count = 1
            };
            CurrentOrderDisplay.Items.Add(item);
        }

        
    }
}
