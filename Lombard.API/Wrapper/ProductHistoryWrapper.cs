using Lombard.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lombard.API.Wrapper
{
    public class ProductWrapper
    {
        public static List<ProductHistory> productHistories(IEnumerable<Product> products)
        {
            var productsHistory = new List<ProductHistory>();
            foreach (var product in products)
            {
                productsHistory.Add(new ProductHistory(product));
            }
            return productsHistory;
        }
    }
}
