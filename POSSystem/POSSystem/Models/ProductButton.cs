using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        
    }
}
