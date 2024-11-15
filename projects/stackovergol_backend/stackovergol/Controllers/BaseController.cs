using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using stackovergol.Infra.Security;
using System.Security.Cryptography;
using System.Text;

namespace stackovergol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BaseController : ControllerBase
    {
        public readonly TokenManager tokenManager;

        public BaseController(IOptions<AppSettings> appSettings)
        {
            this.tokenManager = new TokenManager(appSettings.Value);
        }

        public string Encrypted(string password)
        {
            return TokenManager.Encrypted(password);
        }
    }
}
