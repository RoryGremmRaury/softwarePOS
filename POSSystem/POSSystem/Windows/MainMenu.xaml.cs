using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
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
        public int custId = 0;
        
        pos_dbEntities3 dbEntities = new pos_dbEntities3();
        //   public List<OrderItem> OrderItems = new List<OrderItem>();
        public MainMenu()
        {
            InitializeComponent();
        }
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //ObservableCollection<Order> orders = new ObservableCollection<Order>(dbEntities.Orders);
            DbSet<Order> orders = dbEntities.Orders;
            DbSet<Product> products = dbEntities.Products;
            
            var query =
                from Order in orders
                join Product in products on Order.PoductID equals Product.ProductID
                where Order.OrderID == 1
                orderby Order.OrderID
                
                select new { ProductName = Product.ProductName, ProductPrice = Product.ProductPrice};
            currentOrderDG.ItemsSource = query.ToList();
        }

        private void SaleButton_Click(object sender, RoutedEventArgs e)
        {
            //OrderItem item = new OrderItem
            //{

            //    ItemID = "item1"
            //};
            //currentOrderDG.Items.Add(item);
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            custId++;
            SearchBoard keyboard = new SearchBoard();
            keyboard.Show();
            this.Close();

        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
        //    OrderItem item = new OrderItem
        //    {
        //        ItemID = "OrderItem"
        //    };
        //    currentOrderDG.Items.Add(item);

        }

        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FoodButton_Click(object sender, RoutedEventArgs e)
        {
        //    OrderItem item = new OrderItem
        //    {
        //        ItemID = "FoodItem1"
        //    };
        //    currentOrderDG.Items.Add(item);
        }

        public void DrinkButton_Click(object sender, RoutedEventArgs e)
        {
            //OrderItem item = new OrderItem
            //{
            //    ItemID = "DrinkItem1"
            //};
            //currentOrderDG.Items.Add(item);
        }

    }
}
