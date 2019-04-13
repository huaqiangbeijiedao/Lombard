using Lombard.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lombard.API
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<ProductHistory> ProductsHistory { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Transaction>()
           .HasMany(c => c.ProductHistory)
           .WithOne(e => e.Transaction);

            builder.Entity<Product>().HasData(
             new Product { Id = 1, Name = "Opona", Quantity = 30, Price = 10.00},
             new Product { Id = 2, Name = "Felga", Quantity = 5, Price = 50.00},
             new Product { Id = 3, Name = "Klucz", Quantity = 100, Price = 3.00},
             new Product { Id = 4, Name = "Sruba", Quantity = 500, Price = 1.00}
            );

            builder.Entity<Transaction>().HasData(
             new Transaction { Id = 1, TransactionDate = new DateTime(2019, 4, 13), TransactionType = TransactionType.Bought },
             new Transaction { Id = 2, TransactionDate = new DateTime(2019, 4, 14), TransactionType = TransactionType.Sold }
             );

            builder.Entity<ProductHistory>().HasData(
             new ProductHistory { Id = 1, Name = "Opona", Price = 10, Quantity = 35, TransactionId = 1 },
             new ProductHistory { Id = 2, Name = "Felga", Price = 50, Quantity = 10, TransactionId = 1 },
             new ProductHistory { Id = 3, Name = "Klucz", Price = 3, Quantity = 105, TransactionId = 1 },
             new ProductHistory { Id = 4, Name = "Sruba", Price = 1, Quantity = 510, TransactionId = 1 },

             new ProductHistory { Id = 5, Name = "Opona", Price = 12, Quantity = 5, TransactionId = 2 },
             new ProductHistory { Id = 6, Name = "Felga", Price = 51, Quantity = 5, TransactionId = 2 },
             new ProductHistory { Id = 7, Name = "Klucz", Price = 4, Quantity = 5, TransactionId = 2 },
             new ProductHistory { Id = 8, Name = "Sruba", Price = 1.25, Quantity = 10, TransactionId = 2 }
             );

         

           
        }
    }
}
