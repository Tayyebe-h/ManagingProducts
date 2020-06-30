using System;
using System.Collections.Generic;
using System.Text;
using ManagingProducts.Models;
using ManagingProducts.Repositories;
using MongoDB.Driver;

namespace ManagingProducts.Helper
{
    public class MongoDBConfigFile
    {
        public static IMongoCollection<Product> GetDBCollection()
        {
            var _client = new MongoClient("mongodb+srv://Alina_Iakimchuk:Greenday15@student-e94gn.mongodb.net/ManagingProducts_Database?retryWrites=true&w=majority");
            var _database = _client.GetDatabase("ManagingProducts_Database");
            return _database.GetCollection<Product>("Products");
        }
    }
}
