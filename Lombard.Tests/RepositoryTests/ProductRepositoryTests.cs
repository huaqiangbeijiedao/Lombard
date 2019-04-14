using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lombard.API;
using Lombard.API.Models;
using Lombard.API.Repository;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Lombard.Tests.RepositoryTests
{
    [TestFixture]
    class ProductRepositoryTests
    {
        private IProductRepository _repo;
        private DataContext _context;

        [SetUp]
        public void SetUp()
        {                
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase("DefaultConnection")
                .Options;

            _context = new DataContext(options);
            _repo = new ProductRepository(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
        }

        [Test]
        public void AddProduct_SingleProduct_AddsProductToContext()
        {
            Product testProduct = new Product()
            {
                Id = 1,
                Name = "Test"
            };

            List<Product> list = new List<Product>();
            list.Add(testProduct);

            _repo.AddProducts(list);

            Assert.Contains(testProduct, _context.Products.ToList());
        }

        [Test]
        public void RemoveProduct_SingleProduct_RemovesProductFromContext()
        {
            Product testProduct = new Product()
            {
                Id = 1,
                Name = "Test"
            };
            _context.Products.Add(testProduct);
            _context.SaveChanges();

            List<Product> list = new List<Product>();
            list.Add(testProduct);


            _repo.RemoveProducts(list);

            Assert.IsEmpty(_context.Products.ToList());
        }

        [Test]
        public void SearchForProductById_SingleProduct_ReturnsProduct()
        {
            Product testProduct = new Product()
            {
                Id = 1,
                Name = "Test"
            };
            _context.Products.Add(testProduct);
            _context.SaveChanges();

            var result = _repo.SearchForProductById(1);

            Assert.IsTrue(result.Id == 1 && result.Name == "Test");
        }

        [Test]
        public void SearchForProductsByName_SeveralProducts_ReturnsProducts()
        {
            Product testProduct1 = new Product()
            {
                Id = 1,
                Name = "Test"
            };
            Product testProduct2 = new Product()
            {
                Id = 2,
                Name = "Test"
            };
            Product testProduct3 = new Product()
            {
                Id = 3,
                Name = "Different"
            };

            _context.Products.Add(testProduct1);
            _context.Products.Add(testProduct2);
            _context.Products.Add(testProduct3);
            _context.SaveChanges();

            var result = _repo.SerachForProductsByName("Test");

            Assert.Contains(testProduct1, _context.Products.ToList());
            Assert.Contains(testProduct2, _context.Products.ToList());
            Assert.IsFalse(result.Contains(testProduct3));
        }

    }
}
