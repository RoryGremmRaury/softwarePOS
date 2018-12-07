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
using System.Windows.Shapes;
using System.Data.Sql;
using System.Data.SqlClient;
using POSSystem.Models;
using System.Collections.ObjectModel;
using POSSystem.Windows;
using System.Data.Entity;
using System.Xml.XPath;

namespace POSSystem.Windows
{
    /// <summary>
    /// Interaction logic for SearchBoard.xaml
    /// </summary>
    public partial class SearchBoard : Window
    {
        
        public string selectedSearch { get; set; }
        public string drinkName { get; set; }

        pos_dbEntities3 dbEntities = new pos_dbEntities3();
        ObservableCollection<Product> name;
        ObservableCollection<Order> searchOrder;
      //  ObservableCollection<Customer> cust;

        public int count = 0;

        
        
        List<string> data = new List<string>();
        List<string> orderData = new List<string>();

        string keyInput = "";
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

        public void Enter_Button_Click(object sender, RoutedEventArgs e)
        {
            //SqlConnectionStringBuilder connectionRead = new SqlConnectionStringBuilder();
            //connectionRead.DataSource = "gk-ws01";
            //connectionRead.InitialCatalog = "pos_db";
            //connectionRead.IntegratedSecurity = true;
            //foreach(Order order in searchOrder)
            //{
            //    order.OrderID++;
            //    order.ItemID = query2.ItemID;
            //    order.Price = query2.Price;
            //}
            //OrderItem item = new OrderItem
            //{

            //    OrderDate = new DateTime(),
            //    ItemID = query2.ItemID,
            //    Price = query2.Price,
            //    Name = SearchTB.Text
                
            //};

            //OrderItemList.Add(item);
            //main.currentOrderDG.Items.Add(item);
            //          CollectionViewSource.GetDefaultView(main.currentOrderDG.ItemsSource).Refresh();
            //            main.currentOrderDG.Items.Refresh();
            MainMenu main = new MainMenu();
            DateTime now = DateTime.Now;
            DateTime dt = new DateTime(now.Year, now.Month, now.Day, 16, 0, 0);

            var query2 = name.FirstOrDefault(x => x.ProductName == SearchTB.Text);
            //var query3 = cust.FirstOrDefault(x => x.CustomerID  == count );
            //var query = searchOrder.FirstOrDefault(x => x.OrderID  );
            searchOrder = new ObservableCollection<Order>(dbEntities.Orders);

            SqlConnectionStringBuilder connectionWrite = new SqlConnectionStringBuilder();
            connectionWrite.DataSource = "gk-ws01";
            connectionWrite.InitialCatalog = "pos_db";
            connectionWrite.IntegratedSecurity = true;

            using (SqlConnection connectionWriteSql = new SqlConnection(connectionWrite.ConnectionString))
            {
                connectionWriteSql.Open();
                using (SqlCommand sqlWriteCmd = connectionWriteSql.CreateCommand())
                {
                    sqlWriteCmd.CommandText = @"Insert Into Orders (OrderID,CustomerID,ProductID,OrderDate) 
                                                Values(@OrderID,@CustomerID,@ProductID,@OrderDate)";
                    sqlWriteCmd.Parameters.Add("@OrderID    ", System.Data.SqlDbType.Int , 12);
                    sqlWriteCmd.Parameters.Add("@CustomerID ", System.Data.SqlDbType.Int, 12).Value = main.custId;
                    sqlWriteCmd.Parameters.Add("@ProductID  ", System.Data.SqlDbType.Int, 12).Value = query2.ProductID;
                    sqlWriteCmd.Parameters.Add("@OrderDate  ", System.Data.SqlDbType.Date).Value = dt;
                    sqlWriteCmd.ExecuteNonQuery();



                }
                connectionWriteSql.Close();
            };


            //var OrderItemList = new List<OrderItem>();
            //var order1 = new OrderItem();
            main.Show();
            this.Close();

        }
          
        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            //SqlConnection connection = new SqlConnection();
            //connection.ConnectionString = "data source = gk - ws01; initial catalog = pos_db; integrated security = True; MultipleActiveResultSets = True; App = EntityFramework";
            //SqlDataAdapter adapter = new SqlDataAdapter();
            //connection.Open();
            //SqlDataReader dr;
            //SqlCommand command = new SqlCommand("select Name from Drinks where Name LIKE @name", connection);
            //command.Parameters.Add(new SqlParameter("@name", "%" + SearchTB.Text + "%"));
            //command.ExecuteNonQuery();
            //dr = command.ExecuteReader();
            //AutoCompleteStringCollection col = new AutoCompleteStringCollection();

            ////            TextCompositionAutoComplete col = new TextCompositionAutoComplete();

            //while (dr.Read())
            //{
            //    col.Add(dr.GetString(0));
            //}
            //SearchTB.AutoWordSelection = col;

        }

        private void SearchTB_KeyUp(object sender, KeyEventArgs e)
        {
            bool found = false;
            var border = (resultStack.Parent as ScrollViewer).Parent as Border;
           // var data = DrinkSearch.GetData();

            string query = (sender as TextBox).Text;

            if (query.Length == 0)
            {
                // Clear   
                resultStack.Children.Clear();
                border.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                border.Visibility = System.Windows.Visibility.Visible;
            }

            // Clear the list   
            resultStack.Children.Clear();

            // Add the result   
            foreach (var obj in data)
            {
                if (obj.ToLower().StartsWith(query.ToLower()))
                {
                    // The word starts with this... Autocomplete must work   
                    addItem(obj);
                    found = true;
                }
            }

            if (!found)
            {
                resultStack.Children.Add(new TextBlock() { Text = "No results found." });
            }
        }

        private void addItem(string text)
        {
            TextBlock block = new TextBlock();

            // Add the text   
            block.Text = text;

            // A little style...   
            block.Margin = new Thickness(2, 3, 2, 3);
            block.Cursor = Cursors.Hand;

            // Mouse events   
            block.MouseLeftButtonUp += (sender, e) =>
            {
                SearchTB.Text = (sender as TextBlock).Text;
            };

            block.MouseEnter += (sender, e) =>
            {
                TextBlock b = sender as TextBlock;
                b.Background = Brushes.PeachPuff;
            };

            block.MouseLeave += (sender, e) =>
            {
                TextBlock b = sender as TextBlock;
                b.Background = Brushes.Transparent;
            };

            // Add to the panel   
            resultStack.Children.Add(block);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SearchTB.Focus();
            
            name = new ObservableCollection<Product>(dbEntities.Products);
            foreach (Product product in name)
            {
                product.ProductName.Trim();
                
                data.Add(product.ProductName);


                
            }
        }
    }
}
