using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using Business.Interfaces;
using Models;
using Newtonsoft.Json;
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

        [HttpPost]
        public JsonResult AddNewCustomer(CustomerViewModel customerViewModel)
        {
            string message;

            try
            {
                var customer = CreateCustomerFromViewModel(customerViewModel);
                _customerManager.AddNewCustomer(customer);
                message = JsonConvert.SerializeObject(new CustomerViewModel(customer));
            }
            catch (Exception ex)
            {
                message = "Error: " + ex.Message;
            }

            return Json(message, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateCustomer(CustomerViewModel customerViewModel)
        {
            string message = "";

            try
            {
                var customer = _customerManager.GetCustomerById(customerViewModel.CustomerId);
                customer.DateOfBirth = Convert.ToDateTime(customerViewModel.DateOfBirth);
                customer.FirstName = customerViewModel.FirstName;
                customer.LastName = customerViewModel.LastName;
                _customerManager.UpdateCustomer();

                message = JsonConvert.SerializeObject(new CustomerViewModel(customer));
            }
            catch (Exception ex)
            {
                message = "Error: " + ex.Message;
            }

            return Json(message, JsonRequestBehavior.AllowGet);
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

        private IEnumerable<CustomerViewModel> GetViewModelsForAllCustomers()
        {
            var allCustomers = _customerManager.GetAllCustomers();
            return allCustomers.Select(customer => new CustomerViewModel(customer)).ToList();
        }

        private static Customer CreateCustomerFromViewModel(CustomerViewModel customerViewModel)
        {
            return new Customer
            {
                FirstName = customerViewModel.FirstName,
                LastName = customerViewModel.LastName,
                DateOfBirth = Convert.ToDateTime(customerViewModel.DateOfBirth)
            };
        }
    }
}