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
using POSSystem.Models;
using POSSystem.UserControls;

namespace POSSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        List<Product> OrderItems = new List<Product>();
        pos_dbEntities dataEntities = new pos_dbEntities();
        private ButtonOverlayControl buttonContainer;
        public List<ProductButton> pButtons;

        public ObservableCollection<Product> productCollection;
        private bool showing;

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
           
        }

        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            Account window = new Account();
            window.Show();
            this.Close();
           
        }

        private void FoodButton_Click(object sender, RoutedEventArgs e)
        {
            if (showing == false)
            {
                DisplayOverlayfood();
            }
            else
            {
                SubmenuOverlay.Children.Clear();
                showing = false;
            }
        }

        private void DrinkButton_Click(object sender, RoutedEventArgs e)
        {
            if (showing == false)
            {
                DisplayOverlayDrink();
            }
            else
            {
                SubmenuOverlay.Children.Clear();
                showing = false;
            }
        }

        private void DisplayOverlayfood()
        {
            if (buttonContainer is null)
            {
                buttonContainer = new ButtonOverlayControl(pButtons);
            }
            var query = from product in productCollection
                        where product.ProductCategory == 2   //1 = drink, 2 = food, 3 = merch
                        select product;


            Product[] queryArray = query.ToArray();


            foreach (Product p in queryArray)
            {
                ProductButton pb = new ProductButton(p.ProductName);
                pButtons.Add(pb);
                //buttonContainer.ButtonOverlay.Children.Add(pb);
            }

            //if there is already a button container, don't add another.
            if (SubmenuOverlay.Children.Count == 0)
            {
                SubmenuOverlay.Children.Add(buttonContainer);
            }


            showing = true;

        }

        private void DisplayOverlayDrink()
        {
            if (buttonContainer is null)
            {
                buttonContainer = new ButtonOverlayControl(pButtons);
            }
            var query = from product in productCollection
                        where product.ProductCategory == 1   //1 = drink, 2 = food, 3 = merch
                        select product;


            Product[] queryArray = query.ToArray();


            foreach (Product p in queryArray)
            {
                ProductButton pb = new ProductButton(p.ProductName);
                pButtons.Add(pb);
                //buttonContainer.ButtonOverlay.Children.Add(pb);
            }

            //if there is already a button container, don't add another.
            if (SubmenuOverlay.Children.Count == 0)
            {
                SubmenuOverlay.Children.Add(buttonContainer);
            }


            showing = true;

        }


    }
}
