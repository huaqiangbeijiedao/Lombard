using Lombard.API.Models;
using Lombard.API.Repository;
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
        [Route("Outage/{quant}")]
        public IActionResult ProductsOutage(int quant)
        {
            var sth = _raportReporisotry.CheckProductsOutage(quant);
            return Ok(sth);
        }
        [HttpGet]
        [Route("QuantityByID/{id}")]
        public IActionResult GetProductQuantityById(int id)
        {
            var answer = _raportReporisotry.GetProductQuantityById(id);
            return Ok(answer);
        }
        [HttpGet]
        [Route("PriceByID/{id}")]
        public IActionResult GetProductPriceById(int id)
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
        [Route("TransactionsByType/{transactionType}")]
        public IActionResult GetTransactionsByType(TransactionType transactionType)
        {
            var answer = _raportReporisotry.GetTransactionsByType(transactionType);
            return Ok(answer);
        }

    }
}