using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lombard.API.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public List<ProductHistory> ProductHistory { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionType TransactionType { get; set; }
    }

    public enum TransactionType
    {
        Bought,
        Sold
    }
}
