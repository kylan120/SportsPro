using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models;
using System;
using System.Linq;

namespace SportsPro.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly SportsProContext _context;

        public RegistrationController(SportsProContext context)
        {
            _context = context;
        }

        // GetCustomer action to display the Get Customer page
        public IActionResult GetCustomer()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        public IActionResult Registrations(int customerId)
        {
            var registrations = _context.Registrations
                .Include(r => r.Product)
                .Where(r => r.CustomerID == customerId)
                .ToList();

            var customer = _context.Customers.FirstOrDefault(c => c.CustomerID == customerId);
            if (customer == null)
            {
                return NotFound();
            }

            ViewBag.CustomerName = customer.FullName;
            return View(registrations);
        }


        // GetRegistrations action to display Registrations page after selecting a customer
        [HttpPost]
        public IActionResult GetRegistrations(int customerId)
        {
            var customer = _context.Customers.Include(c => c.Registrations).FirstOrDefault(c => c.CustomerID == customerId);
            if (customer == null)
            {
                return RedirectToAction("GetCustomer");
            }

            HttpContext.Session.SetInt32("CustomerId", customerId);

            var products = _context.Products.ToList();
            ViewBag.Products = products;
            return View("Registrations", Tuple.Create(customer, customer.Registrations.Select(r => r.Product)));
        }

        // RegisterProduct action to handle registration of a new product for the selected customer
        [HttpPost]
        public IActionResult RegisterProduct(int productId)
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            if (customerId == null)
            {
                return RedirectToAction("GetCustomer");
            }

            var registration = new RegistrationModel
            {
                CustomerID = customerId.Value,
                ProductID = productId
            };

            _context.Registrations.Add(registration);
            _context.SaveChanges();

            return RedirectToAction("GetRegistrations", new { customerId });
        }
    }

}
