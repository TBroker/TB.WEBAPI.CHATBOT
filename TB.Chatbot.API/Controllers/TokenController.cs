using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TB.Chatbot.Application.Interfaces;
using TB.Chatbot.Domain.Requests;

namespace TB.Chatbot.API.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController(IConfiguration config, IWebDataRepository webDataRepository) : Controller
    {
        private readonly IConfiguration _configuration = config;
        private readonly IWebDataRepository _webDataRepository = webDataRepository;

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AuthorizationJWTToken(ReqUserInfo reqUserInfo)
        {
            if (reqUserInfo != null && reqUserInfo.UserName != null && reqUserInfo.Password != null)
            {
                try
                {
                    var user = await _webDataRepository.GetDataUserToken(reqUserInfo);

                    if (user != null)
                    {
                        //create claims details based on the user information
                        var issuer = _configuration["Jwt:Issuer"];
                        var audience = _configuration["Jwt:Audience"];
                        var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!);
                        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature);

                        var subject = new ClaimsIdentity(
                                [
                                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]!),
                                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                                    new Claim("DisplayName", user.displayname!),
                                    new Claim("UserName", user.username!),
                                ]);

                        var expires = DateTime.UtcNow.AddMinutes(15);

                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = subject,
                            Expires = expires,
                            Issuer = issuer,
                            Audience = audience,
                            SigningCredentials = signingCredentials
                        };
                        var tokenHandler = new JwtSecurityTokenHandler();
                        var token = tokenHandler.CreateToken(tokenDescriptor);
                        var jwtToken = tokenHandler.WriteToken(token);

                        return Ok(jwtToken);
                    }
                    else
                    {
                        return BadRequest("Invalid credentials");
                    }
                }
                catch
                {
                    return StatusCode(500);
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}