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

        PosDBEntities posEBEntities = new PosDBEntities();
        ObservableCollection<User> users;

        public Login()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            users = new ObservableCollection<User>(posEBEntities.Users);
            foreach(User user in users)
            {
                user.Username.Trim();
            }

        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            var query = from user in users
                        where (UsernameTB.Text == user.Username && PasswordTB.Text == user.Password)
                        select user;
            //check for correct login info
            if(query.Count() > 0)
            {
                MainWindow window = new MainWindow();
                window.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect Username or Password");
            }
            
            
        }

        
    }
}
