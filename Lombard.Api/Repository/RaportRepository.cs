using Lombard.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lombard.API.Repository
{
    public class RaportRepository : IRaportRepository
    {
        private readonly DataContext _context;

        public RaportRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> CheckProductsOutage(int quant)
        {
            //Może dodać parametr zamiast 10?
            // Jest i parametr :) 
            var contextProducts = _context.Products.ToList();
            return contextProducts.Where(p => p.Quantity < quant);
        }
        public int GetProductQuantityById(int id)
        {
            var contextProducts = _context.Products.ToList();
            if (!contextProducts.Any(p => p.Id == id))
                return 0;
            return contextProducts.SingleOrDefault(p => p.Id == id).Quantity;
        }
        public double GetProductPriceById(int id)
        {
            var contextProducts = _context.Products.ToList();
            if (!contextProducts.Any(p => p.Id == id))
                return 0;
            return contextProducts.SingleOrDefault(p => p.Id == id).Price;
        }
        public double GetTotalTurnover()
        {
            var contextTransactions = _context.Transactions;
            var bought = contextTransactions.Where(t => t.TransactionType == TransactionType.Bought);
            var productHistory = bought.SelectMany(t => t.ProductHistory);
            return productHistory.Sum(p => p.Price * p.Quantity);
        }
        public double GetProfit()
        {
            var contextTransactions = _context.Transactions;
            var transactionsBought = contextTransactions.Where(t => t.TransactionType == TransactionType.Bought);
            var transactionsSold = contextTransactions.Where(t => t.TransactionType == TransactionType.Sold);
            double totalPriceBought = transactionsBought.SelectMany(t => t.ProductHistory).Sum(p => p.Price * p.Quantity);
            double totalPriceSold = transactionsSold.SelectMany(t => t.ProductHistory).Sum(p => p.Price * p.Quantity);
            return totalPriceBought - totalPriceSold;
        }
        public IEnumerable<Transaction> GetTransactionsByType(TransactionType transactionType)
        {
            var contextTransactions = _context.Transactions.Include(prodHistory => prodHistory.ProductHistory);
            switch (transactionType)
            {
                case TransactionType.Bought:
                    return contextTransactions.Where(t => t.TransactionType == TransactionType.Bought);

                case TransactionType.Sold:
                    return contextTransactions.Where(t => t.TransactionType == TransactionType.Sold);

                default:
                    //TODO
                    throw new Exception();
            }
        }
    }
}
