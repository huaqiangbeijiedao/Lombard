using System;
using System.Collections.Generic;

namespace Lombard.API.Models
{
    public class Transaction
    {
        public int Id { get; set; }
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
