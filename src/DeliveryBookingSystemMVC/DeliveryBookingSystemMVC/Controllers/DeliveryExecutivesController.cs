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
    public class DeliveryExecutivesController : Controller
    {

        public readonly ILogger<DeliveryExecutivesController> _logger;
        public readonly ILogin<DeliveryExecutive> _repo;
        public readonly ILogin<Booking> _repo1;
        public DeliveryExecutivesController(ILogger<DeliveryExecutivesController> logger, ILogin<DeliveryExecutive> repo, ILogin<Booking> repo1)
        {
            _logger = logger;
            _repo = repo;
            _repo1 = repo1;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<DeliveryExecutive> deliveryExecutives = _repo.GetAll().ToList();
            return View(deliveryExecutives);
        }
        public IActionResult ExecutivesList()
        {
            List<DeliveryExecutive> deliveryExecutives = _repo.GetAll().Where(a=>a.IsVerified=="Verified").ToList();
            return View(deliveryExecutives);
        }
        public IActionResult ExecutiveHomePage()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DeliveryExecutive deliveryExecutive)
        {
            deliveryExecutive.IsVerified = "Null";
            _repo.Add(deliveryExecutive);
            return RedirectToAction("MainHomePage", "User");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(DeliveryExecutive deliveryExecutive)
        {
            int id = _repo.Login(deliveryExecutive);
            try
            {
                if (id != 0)
                {
                    TempData["ExecutiveId"] = id;
                    //return RedirectToAction("PendingRequest");
                    return RedirectToAction("ExecutiveHomePage");
                }
            }
            catch (Exception e)

            {
                _logger.LogDebug(e.Message);

            }
            return RedirectToAction("Error");
        }

        public IActionResult PendingRequest()
        {
            int id = Convert.ToInt32(TempData.Peek("ExecutiveId"));
            List<Booking> booking = _repo1.GetAll().Where(a => a.ExecutiveId == id && a.Status == "Requested").ToList();
            if (booking.Count() != 0)
            {
                return View(booking);
            }
            else if (booking.Count() == 0)
            {
                return View("NoRequest");
            }
            return View();
        }

        public ActionResult Success()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
        public ActionResult NoRequest()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            DeliveryExecutive delivery = _repo.Get(id);
            return View(delivery);
        }
        [HttpPost]
        public IActionResult Edit(int id, DeliveryExecutive delivery)
        {
            _repo.Update(id, delivery);
            return RedirectToAction("Index");
        }
    }
}
       
      