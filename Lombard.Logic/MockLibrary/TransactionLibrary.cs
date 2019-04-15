using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lombard.API.Models;

namespace Lombard.Logic
{
    public class TransactionLibrary
    {
        public IEnumerable<Transaction> GetAllTransactions(IQueryable<Transaction> contextTransactions)
        {
            return contextTransactions.ToList();
        }

        public double GetTotalTurnover(IQueryable<Transaction> contextTransactions)
        {
            var productHistory = contextTransactions.SelectMany(t => t.ProductHistory);
            return productHistory.Sum(p => p.Price);
        }

        public double GetProfit(IQueryable<Transaction> contextTransactions)
        {
            var transactionsBought = contextTransactions.Where(t => t.TransactionType == TransactionType.Bought);
            var transactionsSold = contextTransactions.Where(t => t.TransactionType == TransactionType.Sold);

            double totalPriceBought = transactionsBought.SelectMany(t => t.ProductHistory).Sum(p => p.Price);
            double totalPriceSold = transactionsSold.SelectMany(t => t.ProductHistory).Sum(p => p.Price);

            return totalPriceBought - totalPriceSold;
        }

        public IEnumerable<Transaction> GetTransactionsByType(IQueryable<Transaction> contexTransactions, TransactionType transactionType)
        {
            switch (transactionType)
            {
                case TransactionType.Bought:
                    return contexTransactions.Where(t => t.TransactionType == TransactionType.Bought);

                case TransactionType.Sold:
                    return contexTransactions.Where(t => t.TransactionType == TransactionType.Sold);

                default:
                    //TODO
                    throw new Exception();
            }
        }
    }
}
