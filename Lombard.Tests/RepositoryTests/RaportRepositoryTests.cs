using Lombard.API;
using Lombard.API.Models;
using Lombard.API.Repository;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lombard.Tests.RepositoryTests
{
    class RaportRepositoryTests
    {
        private IRaportRepository _repo;
        private DataContext _context;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase("DefaultConnection")
                .Options;

            _context = new DataContext(options);
            _repo = new RaportRepository(_context);
            Seed(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
        }
        [Test]
        public void CheckProductsOutage_LowQuantity_ReturnsOneProduct()
        {
            List<Product> actual =  new List<Product>(_repo.CheckProductsOutage(20));
            Assert.IsTrue(actual.Count==1);
        }

        [Test]
        public void CheckProductsOutage_EmptyContext_Returns()
        {
            _context.Database.EnsureDeleted();
            List<Product> actual = new List<Product>(_repo.CheckProductsOutage(20000));
            Assert.IsTrue(actual.Count == 0);
        }

        [Test]
        public void CheckProductsOutage_HighQuantity_ReturnsAllProduct()
        {
            List<Product> actual = new List<Product>(_repo.CheckProductsOutage(20000000));
            Assert.IsTrue(actual.Count == 4);
        }

        [Test]
        public void GetProductQuantityById_ID_ReturnsQuantity()
        {
            var actual = _repo.GetProductQuantityById(3);
            Assert.IsTrue(actual == 100);
        }
        [Test]
        public void GetProductQuantityById_BADID_ReturnsQuantity()
        {
            var actual = _repo.GetProductQuantityById(666);
            Assert.IsTrue(actual == 0);
        }


        [Test]
        public void GetProductPriceById_ID_ReturnsPrice()
        {
            var actual = _repo.GetProductPriceById(4);
            Assert.IsTrue(actual == 1.0);
        }

        [Test]
        public void GetProductPriceById_BADID_ReturnsPrice()
        {
            var actual = _repo.GetProductPriceById(4324);
            Assert.IsTrue(actual == 0);
        }

        [Test]
        public void GetTotalTurnover__ReturnsTurnover()
        {
            
            var actual = _repo.GetTotalTurnover();
            Assert.IsTrue(actual == 1675);
        }

        [Test]
        public void GetTotalTurnover_EMPTYCONTEXT_ReturnsTurnover()
        {
            _context.Database.EnsureDeleted();
            var actual = _repo.GetTotalTurnover();
            Assert.IsTrue(actual == 0);
        }

        [Test]
        public void GetProfit__ReturnsProfit()
        {
            var actual = _repo.GetProfit();
            Assert.IsTrue(actual == 1327.5);
        }
        [Test]
        public void GetProfit_EMPTYCONTEXT_ReturnsProfit()
        {
            _context.Database.EnsureDeleted();
            var actual = _repo.GetProfit();
            Assert.IsTrue(actual == 0);
        }

        [Test]
        public void GetTransactionsByType_Bought_ReturnsOneTransaction()
        {
            List<Transaction> actual = new List<Transaction>(_repo.GetTransactionsByType(TransactionType.Bought));
            Assert.IsTrue(actual.Count == 1);
        }

        [Test]
        public void GetTransactionsByType_BADTYPE_ReturnsOneTransaction()
        {

            Assert.Throws<System.InvalidOperationException>(() => _repo.GetTransactionsByType(TransactionType.Bought+3));
        }

        protected void Seed(DataContext context)
        {
            var a = new List<Product> {
             new Product { Id = 1, Name = "Opona", Quantity = 30, Price = 10.00 },
             new Product { Id = 2, Name = "Felga", Quantity = 5, Price = 50.00 },
             new Product { Id = 3, Name = "Klucz", Quantity = 100, Price = 3.00 },
             new Product { Id = 4, Name = "Sruba", Quantity = 500, Price = 1.00 }
            };



            var b = new List<ProductHistory>
            {
             new ProductHistory { Id = 1, Name = "Opona", Price = 10, Quantity = 35, TransactionId = 1 },
             new ProductHistory { Id = 2, Name = "Felga", Price = 50, Quantity = 10, TransactionId = 1 },
             new ProductHistory { Id = 3, Name = "Klucz", Price = 3, Quantity = 105, TransactionId = 1 },
             new ProductHistory { Id = 4, Name = "Sruba", Price = 1, Quantity = 510, TransactionId = 1 },
            };
            var c = new List<ProductHistory>
            {
             new ProductHistory { Id = 5, Name = "Opona", Price = 12, Quantity = 5, TransactionId = 2 },
             new ProductHistory { Id = 6, Name = "Felga", Price = 51, Quantity = 5, TransactionId = 2 },
             new ProductHistory { Id = 7, Name = "Klucz", Price = 4, Quantity = 5, TransactionId = 2 },
             new ProductHistory { Id = 8, Name = "Sruba", Price = 1.25, Quantity = 10, TransactionId = 2 }
             };

            var d = new List<Transaction>
            {
             new Transaction { Id = 1, TransactionDate = new DateTime(2019, 4, 13), TransactionType = TransactionType.Bought, ProductHistory = b },
             new Transaction { Id = 2, TransactionDate = new DateTime(2019, 4, 14), TransactionType = TransactionType.Sold, ProductHistory = c  }
             };
            context.Products.AddRange(a);
            context.Transactions.AddRange(d);
            context.ProductsHistory.AddRange(b);
            context.ProductsHistory.AddRange(c);
            _context.SaveChanges();
        }

    }
}
