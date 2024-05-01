using Assignment_2_NEW.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_2_NEW.Controllers
{
    public class ProductListController : Controller
    {
        private readonly AssignmentDatabaseContext _Context;

        public ProductListController(AssignmentDatabaseContext Context)
        {
            _Context = Context;
        }
        public IActionResult Index()
        {
            ProductList2Cart Getter = new ProductList2Cart();
            ViewBag.Products = Getter.FindAll();
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
