using System;
using System.Collections.Generic;
using System.Text;
using ManagingProducts.Models;
using ManagingProducts.Operations;

namespace ManagingProducts.Repositories
{
    public interface IProductRepository : IDisposable
    {
        string GetFileAddress();
        List<Product> GetAll();
        Product GetOneProduct(string ProductId);
        Product GetOneProduct(Product product);
        void Delete(Product product);
        void Save();
        void Insert(Product product);
        void UpdateProduct(Product product);
        public bool CheckExistence(Product product);
        
    }
}
