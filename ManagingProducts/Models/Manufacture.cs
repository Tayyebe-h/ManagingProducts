using System;
using System.Collections.Generic;
using System.Text;
using ManagingProducts.Repositories;
using ManagingProducts.Operations;

namespace ManagingProducts.Models
{
    class Manufacture
    {

        private ICollection<Product> products = new List<Product>();
        public ICollection<Product> Products
        {
            get => products;
            set => products = value;

        }

        public string Name { get; set; }
    }
}
