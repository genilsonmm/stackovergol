using Microsoft.IdentityModel.Tokens;
using stackovergol.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace stackovergol.Infra.Security
{
    public class TokenManager
    {
        private readonly AppSettings appSettings;
        public TokenManager(AppSettings appSettings)
        {
            this.appSettings = appSettings;
        }
        public string GenerateToken(string username, string role)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddHours(appSettings.ExpirationHour),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                         SecurityAlgorithms.HmacSha256Signature)
            };

            //HmacSha256Signature nunca foi quebrado 22/04/2020 

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
