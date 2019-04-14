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
                var egsists = _context.Products.Find(i.Id);
                if (egsists == null)
                    _context.Products.Add(i);
                else
                    egsists.Quantity += i.Quantity;
            }
            _context.SaveChanges();
        }

        public void RemoveProducts(IEnumerable<Product> products)
        {
            foreach (Product product in products)
            {
                var dbProduct = _context.Products.Find(product.Id);

                if (product.Quantity - dbProduct.Quantity == 0)
                {
                    _context.Products.Remove(dbProduct);
                }
                else if (product.Quantity - dbProduct.Quantity < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    dbProduct.Quantity -= product.Quantity;
                }

                _context.SaveChanges();
            }
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            var productToUpdate = _context.Products.Find(product.Id);
            productToUpdate.Quantity = product.Quantity;
            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;

            _context.SaveChanges();
        }

        public Product SearchForProductById(int productId)
        {
            return _context.Products.Find(productId);
        }

        public List<Product> SerachForProductsByName(string productName)
        {
            return _context.Products.Where(p => p.Name.Contains(productName)).ToList();
        }
    }
}
