using System;
using System.Collections.Generic;
using System.Text;
using ManagingProducts.Models;
using MongoDB.Driver;
using System.IO;
using System.Linq;

namespace ManagingProducts.Repositories
{
    public class MongoDbProductRepository : IProductRepository
    {
        private IMongoCollection<Product> _collection;

        public MongoDbProductRepository(IMongoCollection<Product> collection)
        {
            _collection = collection;
        }

        public List<Product> GetAll()
        {
            var all = _collection.Find(Builders<Product>.Filter.Empty);
            return all.ToList();
        }

        public bool CheckExistence(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            _collection.DeleteOne(s => s.ProductId == product.ProductId);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public string GetFileAddress()
        {
            throw new NotImplementedException();
        }

        public Product GetOneProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void Insert(Product product)
        {
            _collection.InsertOne(product);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            _collection.ReplaceOne(p => p.ProductId == product.ProductId, product);
        }
    }
}
