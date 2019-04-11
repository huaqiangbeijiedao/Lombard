using System;
using System.Collections.Generic;
using System.Text;

namespace Lombard.Logic
{
    public class Items
    {
        public Items()
        {
            ListOfItems = new List<Item>();
        }
            
        public List<Item> ListOfItems { get; set; }
    }
}
