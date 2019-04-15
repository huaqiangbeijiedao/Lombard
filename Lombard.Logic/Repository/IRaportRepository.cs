using Lombard.API.Models;
using System.Collections.Generic;

namespace Lombard.API.Repository
{
    public interface IRaportRepository
    {
        IEnumerable<Product> CheckProductsOutage(int quant);
        int GetProductQuantityById(int id);
        double GetProductPriceById(int id);
        double GetTotalTurnover();
        double GetProfit();
        IEnumerable<Transaction> GetTransactionsByType(TransactionType transactionType);

    }
}
