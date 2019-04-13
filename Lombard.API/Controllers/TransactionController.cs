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
        public IActionResult BuyProducts(List<Product> product)
        {
            _transactionRepository.AddTransaction(product);
        }

    }
}