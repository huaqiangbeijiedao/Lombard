using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lombard.API.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public List<Product> Products { get; set; }
        public DateTime TransactionDate { get; set; } 
    }
}
