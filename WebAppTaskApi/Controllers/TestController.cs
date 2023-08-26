using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace WebAppTaskApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {

        [HttpGet]
        [Route("Sync")]
        public IActionResult GetSync()
        {
           Thread.Sleep(1000);
            return Ok();
        }

        [HttpGet]
        [Route("Async")]
        public async Task<IActionResult> GetAsync()
        {
           await Task.Delay(1000);
            return Ok();
        }
    }
}
