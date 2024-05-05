using Microsoft.AspNetCore.Mvc;
using Admin_Hotel.Models;

namespace Admin_Hotel.ViewComponents
{
    public class vcSideBar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
