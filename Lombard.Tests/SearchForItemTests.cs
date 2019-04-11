using Lombard.Logic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lombard.Tests
{
    class SearchForItemTests
    {
        [Test]
        public void SearchForItem_ExistingItem_FindsItem()
        {
            Items items = new Items();
            SearchForItem searchForItem = new SearchForItem();

            Item item = new Item()
            {
                Name = "Test"
            };
            

        }

        [Test]
        public void SearchForItem_EmptyItem_DoesntFindItem()
        {
            Items items = new Items();
        }
    }
}
