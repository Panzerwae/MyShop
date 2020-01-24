using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class Customer : BaseEntity
    {
        public String UserId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Street { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String ZipCode { get; set; }
    }
}
