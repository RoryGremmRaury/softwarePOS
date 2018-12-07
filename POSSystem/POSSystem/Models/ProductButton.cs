using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace POSSystem.Models
{
    public class ProductButton : UIElement
    {
        public int Height { get; set; } = 40;
        public int Width { get; set; } = 80;
        public string Name { get; set; } = "test";

        public ProductButton(string name)
        {
            Name = name;
            Button pb = new Button();
            pb.DataContext = this;
            pb.MinWidth = Width;
            pb.MinHeight = Height;
            pb.Content = Name;
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        
    }
}
