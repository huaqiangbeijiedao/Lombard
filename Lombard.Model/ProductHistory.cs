using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lombard.Model
{
    public class ProductHistory
    {
        public int ProductHistoryId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; } 
    }
}
