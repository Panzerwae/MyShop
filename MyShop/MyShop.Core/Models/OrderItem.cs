using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class OrderItem : BaseEntity
    {
        public String OrderId { get; set; }
        public String ProductId { get; set; }
        public String PruductName { get; set; }
        public Decimal Price { get; set; }
        public String Image { get; set; }
        public int Quantity { get; set; }
    }
}
