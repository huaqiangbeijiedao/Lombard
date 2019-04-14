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
        public IActionResult ProductsOutage()
        {
            var sth = _raportReporisotry.CheckProductsOutage();
            return Ok(sth);
        }
    }
}