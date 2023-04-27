using AutoMapper;
using CallCenterProject.Data.Entities;
using CallCenterProject.Data;
using Microsoft.AspNetCore.Mvc;
using CallCenterProject.Data.DTO.UserDTO;
using Microsoft.EntityFrameworkCore;

namespace CallCenterProject.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly MainDb context;
        private readonly IMapper mapper;

        public UserController(MainDb context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("/CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserInfo ınfo)
        {
            try
            {
                if (!IsUserExist(ınfo.Email))
                {
                    var user = mapper.Map<User>(ınfo);
                    context.Users.Add(user);
                    await context.SaveChangesAsync();
                    return Ok(user);
                }
                else
                {
                    throw new Exception("The user already exist!");
                }
            }
            catch (Exception) { throw new Exception(); }
        }

        [HttpPut]
        [Route("/UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] User ınfo)
        {
            try
            {
                var user = mapper.Map<User>(ınfo);
                context.Users.Update(user);
                await context.SaveChangesAsync();
                return Ok(user);
            }
            catch (Exception) { throw new Exception(); }
        }

        [HttpDelete]
        [Route("/DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromBody] int Id)
        {
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(x => x.Id == Id);
                context.Users.Remove(user);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception) { throw new Exception(); }
        }

        [HttpGet]
        [Route("/GetUser")]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var user = await context.Users
                    .Select(x => mapper.Map<User>(x))
                    .ToListAsync();
                return Ok(user);
            }
            catch (Exception) { throw new Exception(); }
        }

        [HttpGet]
        [Route("GetUserById")]
        public async Task<IActionResult> GetUserById(int Id)
        {
            try
            {
                var user = await context.Users
                    .Where(x => x.Id == Id)
                    .Select(x => mapper.Map<User>(x))
                    .ToListAsync();
                return Ok(user);
            }
            catch (Exception) { throw new Exception(); }
        }

        ///////////////////////////////////////////////
        private bool IsUserExist(string mail)
        {
            return context.Users.Any(x => x.Email == mail);
        }
    }
}
