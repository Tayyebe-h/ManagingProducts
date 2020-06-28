using System;
using System.Collections.Generic;
using System.Text;
using ManagingProducts.Models;
using ManagingProducts.Repositories;
using System.Linq;
using System.IO;


namespace ManagingProducts.Operations
{
    public class StoreOperations
    {

        static IStoreRepository repository = new FileStoreRepository();
        static IProductRepository repository1 = new FileProductRepository();

        public static void ListAllStores() 
        {

            IEnumerable<Store> list = repository.GetAll();
            foreach (Store s in list)
            {
                Console.WriteLine(" Store: " + s.Name);
                Console.WriteLine(" List of products:");
                foreach (Product p in s.Products)
                {
                    Console.WriteLine(p.Name + "   Price: " + p.Price + "   Id: " + p.Id + "    Manufacture:  " + p.Manufacture.Name);
                }
                Console.WriteLine(" ");
                Console.WriteLine(" ");
            }
        }


        public static void ListaStoresProducts()
        {
                        
            Store store1 = new Store();
            Console.WriteLine("Enter the name of store!");
            Console.WriteLine(" ");
            store1.Name = Console.ReadLine();

            store1 = repository.GetOneStoreProducts(store1);
            if (store1.Products.Count == 0)
            {
                Console.WriteLine("This Store doesn't exist.");
            }
            else
            {
                Console.WriteLine("The number of products in " + store1.Name + " is " + store1.Products.Count());
                Console.WriteLine(" ");
                Console.WriteLine("List of products :");

                foreach (Product x in store1.Products)
                {
                    Console.WriteLine(x.Name + "  Price: " + x.Price + "  Id: " + x.Id + "  Manufacture: " + x.Manufacture.Name);
                }

            }




        }

        public static void AddaStore()  
        {
            
            IEnumerable<string> stores = repository.GetlistofStoresNames();

            Console.WriteLine("Enter the name of the store!");
            Store store = new Store();
            store.Name = Console.ReadLine();

            if (stores.Contains(store.Name))
            {
                Console.WriteLine("This store already exists.");

            }
            else
            {
                Console.WriteLine("How many products has the store?");
                int num = ReadNumber();
                if (num == 0)
                {
                    Console.WriteLine("Sorry we can not have a store with no product.");
                }
                else
                {
                    for (int i = 0; i < num; i++)
                    {
                        Product p = new Product();
                        Console.WriteLine("Enter the Id of the product!");
                        p.Id = Console.ReadLine();
                        if (repository1.CheckExistence(p))
                        {
                            Console.WriteLine("This product already exists so you don't need to enter other information.");
                            store.Products.Add(p);
                        }
                        else
                        {
                            Console.WriteLine("Enter the name of the product!");
                            p.Name = Console.ReadLine();
                            Console.WriteLine("Enter the price of the product!");
                            p.Price = ReadNumber();
                            Console.WriteLine("Enter the manufacture of the product!");
                            p.Manufacture.Name = Console.ReadLine();

                            store.Products.Add(p);
                        }
                    }
                    repository.InsertUpdate(store);
                    Console.WriteLine("The store is added.");
                }
            }
        }


        public static void UpdateaStore() 
        {
            IEnumerable<string> stores = repository.GetlistofStoresNames();

            Console.WriteLine("Enter the name of the store!");
            Store store = new Store();
            store.Name = Console.ReadLine();

            if (stores.Contains(store.Name))
            {

                Console.WriteLine("How many products do you want to add to the store?");
                int num = ReadNumber();
                if( num == 0)
                {
                    Console.WriteLine("Sorry we can not have a store with no product.");
                }
                else
                {
                    for (int i = 0; i < num; i++)
                    {
                        Product p = new Product();
                        Console.WriteLine("Enter the Id of the product!");
                        p.Id = Console.ReadLine();
                        if (repository1.CheckExistence(p))
                        {
                            Console.WriteLine("This product already exists so you don't need to enter other information.");
                            store.Products.Add(p);
                        }
                        else
                        {
                            Console.WriteLine("Enter the name of the product!");
                            p.Name = Console.ReadLine();
                            Console.WriteLine("Enter the price of the product!");
                            p.Price = ReadNumber();
                            Console.WriteLine("Enter the manufacture of the product!");
                            p.Manufacture.Name = Console.ReadLine();
                            store.Products.Add(p);
                        }
                    }
                    repository.InsertUpdate(store);
                    Console.WriteLine("The store is updated.");
                }
            }
            else
            {
                Console.WriteLine("This store doesn't exists. If you want to insert it, choose to insert a store!");
            }
        }


        public static void DeleteStore()
        {

            Console.WriteLine("Enter the name of the store!");
            Store store = new Store();
            store.Name = Console.ReadLine();


            IEnumerable<string> stores = repository.GetlistofStoresNames();

            if (stores.Contains(store.Name))
            {
                repository.Delete(store);
                Console.WriteLine("The store is deleted now");
            }
            else
            {
                Console.WriteLine("This Store doesn't exist.");
            }
        }

         public static void SearchStores() 
        {
            Product p = new Product();
            Console.WriteLine("Enter the Id of the product!");
            p.Id = Console.ReadLine();
            if (repository1.CheckExistence(p))
            {
                Product p1 = repository1.GetOneProduct(p);
                if (p1.Stores.Count() != 0)
                {
                    Console.WriteLine("Product: " + p1.Name + "  Id: " + p1.Id + "  Price:" + p1.Price + "  Manufacture: " + p1.Manufacture.Name);
                    Console.WriteLine("List of stores:");
                    foreach (Store s in p1.Stores)
                    {
                        Console.WriteLine(s.Name);
                    }
                }
                else
                {
                    Console.WriteLine("The product doesn't exist in any store.");
                }
            }
            else
            {
                Console.WriteLine("The product doesn't exists.");
            }
        }

        private static int ReadNumber()
        {
            while (true)
            {
                try
                {
                    int number = Convert.ToInt32(Console.ReadLine());
                    if(number >= 0)
                    {
                        return number;
                    }
                    else
                    {
                        throw new Exception("Please enter a positive integer number!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
