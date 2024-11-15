using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using stackovergol.Data.Service;
using stackovergol.Dto;
using stackovergol.Infra.Security;

namespace stackovergol.Controllers
{
    public class AuthController : BaseController
    {
        private readonly PlayerService playerService;
        public AuthController(PlayerService playerService, IOptions<AppSettings> appSettings) : base(appSettings)
        {
            this.playerService = playerService; 
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Authenticate([FromBody] UserAuth userAuth)
        {
            var userFound = playerService.GetByCredentials(userAuth.Username, Encrypted(userAuth.Password));
            return Ok(new
            {
                name= userFound.Name,
                id = userFound.PlayerId,
                role=userFound.Role,
                token=tokenManager.GenerateToken(userAuth.Username, userFound.Role),
                date=DateTime.Now
            });
        }
    }
}
