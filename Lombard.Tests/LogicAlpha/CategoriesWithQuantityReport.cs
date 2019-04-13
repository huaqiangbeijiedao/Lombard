using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Lombard.Logic
{
    public class CategoriesWithQuantityReport
    {
        public Dictionary<string, double> GroupByNames(Items itemsToGroup)
        {
            Dictionary<string, double> itemsGrouped = new Dictionary<string, double>();
            foreach (Item item in itemsToGroup.ListOfItems)
            {
                if(itemsGrouped.ContainsKey(item.Name))
                {
                    itemsGrouped[item.Name] += item.Quantity;
                }
                else
                {
                    itemsGrouped.Add(item.Name, item.Quantity);
                }
            }

            return itemsGrouped;
        }
    }
}
