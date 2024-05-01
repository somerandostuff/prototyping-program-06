using Assignment_2_NEW.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Logging;
using Microsoft.EntityFrameworkCore;

namespace Assignment_2_NEW.Controllers
{
    public class LoginController : Controller
    {
        private readonly AssignmentDatabaseContext _context;

        public LoginController(AssignmentDatabaseContext context)
        {
            _context = context;
        }


        public IActionResult Customer()
        {
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Admin([Bind("AdminId,AdminPassword")] Admin Assmin)
        {
            if (ModelState.IsValid)
            {
                var TargetAcc = await _context.Admins.Where(Target => Target.AdminId.Equals(Assmin.AdminId)).FirstOrDefaultAsync();
                if (TargetAcc != null && TargetAcc.AdminPassword == Assmin.AdminPassword)
                {
                    HttpContext.Session.SetString("NameAdmin", TargetAcc.AdminRealName.ToString());
                    HttpContext.Session.SetInt32("CurrentSession", 909);
                    return RedirectToAction("Admin", "Home");
                }
                else
                {
                    ViewData["Notification"] = "Sai thông tin đăng nhập!";
                    return RedirectToAction(nameof(Admin));
                }
            }
            else
            {
                ViewData["Notification"] = "Bạn chưa nhập gì!";
                return RedirectToAction(nameof(Admin));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Customer([Bind("CustomerId,CustomerPassword")] Customer CustomerAcc)
        {
            if (ModelState.IsValid)
            {
                var TargetAcc = await _context.Customers.Where(Target => Target.CustomerId.Equals(CustomerAcc.CustomerId)).FirstOrDefaultAsync();
                if (TargetAcc != null && TargetAcc.CustomerPassword == CustomerAcc.CustomerPassword)
                {
                    HttpContext.Session.SetString("NameCustomer", TargetAcc.CustomerRealName.ToString());
                    HttpContext.Session.SetInt32("CurrentSession", 606);
                    return RedirectToAction("Customer", "Home");
                }
                else
                {
                    ViewData["Notification"] = "Sai thông tin đăng nhập!";
                    return RedirectToAction(nameof(Customer));
                }
            }
            else
            {
                ViewData["Notification"] = "Bạn chưa nhập gì!";
                return RedirectToAction(nameof(Customer));
            }
        }
    }
}
