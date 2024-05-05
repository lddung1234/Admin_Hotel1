using Admin_Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Admin_Hotel.Controllers
{
    public class StaffController : Controller
    {
        [Route("/staff",Name ="HomeStaff")]
        public IActionResult Index()
        {
            ViewBag.nameAction = "HomeStaff";
            return View();
        }
        [Route("/staff-add", Name = "AddStaff")]
        public IActionResult Add()
        {
            ViewBag.nameAction = "AddStaff";
            return View();
        }
        [Route("/staff-edit", Name = "EditStaff")]
        public IActionResult Edit()
        {
            ViewBag.nameAction = "EditStaff";
            return View();
        }
    }
}
