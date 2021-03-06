﻿using System;
using System.Collections.Generic;
using System.Text;
using ManagingProducts.Models;
using ManagingProducts.Repositories;
using System.Linq;
using System.IO;
using ManagingProducts.SearchMethods;
using MongoDB.Driver;
using System.Runtime.CompilerServices;
using ManagingProducts.Helper;

namespace ManagingProducts.Operations
{
    public class ProductOperations
    {
        public static IProductRepository repository = new MongoDbProductRepository(MongoDBConfigFile.GetDBCollection());
        public static Product product = new Product();

        public static void Database() 
        {
            IEnumerable<Product> list1 = repository.GetAll();
            foreach (Product product in list1)
            {
                WriteProductInfo(product);
            }
            Console.WriteLine("The number of existing products: " + list1.Count());
        }

        public static void AddProduct() 
        {
            GetProductId();
            if (!repository.CheckExistence(product))
            {
                GetProductInfo();
                repository.Insert(product);
                Console.WriteLine("The product is added.");
            }
            else
            {
                Console.WriteLine("A product with this Id already exists.You can change the Id or choose to update the product's information");
            }
        }

        public static void UpdateAProduct() 
        {
            GetProductId();
                        
            if (repository.CheckExistence(product))
            {
                repository.Delete(product);
                GetProductInfo();
                repository.Insert(product);
                Console.WriteLine("The information of the product is updated.");
            }
            else
            {
                Console.WriteLine("The product doesn't exists. You can choose to add the product.");
            }
        }

        public static void DeleteProduct() 
        {
            GetProductId();
            if (repository.CheckExistence(product))
            {
                repository.Delete(product);
                Console.WriteLine("The product is deleted.");
            }
            else
            {
                Console.WriteLine("The product doesn't exists.");
            }
        }

        public static void SearchProductById() 
        {
            GetProductId();
            if (repository.CheckExistence(product))
            {
                product = repository.GetOneProduct(product.ProductId);
                WriteProductInfo(product);
            }
            else
            {
                Console.WriteLine("The product doesn't exists.");
            }
        }

        public static void SearchCheapProducts() 
        {
            List<Product> list = repository.GetAll();
            Console.WriteLine("Enter the price!");
            int price = ReadNumber();
            list = list.Where(x => x.Price < price).ToList();
            list = list.OrderBy(x => x.Price).ToList();
            if (list.Count() == 0)
            {
                Console.WriteLine("There is not any product cheaper than " + price);
            }
            else
            {
                if (list.Count() <= 10)
                {
                    foreach (Product product in list)
                    {
                        WriteProductInfo(product);
                    }
                }
                else
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine("Product: " + list[i].Name + "  Id: " + list[i].ProductId + "  Price: " + list[i].Price + "\n" + "Stores: ");
                        foreach (Store s in list[i].Stores)
                        {
                            Console.WriteLine(s.Name);
                        }
                        Console.WriteLine(" ");
                    }
                }
            }
        }

        public static void SearchByName()
        {
            var stringDist = new LevenshteinDistance();
            List<Product> list = new List<Product>();

            Console.WriteLine("Enter the name of the product!");
            string name = Console.ReadLine();
           
            List<Product> products = repository.GetAll();
            foreach(Product p in products)
            {
                if (stringDist.GetDistance(p.Name,name) > 0.5)
                {
                    list.Add(p);
                }
            }

            if (list.Count > 0)
            {
                foreach(Product product in list)
                {
                    WriteProductInfo(product);
                }
            }
            else
            {
                Console.WriteLine("No product with this name is found.");
            }
        }

        private static int ReadNumber()
        {
            while (true)
            {
                try
                {
                    int number = Int32.Parse(Console.ReadLine());
                    if (number >= 0)
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

        public static void GetProductInfo()
        {
            Console.WriteLine("Name :");
            product.Name = Console.ReadLine();
            Console.WriteLine("Price :");
            product.Price = ReadNumber();

            Console.WriteLine("Manufacture:");
            product.Manufacture = new Manufacture();
            product.Manufacture.Name = Console.ReadLine();
            product.Stores = new List<Store>();
            Console.WriteLine("How many stores have the product?");
            int num = ReadNumber();
            Console.WriteLine("Enter the name of stores!");
            for (int i = 0; i < num; i++)
            {
                Store s = new Store();
                s.Name = Console.ReadLine();
                product.Stores.Add(s);
            }
        }

        private static void WriteProductInfo(Product product)
        {
            Console.WriteLine("Product: " + product.Name + "  Id: " + product.ProductId + "  Price: " + product.Price +"  Manufacture: "+product.Manufacture.Name+"\n" + "Stores: ");
            foreach (Store s in product.Stores)
            {
                Console.WriteLine(s.Name);
            }
            Console.WriteLine(" ");
        }

        public static void GetProductId()
        {
            Console.WriteLine("Enter the product's data!");
            Console.WriteLine("Id: ");
            product.ProductId = Console.ReadLine();
        }
    }
}
