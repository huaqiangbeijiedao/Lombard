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
        Transaction AddTransaction(IEnumerable<ProductHistory> products, TransactionType transactionType);
        Transaction GetTransaction(int id);
        List<Transaction> GetTransactionsInMonth(int month);
        Transaction RemoveTransaction();
        Transaction GetLast();
    }
}
