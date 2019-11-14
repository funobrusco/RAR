using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RAR.API.Service;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System;
using RAR.DAL.Model;

namespace RAR.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : RARController
    {
        private IUserService _userService;
        private readonly IConfiguration _config;

        public TokenController(IUserService userService, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
            : base(httpContextAccessor)
        {
            _config = configuration;
            _userService = userService;
        }

        [HttpPost("Authenticate")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] User authUserRequest)
        {
            var user = _userService.Authenticate(authUserRequest.Username);

            if (user != null)
            {
                var claims = new[]
                {
                        new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                        new Claim(JwtRegisteredClaimNames.Jti, user.token),
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

                return Ok(token);

            }
            return BadRequest("Could not create token");
        }
    }
}