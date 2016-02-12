using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Interfaces;

namespace Testing.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerManager _customerManager;

        public HomeController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        public ActionResult Index()
        {
            var xxx = _customerManager.GetAllCustomers();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}