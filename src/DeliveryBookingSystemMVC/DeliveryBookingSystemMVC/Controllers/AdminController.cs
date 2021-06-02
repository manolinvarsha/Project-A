using DeliveryBookingSystemMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryBookingSystemMVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Login(Login login)
        {
            if(login.Username=="Admin" && login.Password=="1234")
            {
                return RedirectToAction("AdminHomePage","Admin");
            }
            else
            {
                return View();
            }
           
        }
        public IActionResult AdminHomePage(User u)
        {
            if (u.UserType == "Customer")
            {
                return this.RedirectToAction("CustomerInfo", "Customers");
            }
            else if (u.UserType == "Executive")
            {
                return this.RedirectToAction("ExecutivesList", "DeliveryExecutives");
            }

           
            return View();
        }
    }
}
