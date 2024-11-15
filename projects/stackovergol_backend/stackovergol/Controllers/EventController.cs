using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using stackovergol.Data.Service;
using stackovergol.Dto;
using stackovergol.Infra;
using stackovergol.Infra.Security;
using System.Diagnostics.CodeAnalysis;

namespace stackovergol.Controllers
{
    public class EventController : BaseController
    {
        private readonly EventService eventService;

        public EventController(EventService eventService, IOptions<AppSettings> appSettings) : base(appSettings)
        {
            this.eventService = eventService;
        }

        [Authorize(Roles = Constants.GERAL)]
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(eventService.GetAll());
        }

        /// <summary>
        /// Next event
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = Constants.GERAL)]
        [HttpGet("next")]
        public ActionResult GetNext() => Ok(eventService.GetNext());

        /// <summary>
        /// Create new events
        /// </summary>
        /// <param name="eventDTO"></param>
        /// <returns></returns>
        [Authorize(Roles = Constants.ADMIN)]
        [HttpPost("next")]
        public ActionResult Post([FromBody] EventRequest eventDTO) {
            return Ok(eventService.Add(eventDTO));
        }

        
        [Authorize(Roles = Constants.GERAL)]
        [HttpPost("register-player-in-event")]
        public ActionResult InOrOut([FromBody] InOrOutEventDTO inOrOutEventDTO) 
        {
            eventService.PlayerInOrOutOfEvent(inOrOutEventDTO);
            return Created();
        }

        [Authorize(Roles =Constants.ADMIN)]
        [HttpDelete("remove-player-from-event/{playerId}")]
        public ActionResult DeletePlayerFromMatch(int playerId) 
        {
            eventService.DeletePlayerFromMatch(playerId);
            return Ok();
        }
    }
}
