using Admin_Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Admin_Hotel.Controllers
{
    public class RoomsController : Controller
    {
        [Route("/rooms",Name ="HomeRooms")]
        public IActionResult Index()
        {
            ViewBag.nameAction = "HomeRooms";
            return View();
        }
        [Route("/rooms-edit", Name = "EditRooms")]
        public IActionResult Edit()
        {
            ViewBag.nameAction = "EditRooms";
            return View();
        }
        [Route("/rooms-add", Name = "AddRooms")]
        public IActionResult Add()
        {
            ViewBag.nameAction = "AddRooms";
            return View();
        }
    }
}
