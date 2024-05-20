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
            const string AUTH_TOKEN = "stack-overgol";
            byte[] key = Encoding.ASCII.GetBytes(AUTH_TOKEN);
            HMACSHA256 myhmacsha256 = new HMACSHA256(key);
            byte[] byteArray = Encoding.ASCII.GetBytes(password);
            MemoryStream stream = new MemoryStream(byteArray);
            string result = myhmacsha256.ComputeHash(stream).Aggregate("", (s, e) => s + String.Format("{0:x2}", e), s => s);
            return result;
        }
    }
}
