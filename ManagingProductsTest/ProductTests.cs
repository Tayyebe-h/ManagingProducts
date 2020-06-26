using System;
using Xunit;
using ManagingProducts.Operations;
using ManagingProducts.Repositories;
using ManagingProducts.Models;
using System.Collections.Generic;

namespace ManagingProductsTest
{
    public class ProductTests
    {
        [Fact]
        public void Test1()
        {
            IProductRepository productRepository = new FileProductRepository();
            List<Product> products = productRepository.GetAll();

            string temp = products[0].Name;

            Assert.Equal("Apple", temp);
        }
    }
}
