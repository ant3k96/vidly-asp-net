using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly VidlyDbContext _dbContext;
        private readonly IMapper _mapper;
        public CustomersController(VidlyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CustomerDto>> GetCustomers(string? term)
        {
            var customersQuery = _dbContext.Customers.Include(c => c.MembershipType);

            if (!string.IsNullOrWhiteSpace(term))
            {
                customersQuery = customersQuery.Where(c => c.Name.Contains(term)).Include(x => x.MembershipType);
            }

            var customers = customersQuery.ToList();
            return Ok(customers.Select(_mapper.Map<Customer, CustomerDto>));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCustomer(int id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                throw new KeyNotFoundException("Customer not found");
            }
            return Ok(_mapper.Map<CustomerDto>(customer));

        }

        [HttpPost]
        public IActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new BadHttpRequestException("Bad request");
            }

            var customer = _mapper.Map<Customer>(customerDto);

            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(CreateCustomer), new { id = customer.Id }, customerDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] CustomerDto customer)
        {
            if (!ModelState.IsValid)
            {
                throw new BadHttpRequestException("Bad request");
            }

            var customerDb = _dbContext.Customers.SingleOrDefault(c => c.Id == id);

            if (customerDb == null)
            {
                throw new KeyNotFoundException("Customer not found");
            }
            _mapper.Map(customer, customerDb);

            _dbContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customerDb = _dbContext.Customers.SingleOrDefault(c => c.Id == id);

            if (customerDb == null)
            {
                throw new KeyNotFoundException("Customer not found");
            }

            _dbContext.Customers.Remove(customerDb);
            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}
