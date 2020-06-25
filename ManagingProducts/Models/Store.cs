using System;
using System.Collections.Generic;
using System.Text;

namespace ManagingProducts.Models
{
    public class Store
    {
        private List<Product> products = new List<Product>();
        public List<Product> Products
        {
            get => products;
            set => products = value;

        }

        public string Name { get; set; }


    }
}
