using System;
using System.Collections.Generic;
using System.Text;

namespace Lombard.Logic
{
    public class RemoveItem
    {
        public Items RemoveFirstOccurenceFromItem(Items items, Item remove)
        {
            if (items.ListOfItems.Count==0)
            {
                return items;
            }
            items.ListOfItems.Remove(remove);
            return items;
        }
    }
}
