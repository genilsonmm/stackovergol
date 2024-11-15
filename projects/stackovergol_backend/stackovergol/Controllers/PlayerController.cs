using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using stackovergol.Data.Service;
using stackovergol.Dto;
using stackovergol.Infra;
using stackovergol.Infra.Security;

namespace stackovergol.Controllers
{
    public class PlayerController : BaseController
    {
        private readonly PlayerService playerService;

        public PlayerController(PlayerService playerService, IOptions<AppSettings> appSettings) : base(appSettings)
        {
            this.playerService = playerService;
        }

        [Authorize(Roles = Constants.GERAL)]
        [HttpGet]
        public IEnumerable<PlayerResponseDTO> Get() => playerService.GetAll();

        [Authorize(Roles = Constants.ADMIN)]
        [HttpPost("except")]
        public ActionResult GetExcept([FromBody]List<int> ids)
        {
            return Ok(playerService.GetAllExcept(ids));
        }

        [Authorize(Roles = Constants.ADMIN)]
        [HttpPost]
        public ActionResult Post([FromBody] PlayerDTO player)
        {
            player.Password = Encrypted(player.Password);
            return Ok(playerService.Add(player));
        }

        [Authorize(Roles = Constants.GERAL)]
        [HttpPut]
        public ActionResult Put([FromBody] PlayerDTO player)
        {
            playerService.Update(player);
            return Ok();
        }
    }
}
