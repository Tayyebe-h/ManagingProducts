using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ManagingProducts.Models;
using ManagingProducts.Operations;
using ManagingProducts.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace ManagingProducts
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var _client = new MongoClient("mongodb+srv://Alina_Iakimchuk:Greenday15@student-e94gn.mongodb.net/ManagingProducts_Database?retryWrites=true&w=majority");
            var _database = _client.GetDatabase("ManagingProducts_Database");
            var _collection = _database.GetCollection<Product>("Products");

            IProductRepository productRepository = new MongoDbProductRepository(_collection);
            var list = productRepository.GetAll();

            Menu.ConsoleMenu();
            Menu.Run();
        }
    }
}
