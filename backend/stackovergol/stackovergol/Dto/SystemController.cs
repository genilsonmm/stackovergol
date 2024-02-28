using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace stackovergol.Dto
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        // GET: api/<SystemController>
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Ping";
        }

    }
}
