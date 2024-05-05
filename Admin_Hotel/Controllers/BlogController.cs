using Admin_Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Admin_Hotel.Controllers
{
    public class BlogController : Controller
    {
        [Route("/blog",Name ="HomeBlog")]
        public IActionResult Index()
        {
            
            ViewBag.nameAction = "HomeBlog";
            return View();
        }
        [Route("/blog-add", Name = "AddBlog")]
        public IActionResult Add()
        {
            
            ViewBag.nameAction = "AddBlog";
            return View();
        }
        [Route("/blog-edit", Name = "EditBlog")]
        public IActionResult Edit()
        {
           
            ViewBag.nameAction = "EditBlog";
            return View();
        }
        [Route("/blog-detail", Name = "DetailBlog")]
        public IActionResult Detail()
        {
          
            ViewBag.nameAction = "HomeBlog";
            return View();
        }
    }
}
