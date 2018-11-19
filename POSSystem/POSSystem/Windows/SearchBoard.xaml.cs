using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace POSSystem.Windows
{
    /// <summary>
    /// Interaction logic for SearchBoard.xaml
    /// </summary>
    public partial class SearchBoard : Window
    {
        pos_dbEntities dataEntities = new pos_dbEntities();
        List<Product> OrderItems = new List<Product>();
        public ObservableCollection<Product> productCollection;

        string keyInput = "";
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OrderItems = dataEntities.Products.ToList();
            productCollection = new ObservableCollection<Product>(OrderItems);
        } 
        public SearchBoard()
        {
            InitializeComponent();
        }

        private void QWERTY_ButtonClick(object sender, RoutedEventArgs e)
        {
            //pulls keyboard buttons pressed into a string variable
            keyInput = (((Button)sender).Content).ToString();
            //adds variable to text box
            SearchTB.Text += keyInput;

            
        }

        private void BackSpace_Button_Click(object sender, RoutedEventArgs e)
        {
            string text = SearchTB.Text;
            if (text.Length > 0)
            {
                text = text.Remove(text.Length - 1, 1);
                SearchTB.Text = text;
            }
        }

        private void Enter_Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from product in productCollection
                        where product.ProductName == "water"
                        select product;
            MessageBox.Show(query.ToString());
            //this.Close();
        }

        
    }
}
