using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lombard.API.Models;

namespace Lombard.Logic
{
    public class ProductLibrary
    {
        public IEnumerable<Product> GetAllProducts(IQueryable<Product> contextProducts)
        {
            return contextProducts.ToList();
        }

        public IEnumerable<Product> CheckProductsOutage(IQueryable<Product> contextProducts)
        {
            //Może dodać parametr zamiast 10?
            return contextProducts.Where(p => p.Quantity < 10);
        }
    }
}
