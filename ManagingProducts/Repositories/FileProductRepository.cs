using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ManagingProducts.Models;
using ManagingProducts.Helper;

namespace ManagingProducts.Repositories
{
    public class FileProductRepository : IProductRepository
    {
        private readonly List<Product> _products;

        public FileProductRepository()
        {
            var path = Path.Combine(FileHelper.GetUserHomePath(), "Assignment4", "Data.json");
            _products = File.Exists(path) ? FileHelper.LoadFromJson<Product>(path).ToList() : new List<Product>();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public Product GetOneProduct(Product product)
        {
            return _products.Where(x => x.ProductId == product.ProductId).FirstOrDefault();
        }

        public void Insert(Product product)
        {
            _products.Add(product);
            Save();
        }

        public void UpdateProduct(Product product)
        {
            int index = _products.FindIndex(item => item.ProductId == product.ProductId);
            _products[index] = product;
            Save();
        }

        public bool CheckExistence(Product product)
        {
            int index = _products.FindIndex(item => item.ProductId == product.ProductId);
            if (index >= 0)
            {
                return true;
            }
            else
                return false;
        }

        public void Delete(Product product)
        {
            _products.Remove(product);
            Save();
        }

        public void Save()
        {
            var path = Path.Combine(FileHelper.GetUserHomePath(), "Assignment4", "Data.json");
            FileHelper.SaveToJson(path, _products);
        }

        void IDisposable.Dispose()
        {
            Save();
        }

        public string GetFileAddress()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile,
                  Environment.SpecialFolderOption.DoNotVerify);

            var programPath = Path.Combine(path, "Assignment4");

            if (!Directory.Exists(programPath))
            {
                Directory.CreateDirectory(programPath);
            }

            var filePath = Path.Combine(programPath, "Data.json");
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
            return filePath;
        }
    }
}