using System;
using System.Collections.Generic;
using System.Text;
using ManagingProducts.Repositories;
using ManagingProducts.Operations;

namespace ManagingProducts.Models
{
    class Product
    {

        private List<Store> stores = new List<Store>();
        private Manufacture manufacture = new Manufacture();
        public List<Store> Stores
        {
            get => stores;
            set => stores = value;
        }
        public Manufacture Manufacture
        {
            get => manufacture;
            set => manufacture = value;
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

    }
}
