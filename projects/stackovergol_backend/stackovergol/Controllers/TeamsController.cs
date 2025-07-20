using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using stackovergol.Data.Entity;
using stackovergol.Dto;
using stackovergol.Services;

namespace stackovergol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private static List<TeamTest> _lastDraw = new();
        private readonly TeamBalancer _balancer;

        public TeamsController(TeamBalancer balancer)
        {
            _balancer = balancer;
        }

        [HttpPost("draw")]
        public IActionResult DrawTeams([FromBody] List<PlayerTest> players)
        {
            try
            {
                var result = _balancer.DrawTeams(players);
                _lastDraw = result;
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("last")]
        public IActionResult LastDraw()
        {
            return Ok(_lastDraw);
        }
    }
}
