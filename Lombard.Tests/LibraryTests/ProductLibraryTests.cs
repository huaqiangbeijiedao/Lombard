using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lombard.API.Models;
using Lombard.Logic;
using NUnit.Framework;

namespace Lombard.Tests.LibraryTests
{
    [TestFixture]
    class ProductLibraryTests
    {
        [Test]
        public void GetAllProducts_PopulatedList_ReturnsPopulatedList()
        {
            ProductLibrary library = new ProductLibrary();
            List<Product> products = new List<Product>();
            products.Add(new Product()
            {
                Name = "Test"
            });
            products.Add(new Product()
            {
                Name = "Test"                
            });

            IEnumerable<Product> result = library.GetAllProducts(new EnumerableQuery<Product>(products));

            Assert.IsTrue(result.Count() == 2);
            Assert.IsTrue(result.All(p => p.Name == "Test"));
        }

        [Test]
        public void GetAllProducts_EmptyProductList_ReturnsEmptyList()
        {
            ProductLibrary library = new ProductLibrary();
            List<Product> products = new List<Product>();

            IEnumerable<Product> result = library.GetAllProducts(new EnumerableQuery<Product>(products));

            Assert.IsTrue(!result.Any());
        }

        [Test]
        public void CheckProductsOutage_LowQuantity_ReturnsLowProducts()
        {
            ProductLibrary library = new ProductLibrary();
            List<Product> products = new List<Product>();
            products.Add(new Product()
            {
                Name = "Test",
                Quantity = 1
            });


            IEnumerable<Product> result = library.GetAllProducts(new EnumerableQuery<Product>(products));

            Assert.IsTrue(result.Count() == 1);
            Assert.IsTrue(result.Any(p => p.Name == "Test"));
            Assert.IsTrue(result.Any(p => p.Quantity == 1));
        }

        [Test]
        public void CheckProductsOutage_EmptyList_ReturnsEmptyList()
        {
            ProductLibrary library = new ProductLibrary();
            List<Product> products = new List<Product>();


            IEnumerable<Product> result = library.GetAllProducts(new EnumerableQuery<Product>(products));

            Assert.IsTrue(!result.Any());
        }
    }
}
