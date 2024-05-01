using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment_2_NEW.Models;
using Newtonsoft.Json.Schema;

namespace Assignment_2_NEW.Controllers
{
    public class CartsController : Controller
    {
        // GET: Carts
        public IActionResult Index()
        {
            var CartCurrent = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "CartCurrent");
            ViewBag.CartCurrent = CartCurrent;
            if (HttpContext.Session.GetInt32("CurrentSession") == 606)
            {
                if (CartCurrent != null)
                {
                    ViewBag.Total = CartCurrent.Sum(Itm => Itm.Product?.Price * Itm.Quantity);
                }
                return View();
            }
            else
            {
                return RedirectToAction("Customer", "Login");
            }
        }

        public IActionResult Buy(string ItemID)
        {
            ProductList2Cart Getter = new ProductList2Cart();
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "CartCurrent") == null)
            {
                List<Item> CartCurrent = new List<Item>();
                CartCurrent.Add(new Item { Product = Getter.Find(ItemID), Quantity = 1 });

                SessionHelper.SetObjectAsJson(HttpContext.Session, "CartCurrent", CartCurrent);
            }
            else
            {
                List<Item>? CartCurrent = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "CartCurrent");
                int FindIndex = Coexists(ItemID);
                if (FindIndex != -1)
                {
                    if (CartCurrent != null)
                    {
                        CartCurrent[FindIndex].Quantity++;
                    }
                }
                else
                {
                    if (CartCurrent != null)
                    {
                        CartCurrent.Add(new Item { Product = Getter.Find(ItemID), Quantity = 1 });
                    }
                }
                if (CartCurrent != null)
                {
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "CartCurrent", CartCurrent);
                }
            }
            if (HttpContext.Session.GetInt32("CurrentSession") == 606)
            {
                return RedirectToAction("Index", "Carts");
            }
            else
            {
                return RedirectToAction("Customer", "Login");
            }
        }

        public IActionResult DeleteItem(string ItemID)
        {
            List<Item>? CartCurrent = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "CartCurrent");
            int ListIndex = Coexists(ItemID);
            if (CartCurrent != null)
            {
                CartCurrent.RemoveAt(ListIndex);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "CartCurrent", CartCurrent);
            }
            if (HttpContext.Session.GetInt32("CurrentSession") == 606)
            {
                return RedirectToAction("Index", "Carts");
            }
            else
            {
                return RedirectToAction("Customer", "Login");
            }
        }

        private int Coexists(string ItemID)
        {
            List<Item>? CartCurrent = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "CartCurrent");
            if (CartCurrent != null)
            {
                for (int Index = 0; Index < CartCurrent.Count; Index++)
                {

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    if (CartCurrent[Index].Product.ProductId == ItemID)
                    {
                        return Index;
                    }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                }
            }
                return -1;
        }
    }
}
