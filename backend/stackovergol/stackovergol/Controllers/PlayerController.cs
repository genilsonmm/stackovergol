using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using stackovergol.Data.Service;
using stackovergol.Dto;

namespace stackovergol.Controllers
{
    public class PlayerController : BaseController
    {
        private readonly PlayerService playerService;

        public PlayerController(PlayerService playerService)
        {
            this.playerService = playerService;
        }

        [HttpGet]
        public IEnumerable<PlayerResultDTO> Get()
        {
            return playerService.GetAll();
        }

        [HttpPost]
        public ActionResult Post([FromBody] PlayerDTO player)
        {
            var result = playerService.Add(player);
            return Ok(new
            {
                result
            });
        }

    }
}
