using Microsoft.AspNetCore.Mvc;

namespace Assignment_2_NEW.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Admin()
        {
            ViewBag.NameAdmin = HttpContext.Session.GetString("NameAdmin");
            if (HttpContext.Session.GetInt32("CurrentSession") == 909)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Admin", "Login");
            }
        }

        public IActionResult Customer()
        {
            ViewBag.NameCustomer = HttpContext.Session.GetString("NameCustomer");
            if (HttpContext.Session.GetInt32("CurrentSession") == 606)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Customer", "Login");
            }
        }
    }
}
