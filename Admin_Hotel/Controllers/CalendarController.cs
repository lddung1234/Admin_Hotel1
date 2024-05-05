using Admin_Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Admin_Hotel.Controllers
{
    public class CalendarController : Controller
    {
        [Route("/calendar",Name ="Calendar")]
        public IActionResult Index()
        {
           
            ViewBag.nameAction = "calendar";
            return View();
        }

    }
}
