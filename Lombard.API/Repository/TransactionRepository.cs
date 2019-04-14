using Lombard.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lombard.API.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DataContext _context;

        public TransactionRepository(DataContext context)
        {
            _context = context;
        }

        public List<Transaction> GetTransactions()
        {
            var transactions = _context.Transactions.Include(prodHistory => prodHistory.ProductHistory).ToList();
            return transactions;
        }

        public Transaction AddTransaction(IEnumerable<ProductHistory> products, TransactionType transactionType)
        {
            var newTransaction = new Transaction
            {
                TransactionType = transactionType,
                TransactionDate = DateTime.Now,
                ProductHistory = products.ToList()
            };
            _context.Transactions.Add(newTransaction);
            _context.SaveChanges();
            return newTransaction;

        }
        public Transaction GetTransaction(int id)
        {
            return _context.Transactions.Include(p => p.ProductHistory).SingleOrDefault(t => t.Id == id);
        }
        public List<Transaction> GetTransactionsInMonth(int month)
        {
            return _context.Transactions.Include(p => p.ProductHistory).Where(t => t.TransactionDate.Month == month).ToList();
        }



        public bool UpdateTransaction(Transaction transaction)
        {
            var TransToUpdate = _context.Transactions.Find(transaction.Id);
            TransToUpdate.ProductHistory = transaction.ProductHistory;
            TransToUpdate.TransactionDate = transaction.TransactionDate; //tego nie jestem pewny
            if (TransToUpdate.TransactionType != transaction.TransactionType)
            {
                TransToUpdate.TransactionType = transaction.TransactionType;
                _context.SaveChanges();
                return true;
            }
            _context.SaveChanges();
            return false;
        }
        public Transaction RemoveTransaction()
        { 
            if (_context.Transactions.Count()>1)
            _context.Transactions.Remove(_context.Transactions.Last());
            _context.SaveChanges();
            return _context.Transactions.Last();
        }
        public Transaction GetLast()
        {
            return _context.Transactions.Include(prodHistory => prodHistory.ProductHistory).Last();
        }
    }
}
