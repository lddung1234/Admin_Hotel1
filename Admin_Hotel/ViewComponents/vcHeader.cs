using Microsoft.AspNetCore.Mvc;
using Admin_Hotel.Models;

namespace Admin_Hotel.ViewComponents
{
    public class vcHeader : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
