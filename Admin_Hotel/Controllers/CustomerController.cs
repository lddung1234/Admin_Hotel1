using Admin_Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Admin_Hotel.Controllers
{
    public class CustomerController : Controller
    {
        [Route("/customer",Name ="HomeCustomer")]
        public IActionResult Index()
        {
            
            ViewBag.nameAction = "HomeCustomer";
            return View();
        }
        [Route("/customer-edit", Name = "EditCustomer")]
        public IActionResult Edit()
        {
            ViewBag.nameAction = "EditCustomer";
            return View();
        }
        [Route("/customer-add", Name = "AddCustomer")]
        public IActionResult Add()
        {
            ViewBag.nameAction = "AddCustomer";
            return View();
        }
    }
}
