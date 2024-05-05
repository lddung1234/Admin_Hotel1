using Admin_Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Admin_Hotel.Controllers
{
    public class BookingController : Controller
    {
        [Route("/booking",Name ="HomeBooking")]
        public IActionResult Index()
        {
           
            ViewBag.nameAction = "HomeBooking";
            return View();
        }
        [Route("/booking-edit", Name = "EditBooking")]
        public IActionResult Edit()
        {
            
            ViewBag.nameAction = "EditBooking";
            return View();
        }
        [Route("/booking-add", Name = "AddBooking")]
        public IActionResult Add()
        {
            
            ViewBag.nameAction = "AddBooking";
            return View();
        }
    }
}
