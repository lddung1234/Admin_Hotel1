using Admin_Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Admin_Hotel.Controllers
{
    public class HomeController : Controller
    {

        [Route("", Name = "Home")]
        public IActionResult Index(string fullName)
        {
            ViewBag.nameAction = "home";
            return View();
        }

    }
}
