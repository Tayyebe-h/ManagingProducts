using System;
using System.Collections.Generic;
using System.Text;
using ManagingProducts.Repositories;
using ManagingProducts.Operations;

namespace ManagingProducts.Models
{
    class Store
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
