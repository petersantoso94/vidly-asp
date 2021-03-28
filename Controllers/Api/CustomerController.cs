
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vidly.Data;
using vidly.Dtos;
using vidly.Models;

namespace vidly.Controllers.Api
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CustomerController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }
        [HttpGet]
        [Route("")]
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.Include(c => c.MembershipType).ToList().Select(_mapper.Map<Customer, CustomerDto>);
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null) return new NotFoundResult();
            return Ok(_mapper.Map<Customer, CustomerDto>(customer));
        }

        [HttpPost]
        public IActionResult PostAsync([FromBody] CustomerDto customerDto)
        {
            // validate customer
            if (!ModelState.IsValid) return BadRequest();
            var customer = _mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return CreatedAtAction("GetCustomer", customer.Id, customerDto);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody] CustomerDto customerDto)
        {
            // validate customer
            if (!ModelState.IsValid) return BadRequest();
            var existingCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (existingCustomer == null) return NotFound();

            // update customer
            _mapper.Map(customerDto, existingCustomer);

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var existingCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (existingCustomer == null) return NotFound();
            _context.Customers.Remove(existingCustomer);
            _context.SaveChanges();
            return Ok();
        }
    }
}