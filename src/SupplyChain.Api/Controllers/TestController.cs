using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SupplyChain.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public ActionResult TestGet()
        {
            return Ok("Vsecko jede jak ma!");
        }
    }
}
