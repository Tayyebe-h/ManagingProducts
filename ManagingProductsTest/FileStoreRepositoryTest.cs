using System;
using System.Collections.Generic;
using System.Text;
using ManagingProducts.Repositories;
using ManagingProducts.Models;
using Xunit;

namespace ManagingProductsTest
{
    public class FileStoreRepositoryTest
    {
        [Fact]
        public void GetAllTest()
        {
            IStoreRepository repository = new FileStoreRepository();
            IEnumerable<Store> stores = repository.GetAll();
            Assert.NotEmpty(stores);
        }
        
        [Fact]
        public void GetListfSoresTest()
        {
            IStoreRepository repository = new FileStoreRepository();

            IEnumerable<Store> stores = repository.GetlistofStores();

            Assert.NotEmpty(stores);
        }

        [Fact]
        public void GetListOfStoresNamesTest()
        {
            IStoreRepository repository = new FileStoreRepository();

            IEnumerable<string> stores = repository.GetlistofStoresNames();

            Assert.NotEmpty(stores);
        }

        [Fact]
        public void GetOneStoresProductsTest()
        {
            IStoreRepository repository = new FileStoreRepository();
            Store store = new Store();
            store.Name = "Coop";  //Coop store already exists in database.

            var store1 = repository.GetOneStoreProducts(store);
            var result = store1.Products;

            Assert.NotEmpty(result);
        }
    }
}
