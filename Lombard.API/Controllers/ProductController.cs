using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lombard.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lombard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _repo.GetProducts();
            return Ok(products);
        }
    }
}