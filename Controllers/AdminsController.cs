using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment_2_NEW.Models;

namespace Assignment_2_NEW.Controllers
{
    public class AdminsController : Controller
    {
        private readonly AssignmentDatabaseContext _context;

        public AdminsController(AssignmentDatabaseContext context)
        {
            _context = context;
        }

        // GET: Admins
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("CurrentSession") == 909)
            {
                return View(await _context.Admins.ToListAsync());
            }
            else
            {
                return RedirectToAction("Admin", "Login");
            }
        }

        // GET: Admins/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins
                .FirstOrDefaultAsync(m => m.AdminId == id);
            if (admin == null)
            {
                return NotFound();
            }

            if (HttpContext.Session.GetInt32("CurrentSession") == 909)
            {
                return View(admin);
            }
            else
            {
                return RedirectToAction("Admin", "Login");
            }
        }

        // GET: Admins/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("CurrentSession") == 909)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Admin", "Login");
            }
        }

        // POST: Admins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdminId,AdminRealName,AdminDob,AdminEmail,AdminPassword")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(admin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            if (HttpContext.Session.GetInt32("CurrentSession") == 909)
            {
                return View(admin);
            }
            else
            {
                return RedirectToAction("Admin", "Login");
            }
        }

        // GET: Admins/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            if (HttpContext.Session.GetInt32("CurrentSession") == 909)
            {
                return View(admin);
            }
            else
            {
                return RedirectToAction("Admin", "Login");
            }
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AdminId,AdminRealName,AdminDob,AdminEmail,AdminPassword")] Admin admin)
        {
            if (id != admin.AdminId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminExists(admin.AdminId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            if (HttpContext.Session.GetInt32("CurrentSession") == 909)
            {
                return View(admin);
            }
            else
            {
                return RedirectToAction("Admin", "Login");
            }
        }

        // GET: Admins/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins
                .FirstOrDefaultAsync(m => m.AdminId == id);
            if (admin == null)
            {
                return NotFound();
            }

            if (HttpContext.Session.GetInt32("CurrentSession") == 909)
            {
                return View(admin);
            }
            else
            {
                return RedirectToAction("Admin", "Login");
            }
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var admin = await _context.Admins.FindAsync(id);
            if (admin != null)
            {
                _context.Admins.Remove(admin);
            }

            await _context.SaveChangesAsync();
            if (HttpContext.Session.GetInt32("CurrentSession") == 909)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("Admin", "Login");
            }
        }

        private bool AdminExists(string id)
        {
            return _context.Admins.Any(e => e.AdminId == id);
        }
    }
}
