using AutoMapper;
using CallCenterProject.Data;
using CallCenterProject.Data.DTO.CustomerDTO;
using CallCenterProject.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CallCenterProject.Controllers
{
    public class CustomerController : ControllerBase
    {
       
        private readonly MainDb context;
        private readonly IMapper mapper;

        public CustomerController(MainDb context, IMapper mapper )
        {
            this.context = context;
            this.mapper = mapper;            
        }

        [HttpPost]
        [Route("/CreateCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerLogin login)
        {
            try
            {
                if (!IsCustomerExist(login.CustomerMail))
                {
                    var customer = mapper.Map<Customer>(login);
                    context.Customers.Add(customer);
                    await context.SaveChangesAsync();
                    return Ok(customer);
                }
                else
                {
                    throw new Exception("The customer already exist!");
                }
            }catch(Exception) { throw new Exception(); }
        }

        [HttpPut]
        [Route("/UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerInfo ınfo)
        {
            try
            {
                var customer = mapper.Map<Customer>(ınfo);
                context.Customers.Update(customer);
                await context.SaveChangesAsync();
                return Ok(customer);
            }catch(Exception) { throw new Exception(); }
        }

        [HttpDelete]
        [Route("/CustomerDelete")]
        public async Task<IActionResult> DeleteCustomer([FromBody] int Id)
        {
            try
            {
                var customer = await context.Customers.FirstOrDefaultAsync(x => x.CustomerId == Id);
                context.Customers.Remove(customer);
                await context.SaveChangesAsync();
                return Ok();
            }catch(Exception) { throw new Exception(); }
        }

        [HttpGet]
        [Route("/GetCustomer")]
        public async Task<IActionResult> GetCustomer()
        {
            try
            {
                var customer = await context.Customers
                    .Select(x => mapper.Map<Customer>(x))
                    .ToListAsync();
                return Ok(customer);
            }
            catch (Exception) { throw new Exception(); }
        }

        [HttpGet]
        [Route("GetCustomerById")]
        public async Task<IActionResult> GetCustomerById(int Id)
        {
            try
            {
                var customer = await context.Customers
                    .Where(x=>x.CustomerId== Id)
                    .Select(x=>mapper.Map<Customer>(x))
                    .ToListAsync();
                return Ok(customer);
            }catch(Exception) { throw new Exception(); }
        }

        ///////////////////////////////////////////////
        private bool IsCustomerExist(string mail)
        {
            return context.Customers.Any(x => x.CustomerMail == mail);
        }
    }
}
