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
using POSSystem;

namespace testPOS
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        private string userInput;

        PosDBEntities_ posEBEntities = new PosDBEntities_();
        ObservableCollection<User> users;

        public Login()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //initialize user db
            users = new ObservableCollection<User>(posEBEntities.Users_);

            //trim usernames and passwords of whitespace
            foreach(User user in users)
            {
                user.UserLoginName.Trim();
                user.UserPassword.Trim();
            }
            UserIdTB.Focus();

        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            //see if either username or password fields are blank, if UN is filled in, make password the new focus.
            
            

            //if they're both filled in, check creds.


            //query database for UN/PW combo
            var query = from user in users
                        where (UserIdTB.Text == user.UserLoginName && PasswordTB.Text == user.UserPassword)
                        select user;
            //if there is at least one user with that login info then...
            if(query.Count() > 0)
            {
                //open Main window, close login screen
                //UserName = ((User)query).Username;
                //UserPassword = ((User)query).Password;
                MainWindow window = new MainWindow();
                window.Show();
                this.Close();
            }
            else
            {
                //if creds are wrong, let user know
                MessageBox.Show("Incorrect Username or Password");
            }
        }

        private void NumButton_Click(object sender, RoutedEventArgs e)
        {
            
            //pull number from button pressed
            userInput = (((Button)sender).Content).ToString();
            //add number to string in credential area
            PasswordTB.Text += userInput;
        }
        private void CLRButton_Click(object sender, RoutedEventArgs e)
        {
            string text = PasswordTB.Text;
            if(text.Length > 0)
            {
                text = text.Remove(text.Length - 1, 1);
                PasswordTB.Text = text;
            }
        }
    }
}
