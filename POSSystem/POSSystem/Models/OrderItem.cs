using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSystem
{
    class OrderItem
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public int ItemID { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public string Name { get; set; }
    }
}
