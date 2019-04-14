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
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("GetProducts")]
        public IActionResult GetProducts()
        {
            var products = _repo.GetProducts();
            return Ok(products);
        }

        [HttpPost]
        [Route("RemoveProducts")]
        public IActionResult RemoveProducts([FromBody] IEnumerable<Product> products)
        {
            _repo.RemoveProducts(products);
            return Ok();
        }

        [HttpGet]
        [Route("SearchById/{id}")]
        public IActionResult SearchProductById(int id)
        {
            var product = _repo.SearchForProductById(id);
            return Ok(product);
        }

        [HttpDelete]
        [Route("DeleteById/{id}")]
        public IActionResult DeleteProductById(int id)
        {
            _repo.DeleteProduct(id);
            return Ok();
        }

        [HttpGet]
        [Route("SearchByName/{name}")]
        public IActionResult SearchProductsByName(string name)
        {
            var products = _repo.SerachForProductsByName(name);
            return Ok(products);
        }
    }
}