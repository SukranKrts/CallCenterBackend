/*using CallCenterProject.Data;
using CallCenterProject.Data.DTO.UserDTO;
using CallCenterProject.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CallCenterProject.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly MainDb context;

        public LoginController(IConfiguration configuration, MainDb context)
        {
            this.configuration = configuration;
            this.context = context;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("UserLogin")]
        public async Task<IActionResult> Login([FromBody] UserLogin login)
        {
            var user = Authenticate(login);

            if(user !=null)
            {
                var token = Generate(await user);
                return Ok(token);
            }
            return NotFound("User mail or user password are not true!");
        }

        private string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.MobilePhone, user.Phone),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<User> Authenticate(UserLogin login)
        {
            var _user = await context.Users.FirstOrDefaultAsync(x => x.Email ==
              login.Email && x.Password == login.Password);

            if(_user != null)
            {
                return _user;
            }
            return null;
        }
    }
}
*/