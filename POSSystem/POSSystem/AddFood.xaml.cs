using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace POSSystem
{
    /// <summary>
    /// Interaction logic for AddFood.xaml
    /// </summary>
    public partial class AddFood : Window
    {
        public AddFood()
        {
            InitializeComponent();
        }


        private void submitfood_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source=MCHDTV-0010;Initial Catalog=pos_db;Integrated Security=True";
            if (nameTB.Text == "" || priceTB.Text == "")
                MessageBox.Show("please fill mandatory fields");



            else
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {


                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("foodAdd", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@ProductName", nameTB.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@ProductPrice", priceTB.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@ProductCategory", 1);
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Registration is successfull");


                }
            }


        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainMenu window = new MainMenu();
            window.Show();
            this.Close();
        }
    }
}
