using System;
using System.Collections.Generic;
using System.Text;

namespace Lombard.Logic
{
    public class Item
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        static public int WareHouseQuantity(IEnumerable<Item> items)
        {
            int quantinty = 0;
            foreach(var i in items)
            {
                quantinty += i.Quantity; 
            }
            return quantinty;
        }
    }
}
