using Admin_Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Admin_Hotel.Controllers
{
    public class PricingController : Controller
    {
        [Route("/pricing",Name ="HomePricing")]
        public IActionResult Index()
        {
            ViewBag.nameAction = "HomePricing";
            return View();
        }
        [Route("/pricing-add", Name = "AddPricing")]
        public IActionResult Add()
        {
            ViewBag.nameAction = "AddPricing";
            return View();
        }
        [Route("/pricing-edit", Name = "EditPricing")]
        public IActionResult Edit()
        {
            ViewBag.nameAction = "EditPricing";
            return View();
        }
    }
}
