using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcoregraphql.Controllers
{
    [Produces("application/json")]
    [Route("/")]
    public class IndexController : Controller
    {
        public IActionResult Index()
        {
            var result = new
            {
                Value = "success"
            };

            return Ok(result);
        }
    }
}