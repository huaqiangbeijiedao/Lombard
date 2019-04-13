using Lombard.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lombard.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts()
        {
            var products = _context.Products.ToList();
            return products;
        }

        public void AddProducts(IEnumerable<Product> products)
        {
            foreach (var i in products)
            {
                _context.Products.Add(i);
            }
            _context.SaveChanges();
        }
        
    }
}
