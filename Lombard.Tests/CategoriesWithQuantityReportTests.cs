using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Lombard.Logic;

namespace Lombard.Tests
{
    class CategoriesWithQuantityReportTests
    {
        [Test]
        public void GroupByNames_PopulatedList_ReturnsGroupedDictionary()
        {
            var catReport = new CategoriesWithQuantityReport();

            Items items = new Items();
           var item = new Item()
            {
                Name = "TestName",
                Quantity = 2
            };

            var item2 = new Item()
            {
                Name = "TestName",
                Quantity = 2
            };

            items.ListOfItems.Add(item);
            items.ListOfItems.Add(item2);

            var result = catReport.GroupByNames(items);

            Assert.IsTrue(result.ContainsKey("TestName"));
            Assert.IsTrue(result["TestName"] == 4);
        }

        [Test]
        public void GroupByNames_EmptyList_ReturnsEmptyDictionary()
        {
            var catReport = new CategoriesWithQuantityReport();

        }


        [Test]
        public void GroupByQuantity_PopulatedList_ReturnsGroupedDictionary()
        {
            var catReport = new CategoriesWithQuantityReport();

        }

        [Test]
        public void GroupByQuantity_EmptyList_ReturnsEmptyDictionary()
        {

        }
    }
}
