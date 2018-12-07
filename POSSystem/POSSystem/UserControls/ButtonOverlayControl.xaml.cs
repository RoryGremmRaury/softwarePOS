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
    /// Interaction logic for ProductButtonControl.xaml
    /// </summary>
    public partial class ButtonOverlayControl : UserControl
    {
        public List<POSSystem.Models.ProductButton> PButtons { get; set; }
        public ButtonOverlayControl(List<POSSystem.Models.ProductButton> pButtons)
        {
            InitializeComponent();
            PButtons = pButtons;
            DataContext = this;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < PButtons.Count; i++)
            {
                ProductButtonControl buttonControl = new ProductButtonControl(PButtons[i]);

                ColumnDefinition column = new ColumnDefinition();
                column.Width = new GridLength(1, GridUnitType.Star);
                ButtonOverlay.ColumnDefinitions.Add(column);
                ButtonOverlay.Children.Add(buttonControl);
                Grid.SetColumn(buttonControl, i);
            }
        }
    }
}
