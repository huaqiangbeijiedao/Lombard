using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lombard.API.Models;
using Lombard.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lombard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IProductRepository _productRepository;

        public TransactionController(ITransactionRepository transactionRepository, IProductRepository productRepository)
        {
            _transactionRepository = transactionRepository;
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetTransactions()
        {
            var transaction = _transactionRepository.GetTransactions();
            return Ok(transaction);
        }

        [HttpPost]
        [Route("BuyProducts")]
        public IActionResult BuyProducts([FromBody] List<Product> products)
        {
            _transactionRepository.AddTransaction(productHistories(products), TransactionType.Bought);
            _productRepository.AddProducts(products);
            return Ok();
        }
        [HttpPost]
        [Route("SellProducts")]
        public IActionResult SellProducts([FromBody] List<Product> products)
        {
            _transactionRepository.AddTransaction(productHistories(products), TransactionType.Sold);
            _productRepository.AddProducts(products);
            return Ok();
        }


        private List<ProductHistory> productHistories(IEnumerable<Product> products)
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