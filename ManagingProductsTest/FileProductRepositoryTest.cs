using System;
using Xunit;
using ManagingProducts.Operations;
using ManagingProducts.Repositories;
using ManagingProducts.Models;
using System.Collections.Generic;

namespace ManagingProductsTest
{
    public class FileProductRepositoryTest
    {

        [Fact]
        public void CalltoGetAllWithAnExistingProduct()
        {
            IProductRepository productRepository = new FileProductRepository();
            List<Product> products = productRepository.GetAll();

            string temp = products[0].Name;

            Assert.Equal("Apple", temp);
        }

        [Fact]
        public void CalltoGetAllWithNumberOfProducts()
        {
            IProductRepository productRepository = new FileProductRepository();

            List<Product> products = productRepository.GetAll();
            var num = products.Count;


            Assert.Equal(10, num); //The number of products in database is 10
        }


        [Fact]
        public void CheckExistenceTestReturnTrue()
        {
            IProductRepository productRepository = new FileProductRepository();
            Product product = new Product();
            product.ProductId = "1";    // a product which we know already exists in database.

            var result = productRepository.CheckExistence(product);

            Assert.True(result);

        }

        [Fact]
        public void CheckExistenceTestReturnFalse()
        {
            IProductRepository productRepository = new FileProductRepository();
            Product product = new Product();
            product.ProductId = "100";    // a product which we know doesn't exist in database.

            var result = productRepository.CheckExistence(product);

            Assert.False(result);
        }

        [Fact]
        public void GetAllTest()
        {
            IProductRepository productRepository = new FileProductRepository();

            List<Product> products = productRepository.GetAll();

            Assert.NotEmpty(products);
        }

        [Fact]
        public void GetOneProductTest()
        {
            IProductRepository productRepository = new FileProductRepository();
            Product product = new Product();
            product.ProductId = "0";

            Product product1 = productRepository.GetOneProduct(product);
            var result = product1.Name;

            Assert.Equal("Apple", result);   // in database Apple's Id is 0
        }
    }
}
