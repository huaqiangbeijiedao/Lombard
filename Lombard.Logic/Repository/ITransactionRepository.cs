using Lombard.API.Models;
using System.Collections.Generic;


namespace Lombard.API.Repository
{
    public interface ITransactionRepository
    {
        List<Transaction> GetTransactions();
        Transaction AddTransaction(IEnumerable<ProductHistory> products, TransactionType transactionType);
        Transaction GetTransaction(int id);
        List<Transaction> GetTransactionsInMonth(int month);
        Transaction RemoveLastTransaction();
        Transaction GetLast();
    }
}
