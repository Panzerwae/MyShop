using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.ViewModels
{
    public class BasketItemViewModel
    {
        public String Id { get; set; }
        public int Quantity { get; set; }
        public String ProductName { get; set; }
        public Decimal Price { get; set; }
        public String Image { get; set; }
    }
}
