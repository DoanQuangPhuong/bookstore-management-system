using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using MvcApplication2.Models;

namespace MvcApplication2.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        HTQLNSEntities1 db = new HTQLNSEntities1();
        public ActionResult Index(string search = "", string sortColumn = "", string IconClass = "", int page = 1)
        {
            List<tb_SACH> ds = db.tb_SACH.Where(row => row.TenSach.Contains(search)).ToList();
            ViewBag.Search = search;

            ViewBag.IconClass = IconClass;
            if (sortColumn == "Gia")
            {
                if(IconClass == "Giam")
                {
                    ds = ds.OrderBy(row => row.Gia).ToList();
                }
                else
                {
                    ds = ds.OrderByDescending(row => row.Gia).ToList();
                }
            }

            int NoOfRecordPerPage = 12;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(ds.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;//Số trang
            ds = ds.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();

            return View(ds);
        }

        public ActionResult Detail(int id)
        {
            tb_SACH sach = db.tb_SACH.Where(row => row.MaSach == id).FirstOrDefault();

            return View(sach);
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            // Extract the username from the form
            string username = form["username"];

            // Fetch the user account based on the username
            tb_TaiKhoan tk = db.tb_TaiKhoan.Where(row => row.Email.Equals(username)).FirstOrDefault();

            if (tk != null) // Check if the user exists
            {
                if (tk.Quyen == "Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                // Handle the case where the user is not found
                // For example, redirect to a login page with an error message
                return RedirectToAction("Login", new { errorMessage = "User not found" });
            }

        }
        public ActionResult register()
        {
            return View();
        }
       
        public ActionResult AddToCart(CartItem s)
        {
            List<CartItem> cart = Session["Cart"] as List<CartItem>;

            if (cart == null)
            {
                cart = new List<CartItem>();
            }

            var existingItem = cart.Find(item => item.Masach == s.Masach);

            if (existingItem != null)
            {
                existingItem.Soluong += 1;
            }
            else
            {
                cart.Add(new CartItem { Masach = s.Masach, TenSach = s.TenSach, Gia = s.Gia, Image = s.Image ,Soluong = 1});
            }

            Session["Cart"] = cart;
            return View();
        }


        public ActionResult Cart()
        {
            List<CartItem> Cart = Session["Cart"] as List<CartItem>;
            return View(Cart);
        }
    }
}
