using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class BasketItem : BaseEntity
    {
        public String BasketId { get; set; }
        public String ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
