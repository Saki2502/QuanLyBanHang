using QLBHNguyenDangTuyetNhi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBHNguyenDangTuyetNhi.Controllers
{
    public class CartController : Controller
    {
        private List<CartModels> GetListCart()
        {
            List<CartModels> carts = Session["CartModels"] as List<CartModels>;
            if(carts==null)
            {
                carts = new List<CartModels>();
                Session["CartModels"] = carts;
            }
            return carts;
        }

        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        // GET: ListProduct in Cart
        public ActionResult ListCarts()
        {
            List<CartModels> carts = GetListCart();

            ViewBag.CountProduct = carts.Sum(s => s.Quantity);
            ViewBag.Total = carts.Sum(s => s.Total);

            return View(carts);
        }

        // Hàm thêm sản phẩm vào giỏ hàng
        public ActionResult AddCart(int id)
        {
            List<CartModels> carts = GetListCart();
            CartModels c = carts.Find(s => s.ProductID == id);
            if (c==null)
            {
                c = new CartModels(id);
                carts.Add(c);
            }
            else
            {
                c.Quantity++;
            }
            

            return RedirectToAction("ListCarts");
        }
    }
}