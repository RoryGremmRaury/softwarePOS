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

namespace testPOS
{
    /// <summary>
    /// Interaction logic for SearchBoard.xaml
    /// </summary>
    /// 


    public partial class SearchBoard : Window
    {
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
    }
}
