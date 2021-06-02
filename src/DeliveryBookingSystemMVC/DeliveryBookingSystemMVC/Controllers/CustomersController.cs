using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeliveryBookingSystemMVC.Models;
using Microsoft.Extensions.Logging;
using DeliveryBookingSystemMVC.Services;

namespace DeliveryBookingSystemMVC.Controllers
{
    public class CustomersController : Controller
    {

        public readonly ILogger<CustomersController> _logger;
        public readonly ILogin<Customer> _repo;
        public readonly ILogin<Booking> _repo1;
        public DeliveryContext _context;

        public CustomersController(ILogger<CustomersController> logger, ILogin<Customer> repo, ILogin<Booking> repo1)
        {
            _logger = logger;
            _repo = repo;
            _repo1 = repo1;
        }
        public IActionResult CustomerHomePage()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Customer> customers = _repo.GetAll().ToList();
            return View(customers);
        }
        public IActionResult CustomerInfo()
        {
            List<Customer> customers = _repo.GetAll().ToList();
            return View(customers);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            customer.IsVerified = "Null";
            _repo.Add(customer);
            return RedirectToAction("MainHomePage","User");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Customer customer)
        {
            int id = _repo.Login(customer);
            if (id != 0)
            {
                TempData["Customer Id"] = id;
                return RedirectToAction("CustomerHomePage", "Customers");
            }
            else
            {
                TempData["Message"] = "You’ve entered an incorrect UserName or Password or not a verified User Please Try again!";
                return RedirectToAction("Login");

            }
        }
        public ActionResult Success()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            Customer customer = _repo.Get(id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult Edit(int id, Customer customer)
        {
            _repo.Update(id, customer);
            return RedirectToAction("Index");
        }
       
        public IActionResult RequestList()
        {
            int id = Convert.ToInt32(TempData.Peek("Customer Id"));
            List<Booking> booking = _repo1.GetAll().Where(a => a.CustomerId == id && a.Status=="Requested").ToList();
            if (booking.Count() != 0)
            {
                return View(booking);
            }
            else if (booking.Count() == 0)
            {
                return View("Empty");
            }
            return View();
        }
        public IActionResult AcceptedList()
        {
            int id = Convert.ToInt32(TempData.Peek("Customer Id"));
            List<Booking> booking = _repo1.GetAll().Where(a => a.CustomerId == id && a.Status == "Accepted").ToList();
            if (booking.Count() != 0)
            {
                return View(booking);
            }
            else if (booking.Count() == 0)
            {
                return View("Empty");
            }
            return View();
        }
        public IActionResult RejectedList()
        {
            int id = Convert.ToInt32(TempData.Peek("Customer Id"));
            List<Booking> booking = _repo1.GetAll().Where(a => a.CustomerId == id && a.Status == "Rejected").ToList();
            if (booking.Count() != 0)
            {
                return View(booking);
            }
            else if (booking.Count() == 0)
            {
                return View("Empty");
            }
            return View();
        }
        public ActionResult Empty()
        {
            return View();
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(CustomerHomePage));
        }

    }
}



    

