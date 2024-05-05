using Admin_Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Admin_Hotel.Controllers
{
    public class SalaryController : Controller
    {
        [Route("/salary",Name ="Salary")]
        public IActionResult Index()
        {
            ViewBag.nameAction = "Salary";
            return View();
        }
        [Route("/salary-slip", Name = "SalarySlip")]
        public IActionResult SalarySlip()
        {
            ViewBag.nameAction = "SalarySlip";
            return View();
        }
		[Route("/salary-add", Name = "SalaryAdd")]
		public IActionResult SalaryAdd()
		{
			ViewBag.nameAction = "Salary";
			return View();
		}
	}
}
