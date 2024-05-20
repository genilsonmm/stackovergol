using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using stackovergol.Data.Service;
using stackovergol.Dto;
using stackovergol.Infra;
using stackovergol.Infra.Security;

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

        [Authorize(Roles = Constants.GERAL)]
        [HttpGet("next")]
        public ActionResult GetNext() => Ok(eventService.GetNext());

        [Authorize(Roles = Constants.ADMIN)]
        [HttpPost("next")]
        public ActionResult Post([FromBody] EventResponse eventDTO) {
            return Ok(eventService.Add(eventDTO));
        }
    }
}
