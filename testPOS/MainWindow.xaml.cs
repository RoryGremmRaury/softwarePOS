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
        PosDBEntities dBEntities = new PosDBEntities();
        ObservableCollection<Drink> DrinkCollection;

        public MainWindow()
        {
            InitializeComponent();
            DrinkCollection = new ObservableCollection<Drink>(dBEntities.Drinks);
            //var testQuery = from testDrink in DrinkCollection
            //                where testDrink.Name == "Water"
            //                select testDrink.Name;
            //testButton.Content = testQuery.ToString();
            //loggedInAsTB.Text = 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //checks to see if another screen is being displayed and collapses it if there is one
        }

        private void SaleButton_Click(object sender, RoutedEventArgs e)
        {
            var priceQuery = from drink in DrinkCollection
                             where drink.Price >= (decimal)0.0
                             select drink.Price;

            //PriceDG.ItemsSource = priceQuery.ToList();
        }

        private void DrinkButton_Click(object sender, RoutedEventArgs e)
        {
            //DbSet<Drink> drinks = dBEntities.Drinks;
            //DrinkDG.Visibility = (DrinkDG.Visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
            //DrinkDG.ItemsSource = drinks.ToList();
        }

        private void FoodButton_Click(object sender, RoutedEventArgs e)
        {
            //DbSet<Snack> snacks = dBEntities.Snacks;
            //SnackDG.Visibility = (SnackDG.Visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
            //SnackDG.ItemsSource = snacks.ToList();
        }

        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            //DbSet<Customer> customers = dBEntities.Customers;
            //CustomerDG.Visibility = (CustomerDG.Visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
            //CustomerDG.ItemsSource = customers.ToList();
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
