﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class Product : BaseEntity
    {
        [StringLength(20)]
        [DisplayName("Product Name")]
        public String Name { get; set; }
        public String Description { get; set; }
        public Decimal Price { get; set; }
        public String Category { get; set; }
        public String Image { get; set; }

        public Product()
        {
            
        }
    }
}
