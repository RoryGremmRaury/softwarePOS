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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public string UserName { get; set; }
        private string UserPassword { get; set; }
        private string userInput;

        pos_dbEntities dbEntities = new pos_dbEntities();
        ObservableCollection<User> users;
        
        public Login()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //initialize user db
            users = new ObservableCollection<User>(dbEntities.Users);

            //trim usernames and passwords of whitespace
            foreach (User user in users)
            {
                user.Username.Trim();
                user.Password.Trim();
            }
            UserIdTB.Focus();
        }

        private void NumButton_Click(object sender, RoutedEventArgs e)
        {

            //pull number from button pressed
            userInput = (((Button)sender).Content).ToString();
            //add number to string in credential area
            PasswordTB.Password += userInput;
        }
        private void CLRButton_Click(object sender, RoutedEventArgs e)
        {
            string text = PasswordTB.Password;
            if (text.Length > 0)
            {
                text = text.Remove(text.Length - 1, 1);
                PasswordTB.Password = text;
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            var query = from user in users
                        where (UserIdTB.Text == user.Username && PasswordTB.Password == user.Password)
                        select user;


            //if there is at least one user with that login info then...
            if (query.Count() > 0)
            {
                MainMenu window = new MainMenu();
                window.Show();
                this.Close();
            }
            else
            {
                //if creds are wrong, let user know
                MessageBox.Show("Incorrect Username or Password");
            }
        }
    }
}
