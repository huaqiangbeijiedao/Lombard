using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lombard.Logic
{
    public class Items
    {
        public List<Item> ListOfItems { get; set; }

        public Items()
        {
            ListOfItems = new List<Item>();
        }
        public double GetPriceOfAllProducts()
        {
            return ListOfItems.Sum(i=>i.GetTotalPrice());
        }
    }
}
