using DeliveryBookingSystemMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryBookingSystemMVC.Controllers
{
    public class UserController : Controller
    {
        public ActionResult MainHomePage()
        {
            return View();
        }
        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Register(User u)
        {
            if (u.UserType == "Customer")
            {
                return this.RedirectToAction("Create", "Customers");
            }
            else if (u.UserType == "Executive")
            {
                return this.RedirectToAction("Create", "DeliveryExecutives");
            }
            return View();
        }
        public ActionResult Login(User u)
        {
            if (u.UserType == "Customer")
            {
                return this.RedirectToAction("Login", "Customers");
            }
            else if (u.UserType == "Executive")
            {
                return this.RedirectToAction("Login", "DeliveryExecutives");
            }

            else if (u.UserType == "Admin")
            {
                return this.RedirectToAction("Login", "Admin");
            }
            return View();
        }
        //public ActionResult AdminLogin(Login user)
        //{
        //    if (user.Username == " admin" && user.Password == "admin1234")
        //    {
        //        return this.RedirectToAction("Login", "Customer");
        //    }
        //    else
        //    {
        //        return View();

        //    }
        //}
    }
}





