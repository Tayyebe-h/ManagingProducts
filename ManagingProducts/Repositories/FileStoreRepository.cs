using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ManagingProducts.Models;
using ManagingProducts.Repositories;
using ManagingProducts.Helper;

namespace ManagingProducts.Repositories
{
    public class FileStoreRepository : IStoreRepository
    {
        public static IProductRepository productRepository = new MongoDbProductRepository(MongoDBConfigFile.GetDBCollection());
        public static List<Product> allProducts = productRepository.GetAll();
        public static List<Product> list = new List<Product>();

        public FileStoreRepository()
        {
            var filePath = GetFileAddress();
            var jsonString = File.ReadAllText(filePath);

            try
            {
                list = JsonSerializer.Deserialize<List<Product>>(jsonString);
            }
            catch
            {
                return;
            }
        }

        public void Delete(Store store)
        {
            List<Product> list1 = allProducts.Where(product => product.Stores.Any(s => s.Name == store.Name)).ToList();
            foreach (Product p in list1)
            {
                p.Stores.RemoveAll(s => s.Name == store.Name);
            }
        }

        public IEnumerable<Store> GetAll()
        {
            IEnumerable<string> list1 = GetlistofStoresNames();
            List<Store> list2 = new List<Store>();

            foreach (string x in list1)
            {
                List<Product> listProductsofOneStores = allProducts.Where(product => product.Stores.Any(s => s.Name == x)).ToList();
                Store store = new Store();
                store.Products = listProductsofOneStores;
                store.Name = x;
                list2.Add(store);
            }
            return list2;
        }

        public Store GetOneStoreProducts(Store store)
        {
            IEnumerable<Product> listProductsofOneStores = allProducts.Where(product => product.Stores.Any(s => s.Name == store.Name)).ToList();
            store.Products = listProductsofOneStores.OrderBy(x => x.ProductId).ToList();
            return store;
        }

        public void InsertUpdate(Store store)
        {
            foreach (Product product in store.Products)
            {
                int index = allProducts.FindIndex(item => item.ProductId == product.ProductId);
                if (index >= 0)
                {
                    bool containsItem = allProducts[index].Stores.Any(item => item.Name == store.Name);
                    if (containsItem)
                    {
                        return;
                    }
                    else
                    {
                        Store newStore = new Store();
                        newStore.Name = store.Name;
                        allProducts[index].Stores.Add(newStore);
                    }
                }
                else
                {
                    Store newStore = new Store();
                    newStore.Name = store.Name;
                    product.Stores.Add(newStore);
                    productRepository.Insert(product);
                }
            }
        }

        public void Save()
        {
            var filePath = GetFileAddress();
            var jsonString = JsonSerializer.SerializeToUtf8Bytes(list);
            File.WriteAllBytes(filePath, jsonString);
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


        public IEnumerable<Store> GetlistofStores()
        {
            IEnumerable<Store> list1 = allProducts.SelectMany(P => P.Stores).ToList();
            return list1;
        }

        public IEnumerable<string> GetlistofStoresNames()
        {
            IEnumerable<string> list3 = new List<string>();
            IEnumerable<Store> list1 = GetlistofStores();
            IEnumerable<string> list2 = list1.Select(P => P.Name).ToList();
            
            return list3 = list2.Distinct();
        }
    }
}
