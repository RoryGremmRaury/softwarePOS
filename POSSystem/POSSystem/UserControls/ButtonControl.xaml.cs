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

namespace POSSystem.UserControls
{
    /// <summary>
    /// Interaction logic for ButtonControl.xaml
    /// </summary>
    public partial class ProductButtonControl : UserControl
    {
        public POSSystem.Models.ProductButton ProdButton { get; set; }

        public ProductButtonControl(POSSystem.Models.ProductButton prodButton)
        {
            ProdButton = prodButton;
            
            InitializeComponent();
            DataContext = this;
            NameLabel.Text = prodButton.Name;
        }
    }
}
