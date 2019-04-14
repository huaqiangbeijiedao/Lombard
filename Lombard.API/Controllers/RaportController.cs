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
    public class RaportController : ControllerBase
    {
        private readonly IRaportRepository _raportReporisotry;

        public RaportController(IRaportRepository raportRepository)
        {
            _raportReporisotry = raportRepository;
        }
        [HttpGet]
        [Route("Outage")]
        public IActionResult ProductsOutage([FromBody] int quant)
        {
            var sth = _raportReporisotry.CheckProductsOutage(quant);
            return Ok(sth);
        }
        [HttpGet]
        [Route("QuantityByID")]
        public IActionResult GetProductQuantityById([FromBody] int id)
        {
            var answer = _raportReporisotry.GetProductQuantityById(id);
            return Ok(answer);
        }
        [HttpGet]
        [Route("PriceByID")]
        public IActionResult GetProductPriceById([FromBody] int id)
        {
            var answer = _raportReporisotry.GetProductPriceById(id);
            return Ok(answer);
        }
        [HttpGet]
        [Route("Turnover")]
        public IActionResult GetTotalTurnover()
        {
            var answer = _raportReporisotry.GetTotalTurnover();
            return Ok(answer);
        }
        [HttpGet]
        [Route("Profit")]
        public IActionResult GetProfit()
        {
            var answer = _raportReporisotry.GetProfit();
            return Ok(answer);
        }
        [HttpGet]
        [Route("TransactionsByType")]
        public IActionResult GetTransactionsByType([FromBody] TransactionType transactionType)
        {
            var answer = _raportReporisotry.GetTransactionsByType(transactionType);
            return Ok(answer);
        }

    }
}