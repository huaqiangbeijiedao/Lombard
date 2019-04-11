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
        public void AddItem_ListAndItem_List()
        {
            var lista = new Items();

        }
    }
}