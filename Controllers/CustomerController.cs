using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vidly.Data;
using vidly.Models;
using vidly.ViewModels;

namespace vidly.Controllers
{
    [Authorize]
    [Route("customer")]
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        [Route("")]
        public async Task<IActionResult> Index()
        {
            return View("~/Pages/Customer/Index.cshtml");
        }

        [Route("detail/{id:int}")]
        public async Task<IActionResult> Detail(int id)
        {
            var detail = await _context.Customers.Include(c => c.MembershipType).FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (detail == null) return NotFound();
            return View(detail);
        }

        [Route(nameof(Add))]
        public async Task<IActionResult> Add(string name)
        {
            var memberShipType = await _context.MembershipType.ToListAsync();
            var viewModel = new CustomerFormViewModel
            {
                MembershipType = memberShipType,
                Customer = new Customer()
            };
            return View("~/Pages/Customer/CustomerForm.cshtml", viewModel);
        }

        [HttpPost(nameof(Save))]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipType = await _context.MembershipType.ToListAsync()
                };
                return View("~/Pages/Customer/CustomerForm.cshtml", viewModel);
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                _context.Customers.Update(customer);
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(x => x.Id == id);
            if (customer == null) return NotFound();
            var formViewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipType = await _context.MembershipType.ToListAsync()
            };
            return View("~/Pages/Customer/CustomerForm.cshtml", formViewModel);
        }
    }
}