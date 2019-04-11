using Lombard.Logic;
using NUnit.Framework;
using System.Collections.Generic;

using Lombard.Logic;
namespace Tests
{
    public class Tests
    {
       
        [Test]  
        public void WareHouseQuantity_ItemsList_CorrectQuantity()
        {
            var listOfItems = new List<Item>
            {
                new Item {ProductId = 1,Price = 5.00, Quantity = 1},
                new Item {ProductId = 2,Price = 25.00, Quantity = 2},
                new Item {ProductId = 3,Price = 6.00, Quantity = 5}
            };
            var itemsCount = Item.WareHouseQuantity(listOfItems);
            Assert.AreEqual(8,itemsCount);
        }
        [Test]
        public void ProfitReport_TwoValues_Output()
        {
            double price1 = 100;
            double price2 = 300;
            var c = new ProfitReport();
            Assert.AreEqual(200, c.GenerateProfitReport(price1, price2));
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
            var result = TransactionReport.TotalTradingReport(bought, sold);
            Assert.AreEqual(result, 5500);
        }

        [Test]
        public void AddItem_ListAndItem_List()
        {
            var lista = new Items();
        }
        [Test]
        [TestCase(5.0, 8, 40)]
        [TestCase(8.0, 10, 80)]
        [TestCase(0.0, 10, 0)]
        public void GetTotalPrice_Item_ReturnsQuantityMultiPrice(double x, int y, double effect)
        {
            var item = new Item { Price = x, Quantity = y };

            Assert.AreEqual(effect, item.GetTotalPrice());
        }
        [Test]
        public void GetPriceOfAllProducts_ListOfItems_ReturnsQuantityMultiPrice()
        {
            var items = new Items();
            items.ListOfItems.Add(new Item { Price = 5.00, Quantity = 100 });
            items.ListOfItems.Add(new Item { Price = 3.00, Quantity = 50 });
            items.ListOfItems.Add(new Item { Price = 10.00, Quantity = 120 });

            var result = items.GetPriceOfAllProducts();
            Assert.AreEqual(1850, result);
        }
        [Test]
        public void GetPriceOfAllProducts_ListOfItems_ReturnsQuantityMultiPriceV2()
        {
            var items = new Items();
            items.ListOfItems.Add(new Item { Price = 1.50, Quantity = 2 });
            items.ListOfItems.Add(new Item { Price = 1.00, Quantity = 10 });
            items.ListOfItems.Add(new Item { Price = 0.00, Quantity = 120 });

            var result = items.GetPriceOfAllProducts();
            Assert.AreEqual(13, result);
        }

    }
}