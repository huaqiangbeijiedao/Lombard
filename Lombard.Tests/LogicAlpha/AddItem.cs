using System;
using System.Collections.Generic;
using System.Text;

namespace Lombard.Logic
{
    public class AddItem
    {
        public Items AddItemAtEnd (Items items, Item item)
        {
            items.ListOfItems.Add(item);
            return items;
        }
    }
}
