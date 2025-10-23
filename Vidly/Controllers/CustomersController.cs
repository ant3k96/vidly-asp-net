using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly VidlyDbContext _context;

        public CustomersController(VidlyDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult New()
        {
            var membershipsTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel { Customer = new Customer(), MembershipTypes = membershipsTypes };
            return View("CustomerForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAsync(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var model = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", model);
            }
            if (customer.Id == 0)
            {
                await _context.Customers.AddAsync(customer);
            }
            else
            {
                var customerInDb = await _context.Customers.FindAsync(customer.Id);

                if (customerInDb is null)
                {
                    return NotFound();
                }
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.Name = customer.Name;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Customers");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(x => x.Id == id);

            return View(customer);
        }

        public async Task<IActionResult> EditAsync(int id)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(x => x.Id == id);

            if (customer == null)
                return NotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}
