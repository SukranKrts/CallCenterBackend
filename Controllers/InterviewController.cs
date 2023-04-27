using AutoMapper;
using CallCenterProject.Data;
using CallCenterProject.Data.DTO.InterviewDTO;
using CallCenterProject.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CallCenterProject.Controllers
{
    public class InterviewController : ControllerBase
    {

        private readonly MainDb context;
        private readonly IMapper mapper;

        public InterviewController(MainDb context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("/CreateInterview")]
        public async Task<IActionResult> CreateInterview([FromBody] InterviewCreate login)
        {
            try
            {
                var interview = mapper.Map<Interview>(login);
                context.Interviews.Add(interview);
                await context.SaveChangesAsync();
                return Ok(interview);
            }
            catch (Exception) { throw new Exception(); }
        }

        [HttpPut]
        [Route("/UpdateInterview")]
        public async Task<IActionResult> UpdateInterview([FromBody] InterviewInfo ınfo)
        {
            try
            {
                var interview = mapper.Map<Interview>(ınfo);
                context.Interviews.Update(interview);
                await context.SaveChangesAsync();
                return Ok(interview);
            }
            catch (Exception) { throw new Exception(); }
        }

        [HttpDelete]
        [Route("/InterviewDelete")]
        public async Task<IActionResult> DeleteInterview([FromBody] int Id)
        {
            try
            {
                var interview = await context.Interviews.FirstOrDefaultAsync(x => x.InterviewId == Id);
                context.Interviews.Remove(interview);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception) { throw new Exception(); }
        }

        [HttpGet]
        [Route("/GetInterview")]
        public async Task<IActionResult> GetInterview()
        {
            try
            {
                var interview = await context.Interviews
                    .Select(x => mapper.Map<Interview>(x))
                    .ToListAsync();
                return Ok(interview);
            }
            catch (Exception) { throw new Exception(); }
        }

        [HttpGet]
        [Route("GetInterviewById")]
        public async Task<IActionResult> GetInterviewById(int Id)
        {
            try
            {
                var interview = await context.Interviews
                    .Where(x => x.InterviewId == Id)
                    .Select(x => mapper.Map<Interview>(x))
                    .ToListAsync();
                return Ok(interview);
            }
            catch (Exception) { throw new Exception(); }
        }
    }
}
