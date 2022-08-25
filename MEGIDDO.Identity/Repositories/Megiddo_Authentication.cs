using MEGIDDO.Identity.Dtos;
using MEGIDDO.Identity.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MEGIDDO.Identity.Repositories
{
    public class Megiddo_Authentication : IMegiddo_Authentication
    {

        private readonly IConfiguration _configuration;

        public Megiddo_Authentication(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<TokenResult> GetJWTToken(UserLoginModel user)
        {
            try
            {
                var _User = GetUserByUsernameAndPassword(user);
                if(_User is null)
                {
                    return new TokenResult
                    {
                        IsSuccess = false,
                        RefreshToken = "",
                        Token = ""
                    };
                }
                var jwtTokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("ID", _User.UId.ToString()),
                        new Claim("Username", _User.Username)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])), SecurityAlgorithms.HmacSha256),
                    Audience = _configuration["Jwt:Audience"],
                    Issuer = _configuration["Jwt:Issuer"]
                };
                var token = jwtTokenHandler.CreateToken(tokenDescriptor);
                //string resultJWT = "Bearer " + jwtTokenHandler.WriteToken(token);
                string resultJWT = jwtTokenHandler.WriteToken(token);
                return new TokenResult
                {
                    IsSuccess = true,
                    RefreshToken = "",
                    Token = resultJWT
                };
            }
            catch(Exception e)
            {
                return new TokenResult
                {
                    IsSuccess = false,
                    RefreshToken = "",
                    Token = ""
                };
            }
        }

        private User GetUserByUsernameAndPassword(UserLoginModel user)
        {
            var _user = ListUser.Users.FirstOrDefault(a => a.Password.Equals(user.Password) && a.Username.Equals(user.Username));
            return _user;
        }
    }
}
