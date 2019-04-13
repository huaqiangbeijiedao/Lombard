using System;
using System.Collections.Generic;
using System.Linq;
using Lombard.API.Models;
using Lombard.Logic;
using NUnit.Framework;


namespace Lombard.Tests.LibraryTests
{
    [TestFixture]
    class TransactionLibraryTests
    {
        [Test]
        public void GetAllProducts_PopulatedList_ReturnsPopulatedList()
        {
            TransactionLibrary library = new TransactionLibrary();
            List<Transaction> transactions = new List<Transaction>();
            transactions.Add(new Transaction()
            {
                TransactionId = 1
            });
            transactions.Add(new Transaction()
            {
                TransactionId = 2
            });

            IEnumerable<Transaction> result = library.GetAllTransactions(new EnumerableQuery<Transaction>(transactions));

            Assert.IsTrue(result.Count() == 2);
            Assert.IsTrue(result.Any(p => p.TransactionId == 1));
            Assert.IsTrue(result.Any(p => p.TransactionId == 2));
        }

        [Test]
        public void GetAllProducts_EmptyProductList_ReturnsEmptyList()
        {
            TransactionLibrary library = new TransactionLibrary();
            List<Transaction> transactions = new List<Transaction>();

            IEnumerable<Transaction> result = library.GetAllTransactions(new EnumerableQuery<Transaction>(transactions));

            Assert.IsTrue(!result.Any());
        }

        [Test]
        public void GetTotalTurnover_PositiveInts_ReturnsProperValue()
        {
            TransactionLibrary library = new TransactionLibrary();
            List<Transaction> transactions = new List<Transaction>();
            transactions.Add(new Transaction()
            {
                TransactionId = 1,
                ProductHistory = new List<ProductHistory>()
                {
                    new ProductHistory()
                    {
                        Price = 1
                    },
                    new ProductHistory()
                    {
                        Price = 3
                    }
                }
            });
            transactions.Add(new Transaction()
            {
                TransactionId = 2,
                ProductHistory = new List<ProductHistory>()
                {
                    new ProductHistory()
                    {
                        Price = 2.50
                    }
                }
            });

            var result = library.GetTotalTurnover(new EnumerableQuery<Transaction>(transactions));

            Assert.IsTrue(result > 6.49 && result < 6.51);
        }

        [Test]
        public void GetTotalTurnover_NegativeInts_ReturnsProperValue()
        {
            TransactionLibrary library = new TransactionLibrary();
            List<Transaction> transactions = new List<Transaction>();
            transactions.Add(new Transaction()
            {
                TransactionId = 1,
                ProductHistory = new List<ProductHistory>()
                {
                    new ProductHistory()
                    {
                        Price = -1
                    },
                    new ProductHistory()
                    {
                        Price = -3
                    }
                }
            });
            transactions.Add(new Transaction()
            {
                TransactionId = 2,
                ProductHistory = new List<ProductHistory>()
                {
                    new ProductHistory()
                    {
                        Price = -2.50
                    }
                }
            });

            var result = library.GetTotalTurnover(new EnumerableQuery<Transaction>(transactions));

            Assert.IsTrue(result < -6.49 && result > -6.51);
        }

        [Test]
        public void GetProfit_MixedTransactions_ReturnsProperValue()
        {
            TransactionLibrary library = new TransactionLibrary();
            List<Transaction> transactions = new List<Transaction>();
            transactions.Add(new Transaction()
            {
                TransactionId = 1,
                ProductHistory = new List<ProductHistory>()
                {
                    new ProductHistory()
                    {
                        Price = 1
                    },
                    new ProductHistory()
                    {
                        Price = 2
                    }
                },
                TransactionType = TransactionType.Sold          
            });
            transactions.Add(new Transaction()
            {
                TransactionId = 2,
                ProductHistory = new List<ProductHistory>()
                {
                    new ProductHistory()
                    {
                        Price = 2.50
                    }
                },

                TransactionType = TransactionType.Bought
            });

            var result = library.GetProfit(new EnumerableQuery<Transaction>(transactions));

            Assert.IsTrue(result < -0.49 && result > -0.51);
        }

        [Test]
        public void GetTransactionByType_SoldType_ReturnsSoldType()
        {
            TransactionLibrary library = new TransactionLibrary();
            List<Transaction> transactions = new List<Transaction>();
            transactions.Add(new Transaction()
            {
                TransactionId = 1,
                ProductHistory = new List<ProductHistory>()
                {
                    new ProductHistory()
                    {
                        Price = 1
                    },
                    new ProductHistory()
                    {
                        Price = 2
                    }
                },
                TransactionType = TransactionType.Sold
            });
            transactions.Add(new Transaction()
            {
                TransactionId = 2,
                ProductHistory = new List<ProductHistory>()
                {
                    new ProductHistory()
                    {
                        Price = 2.50
                    }
                },

                TransactionType = TransactionType.Bought
            });

            var result = library.GetTransactionsByType(new EnumerableQuery<Transaction>(transactions), TransactionType.Sold);

            Assert.IsTrue(result.All(t => t.ProductHistory.Count == 2));
            Assert.IsTrue(result.All(t => t.TransactionId == 1));
        }

        [Test]
        public void GetTransactionByType_BoughtType_ReturnsBoughtType()
        {
            TransactionLibrary library = new TransactionLibrary();
            List<Transaction> transactions = new List<Transaction>();
            transactions.Add(new Transaction()
            {
                TransactionId = 1,
                ProductHistory = new List<ProductHistory>()
                {
                    new ProductHistory()
                    {
                        Price = 1
                    },
                    new ProductHistory()
                    {
                        Price = 2
                    }
                },
                TransactionType = TransactionType.Sold
            });
            transactions.Add(new Transaction()
            {
                TransactionId = 2,
                ProductHistory = new List<ProductHistory>()
                {
                    new ProductHistory()
                    {
                        Price = 2.50
                    }
                },

                TransactionType = TransactionType.Bought
            });

            var result = library.GetTransactionsByType(new EnumerableQuery<Transaction>(transactions), TransactionType.Bought);

            Assert.IsTrue(result.All(t => t.ProductHistory.Count == 1));
            Assert.IsTrue(result.All(t => t.TransactionId == 2));
        }
    }
}
