﻿using Lombard.API.Models;
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
