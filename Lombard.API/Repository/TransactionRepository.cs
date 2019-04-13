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
    }
}
