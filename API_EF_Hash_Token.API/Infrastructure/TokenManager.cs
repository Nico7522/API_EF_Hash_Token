using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_EF_Hash_Token.API.Infrastructure
{
    public class TokenManager
    {
        private readonly IConfiguration _configuration;
        public readonly string _secret;
        public readonly string _issuer;
        public readonly string _audience;

        public TokenManager(IConfiguration configuration)
        {
            _configuration = configuration;
            _secret = _configuration["jwt:key"];
            _issuer = _configuration["jwt:issuer"];
            _audience = _configuration["jwt:audience"];
        }

        public string GerenateJwt(dynamic user, int expirationDate = 1)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            DateTime now = DateTime.Now;

            Claim[] myClaims = new Claim[]
            {
                new Claim(ClaimTypes.Sid, user.UserId.ToString()),

                new Claim(ClaimTypes.GivenName, $"{user.FirstName} {user.LastName}"),

                new Claim(ClaimTypes.Role, user.Role),

                new Claim(ClaimTypes.Expiration, now.Add(TimeSpan.FromDays(expirationDate)).ToString(), ClaimValueTypes.DateTime)
            };

            JwtSecurityToken token = new JwtSecurityToken(
                claims: myClaims,
                expires: now.Add(TimeSpan.FromDays(expirationDate)),
                signingCredentials: credentials,
                issuer: _issuer,
                audience: _audience
            );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }
}
