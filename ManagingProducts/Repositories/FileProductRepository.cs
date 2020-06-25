using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ManagingProducts.Models;


namespace ManagingProducts.Repositories
{
    public class FileProductRepository : IProductRepository
    {
        private static List<Product> Productslist = new List<Product>();
        private static List<Product> list = new List<Product>();


        public FileProductRepository()
        {
            var filePath = GetFileAddress();
            var jsonString = File.ReadAllText(filePath);

            try
            {
                list = JsonSerializer.Deserialize<List<Product>>(jsonString);
                Productslist = list.OrderBy(x => x.Id).ToList();

            }
            catch
            {
                return;
            }

        }



        public List<Product> GetAll()
        {

            return Productslist;

        }


        public Product GetOneProduct(Product p)
        {

            var product = Productslist.Where(x => x.Id == p.Id).FirstOrDefault();
            return product;

        }


        public void Insert(Product product)
        {

            Productslist.Add(product);
            Save();

        }

        public void UpdateProduct(Product product)
        {

            int index = Productslist.FindIndex(item => item.Id == product.Id);

            Productslist[index] = product;

            Save();

        }

        public bool CheckExistence(Product product)
        {

            int index = Productslist.FindIndex(item => item.Id == product.Id);
            if (index >= 0)
            {
                return true;
            }
            else
                return false;

        }



        public void Delete(Product product)
        {

            int index = Productslist.FindIndex(item => item.Id == product.Id);

            Productslist.RemoveAt(index);
            Save();

        }



       

        public void Save()
        {
            var filePath = GetFileAddress();
            var jsonString = JsonSerializer.SerializeToUtf8Bytes(Productslist);
            File.WriteAllBytes(filePath, jsonString);
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
