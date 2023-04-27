using AutoMapper;
using CallCenterProject.Data;
using CallCenterProject.Data.DTO.RepresentativeDTO;
using CallCenterProject.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CallCenterProject.Controllers
{
    public class RepresentativeController : ControllerBase
    {

        private readonly MainDb context;
        private readonly IMapper mapper;

        public RepresentativeController(MainDb context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("/CreateRepresentative")]
        public async Task<IActionResult> CreateRep([FromBody] RepresentativeLogin login)
        {
            try
            {
                if (!IsRepresentativeExist(login.RepMail))
                {
                    var representative = mapper.Map<Representative>(login);
                    context.Representatives.Add(representative);
                    await context.SaveChangesAsync();
                    return Ok(representative);
                }
                else
                {
                    throw new Exception("The representative is already exist!");
                }
            }
            catch (Exception) { throw new Exception(); }
        }

        [HttpPut]
        [Route("/UpdateRepresentative")]
        public async Task<IActionResult> UpdateRep([FromBody] RepresentativeInfo ınfo)
        {
            try
            {
                var representative = mapper.Map<Representative>(ınfo);
                context.Representatives.Update(representative);
                await context.SaveChangesAsync();
                return Ok(representative);
            }
            catch (Exception) { throw new Exception(); }
        }

        [HttpDelete]
        [Route("/RepresentativeDelete")]
        public async Task<IActionResult> DeleteRep([FromBody] int Id)
        {
            try
            {
                var representative = await context.Representatives.FirstOrDefaultAsync(x => x.RepId == Id);
                context.Representatives.Remove(representative);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception) { throw new Exception(); }
        }

        [HttpGet]
        [Route("/GetRepresentative")]
        public async Task<IActionResult> GetRep()
        {
            try
            {
                var representative = await context.Representatives
                    .Select(x => mapper.Map<Representative>(x))
                    .ToListAsync();
                return Ok(representative);
            }
            catch (Exception) { throw new Exception(); }
        }

        [HttpGet]
        [Route("GetRepresentativeById")]
        public async Task<IActionResult> GetRepById(int Id)
        {
            try
            {
                var representative = await context.Representatives
                    .Where(x => x.RepId == Id)
                    .Select(x => mapper.Map<Representative>(x))
                    .ToListAsync();
                return Ok(representative);
            }
            catch (Exception) { throw new Exception(); }
        }

        /////////////////////////////////////////////////
        private bool IsRepresentativeExist(string mail)
        {
            return context.Representatives.Any(x => x.RepMail == mail);
        }
    }
}