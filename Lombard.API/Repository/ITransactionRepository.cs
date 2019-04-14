using Lombard.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Lombard.API.Repository
{
    public interface ITransactionRepository
    {
        List<Transaction> GetTransactions();
        void AddTransaction(IEnumerable<ProductHistory> products, TransactionType transactionType);
        Transaction GetTransaction(int id);
        List<Transaction> GetTransactionsInMonth(int month);
    }
}
