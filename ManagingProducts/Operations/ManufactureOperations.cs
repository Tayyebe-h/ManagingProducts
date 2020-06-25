using System;
using System.Collections.Generic;
using System.Text;
using ManagingProducts.Models;
using ManagingProducts.Repositories;
using System.Linq;



namespace ManagingProducts.Operations
{
    public class ManufactureOperations
    {
                

        public static void ListManufactures()
        {
            IProductRepository repository = new FileProductRepository();

            IEnumerable<Product> list = repository.GetAll();
            IEnumerable<Manufacture> list1 = list.Select(p => p.Manufacture).ToList();
            IEnumerable<string> list2 = list1.Select(m => m.Name).ToList();
            list2 = list2.Distinct();

            Manufacture manufacture = new Manufacture();

            foreach (string s in list2)
            {
                manufacture.Products = list.Where(p => p.Manufacture.Name == s).ToList();
                manufacture.Name = s;
                Console.WriteLine("Manufacture: " + manufacture.Name + "  Number of products: " + manufacture.Products.Count());
            }


        }
    }
}
