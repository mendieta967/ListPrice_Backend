using Lista_Price.Data.Repository;
using Lista_Price.Entities;
using Lista_Price.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Lista_Price.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        private readonly IConfiguration _config;


        public AuthenticateController(UserRepository userRepository, IConfiguration configuration) 
        {
            _userRepository = userRepository;
            _config = configuration;
        }
        [HttpPost]
        public IActionResult Authenticate([FromBody] CredentialsForAuthenticateDto credentials)
        {
           User? userAuthenticated = _userRepository.Authenticate(credentials.Email, credentials.Password);
           if (userAuthenticated is not null)
            {
                var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"]));
                SigningCredentials signature = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

                var claimsForToken = new List<Claim>();
                claimsForToken.Add(new Claim("sub", userAuthenticated.Id.ToString()));
                claimsForToken.Add(new Claim("give_name", userAuthenticated.Email.ToString()));

                var jwtSecurityToken = new JwtSecurityToken(
                    _config["Authentication:Issuer"],
                    _config["Authentication:Audience"],
                    claimsForToken,
                    DateTime.UtcNow,
                    DateTime.UtcNow.AddHours(1),
                    signature);

                string tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                return Ok(tokenToReturn);
            }

            return Unauthorized();
        }
    }
}
