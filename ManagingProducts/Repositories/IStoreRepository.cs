using System;
using System.Collections.Generic;
using System.Text;
using ManagingProducts.Models;
using ManagingProducts.Operations;

namespace ManagingProducts.Repositories
{
    public interface IStoreRepository
    {
        string GetFileAddress();
        IEnumerable<Store> GetAll();
        Store GetOneStoreProducts(Store store);
        void Delete(Store store);
        void Save();
        void InsertUpdate(Store store);
        IEnumerable<Store> GetlistofStores();
        IEnumerable<string> GetlistofStoresNames();

    }
}
