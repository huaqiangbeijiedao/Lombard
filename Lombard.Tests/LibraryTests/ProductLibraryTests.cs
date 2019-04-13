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


            IEnumerable<Product> result = library.CheckProductsOutage(new EnumerableQuery<Product>(products));

            Assert.IsTrue(result.Count() == 1);
            Assert.IsTrue(result.Any(p => p.Name == "Test"));
            Assert.IsTrue(result.Any(p => p.Quantity == 1));
        }

        [Test]
        public void CheckProductsOutage_EmptyList_ReturnsEmptyList()
        {
            ProductLibrary library = new ProductLibrary();
            List<Product> products = new List<Product>();


            IEnumerable<Product> result = library.CheckProductsOutage(new EnumerableQuery<Product>(products));

            Assert.IsTrue(!result.Any());
        }
        [Test] 
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(5)]
        [TestCase(8)]
        public void GetProductByIdTest_GivesId_ReturnsProductWithSpecifiedId(int id)
        {
            ProductLibrary library = new ProductLibrary();
            List<Product> products = new List<Product>();

            var product = new Product { ProductId = id };
            products.Add(product);
            products.Add(new Product { ProductId = 2 });
            products.Add(new Product { ProductId = 9 });
            Product result = library.GetProductById(id, products);

            Assert.AreEqual(result.ProductId, product.ProductId);
        }
        [Test]
        [TestCase(1)]
        public void GetProductByIdTest_GivesIdToListWhichDoesntContainSpecifiedId_ReturnsNull(int id)
        {
            ProductLibrary library = new ProductLibrary();
            List<Product> products = new List<Product>();

            var product = new Product { ProductId = id };
            products.Add(product);
            Product result = library.GetProductById(id+1, products);

            Assert.AreEqual(result, null);
        }
        [TestCase(1, 100 )]
        [TestCase(3, 200)]
        [TestCase(5, 50)]
        [TestCase(8, 80)]
        public void GetProductQuantityByIdTest_GivesId_ReturnsProductQuantityForSpecifiedId(int id, int q )
        {
            ProductLibrary library = new ProductLibrary();
            List<Product> products = new List<Product>();

            var product = new Product { ProductId = id, Quantity = q};
            products.Add(product);
            products.Add(new Product { ProductId = 2, Quantity = 5});
            products.Add(new Product { ProductId = 9 , Quantity = 1});
            var result = library.GetProductQuantityById(id, products);

            Assert.AreEqual(result, product.Quantity);
        }
        [Test]
        public void GetProductQuantityByIdTest_GivesIdToListWhichDoesntContainSpecifiedId_Returns0()
        {
            ProductLibrary library = new ProductLibrary();
            List<Product> products = new List<Product>();

            var product = new Product { ProductId = 1 };
            products.Add(product);
            var result = library.GetProductQuantityById(2, products);

            Assert.AreEqual(result, 0);
        }
        [TestCase(1, 100.50)]
        [TestCase(3, 50.50)]
        [TestCase(5, 50)]
        [TestCase(8, 40)]
        public void GetProductPriceByIdTest_GivesId_ReturnsProductPriceForSpecifiedId(int id, double p)
        {
            ProductLibrary library = new ProductLibrary();
            List<Product> products = new List<Product>();

            var product = new Product { ProductId = id, Price = p };
            products.Add(product);
            var result = library.GetProductPriceById(id, products);

            Assert.AreEqual(result, product.Price);
        }
        [Test]
        public void GetProductPriceByIdTest_GivesIdToListWhichDoesntContainSpecifiedId_Returns0()
        {
            ProductLibrary library = new ProductLibrary();
            List<Product> products = new List<Product>();

            var product = new Product { ProductId = 1 };
            products.Add(product);
            var result = library.GetProductPriceById(2, products);

            Assert.AreEqual(result, 0);
        }
    }
}
