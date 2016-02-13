using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using Business.Interfaces;
using Models;
using Testing.ViewModels;

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
            var customerViewModels = GetViewModelsForAllCustomers();
            return View(customerViewModels);
        }

        private IEnumerable<CustomerViewModel> GetViewModelsForAllCustomers()
        {
            var allCustomers = _customerManager.GetAllCustomers();
            return allCustomers.Select(customer => new CustomerViewModel(customer)).ToList();
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