using AutoMapper;
using CallCenterProject.Data;
using CallCenterProject.Data.DTO.RequestDTO;
using CallCenterProject.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CallCenterProject.Controllers
{
    public class RequestController : ControllerBase
    {
        private readonly MainDb context;
        private readonly IMapper mapper;

        public RequestController(MainDb context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpPost]
        [Route("/CreateRequest")]
        public async Task<IActionResult> CreateRequest([FromBody] CreateRequest ınfo)
        {
            try
            {
                var request = mapper.Map<RequestEntity>(ınfo);
                context.RequestEntities.Add(request);
                await context.SaveChangesAsync();
                return Ok(request);

            }catch(Exception) { throw new Exception(); }
        }

        [HttpPut]
        [Route("/UpdateRequest")]
        public async Task<IActionResult> UpdateRequest([FromBody] RequestInfo ınfo)
        {
            try
            {
                var request = mapper.Map<RequestEntity>(ınfo);
                context.RequestEntities.Update(request);
                await context.SaveChangesAsync();
                return Ok(request);
            }
            catch (Exception) { throw new Exception(); }
        }

        [HttpDelete]
        [Route("/RequestDelete")]
        public async Task<IActionResult> DeleteRequest([FromBody] int Id)
        {
            try
            {
                var request = await context.RequestEntities.FirstOrDefaultAsync(x => x.RequestId == Id);
                context.RequestEntities.Remove(request);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception) { throw new Exception(); }
        }

        [HttpGet]
        [Route("/GetRequest")]
        public async Task<IActionResult> GetCustomer()
        {
            try
            {
                var request = await context.RequestEntities
                    .Select(x => mapper.Map<RequestEntity>(x))
                    .ToListAsync();
                return Ok(request);
            }
            catch (Exception) { throw new Exception(); }
        }

        [HttpGet]
        [Route("GetRequestById")]
        public async Task<IActionResult> GetCustomerById(int Id)
        {
            try
            {
                var request = await context.RequestEntities
                    .Where(x => x.RequestId == Id)
                    .Select(x => mapper.Map<RequestEntity>(x))
                    .ToListAsync();
                return Ok(request);
            }
            catch (Exception) { throw new Exception(); }
        }
    }
}
