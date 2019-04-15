using Lombard.API;
using Lombard.API.Models;
using Lombard.API.Repository;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lombard.Tests.RepositoryTests
{
    class TransactionRepositoryTests
    {
        private ITransactionRepository _repo;
        private DataContext _context;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase("DefaultConnection")
                .Options;

            _context = new DataContext(options);
            _repo = new TransactionRepository(_context);
            Seed(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
        }


        [Test]
        public void GetTransactions_NOthing_AllTransactions()
        {
            var expected = _repo.GetTransactions();
            Assert.IsTrue(expected.Count == 2);
        }

        [Test]
        public void GetTransatcion_ID_Transaction()
        {
            var expected = _repo.GetTransaction(1);
            Assert.AreEqual(expected, mocktrans.Find(a=>a.Id==1));
        }


        [Test]
        public void AddTransaction_productsAndType_Transaction()
        {
            var c = new List<ProductHistory>
            {
             new ProductHistory { Id = 9, Name = "fef", Price = 12, Quantity = 5, TransactionId = 3 },
             new ProductHistory { Id = 10, Name = "Fsdga", Price = 51, Quantity = 5, TransactionId = 3 },
             new ProductHistory { Id = 11, Name = "Kadwcz", Price = 4, Quantity = 5, TransactionId = 3 },
             new ProductHistory { Id = 12, Name = "Srsfgba", Price = 1.25, Quantity = 10, TransactionId = 3 }
             };
            var expected = _repo.AddTransaction(c, TransactionType.Bought);
            Assert.IsTrue(_context.Transactions.Count() == 3);
        }

        [Test]
        public void GetTransactionsInMonth_month_LisTransatcion()
        {
            var expected = _repo.GetTransactionsInMonth(4);
            Assert.IsTrue(expected.Count == 2);
        }

        [Test]
        public void RemoveTransaction_Transaction_TRansaction()
        {
            var expected = _repo.RemoveLastTransaction();
            Assert.IsTrue(_context.Transactions.Count() == 1);
        }


        private List<Transaction> mocktrans;
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

            mocktrans = new List<Transaction>
            {
             new Transaction { Id = 3, TransactionDate = new DateTime(2019, 4, 13), TransactionType = TransactionType.Bought, ProductHistory = b },
             new Transaction { Id = 4, TransactionDate = new DateTime(2019, 4, 14), TransactionType = TransactionType.Sold, ProductHistory = c  }
             };
            context.Products.AddRange(a);
            context.Transactions.AddRange(mocktrans);
            context.ProductsHistory.AddRange(b);
            context.ProductsHistory.AddRange(c);
            _context.SaveChanges();
        }
    }
}
