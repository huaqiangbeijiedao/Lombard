using Lombard.Logic;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void TransationTest_boughtAndSoldItems_ReturnSum()
        {
            var bought = new List<Item>
            {
                new Item {Price = 5.00, Quantity = 100},
                new Item {Price = 3.00, Quantity = 50},
                new Item {Price = 10.00, Quantity = 120},
            };
            var sold = new List<Item>
            {
                new Item {Price = 10.00, Quantity = 100},
                new Item {Price = 5.00, Quantity = 50},
                new Item {Price = 20.00, Quantity = 120},
            };


            var result = TransactionReport.TotalReport(bought, sold);
            Assert.AreEqual(result, 5500);
        }

    }
}