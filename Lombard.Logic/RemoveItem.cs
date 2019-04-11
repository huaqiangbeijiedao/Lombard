using System;
using System.Collections.Generic;
using System.Text;

namespace Lombard.Logic
{
    public class RemoveItem
    {
        public Items RemoveFirstOccurenceFromItem(Items items, Item remove)
        {
            items.ListOfItems.Remove(remove);
            return items;
        }
    }
}
