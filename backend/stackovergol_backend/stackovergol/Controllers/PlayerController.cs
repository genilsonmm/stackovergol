using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using stackovergol.Data.Entity;
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
        public IEnumerable<PlayerResponseDTO> Get() => playerService.GetAll();

        [HttpPost]
        public ActionResult Post([FromBody] PlayerDTO player) => Ok(playerService.Add(player));

        [HttpPut]
        public ActionResult Put([FromBody] PlayerDTO player)
        {
            playerService.Update(player);
            return Ok();
        }
    }
}
