/*-----------------------------------------
 * 作者：杨泽华
 * 最后修改：2021.7.15
 * 功能：为给定的用户名、密码和用户类型生成token
 ----------------------------------------*/
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackEnd
{
    public class JwtAuthenticationHandler : IJwtAuthenticationHandler
    {
        private readonly string _secretKey;   //声明一个加密的密钥，由外部传入

        public JwtAuthenticationHandler(string secretKey)
        {
            _secretKey = secretKey;
        }

        public string Authenticate(string username, string password, string type)
        {
            var tokenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Issuer = "http://47.118.78.110:80/",
                Audience = "api",
                SigningCredentials = new SigningCredentials(tokenKey, SecurityAlgorithms.HmacSha256),
                Expires = DateTime.Now.AddMinutes(30),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,username),
                    new Claim(ClaimTypes.Role,type)
                })
            };

            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
