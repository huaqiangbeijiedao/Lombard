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
    public class RaportController : ControllerBase
    {
        private readonly IRaportRepository _raportReporisotry;

        public RaportController (IRaportRepository raportRepository )
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
    }
}