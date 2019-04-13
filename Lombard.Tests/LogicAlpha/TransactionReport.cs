using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Lombard.Logic
{
    public static class TransactionReport
    {
        public static double TotalTradingReport(IEnumerable<Item> bought, IEnumerable<Item> sold)
        {
            var result = bought.Sum(i => i.Price * i.Quantity) + sold.Sum(i => i.Price * i.Quantity);
            return result;
        }
    }
}
