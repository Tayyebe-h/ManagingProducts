using System;
using System.Collections.Generic;
using System.Text;

namespace ManagingProducts.Models
{
    public class Manufacture
    {
        private ICollection<Product> products = new List<Product>();
        public ICollection<Product> Products { get; set; }
        public string Name { get; set; }
    }
}
