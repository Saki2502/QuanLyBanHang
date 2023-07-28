using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBHNguyenDangTuyetNhi.Controllers
{
    public class ProductController : Controller
    {
        NorthwindDataContext da = new NorthwindDataContext();

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        // GET: Product
        public ActionResult ListProduct()
        {
            //Query Syntax
            //List<Product> listP = (From p in da.Products Select p).ToList();
            //Method Syntax
            List<Product> listP = da.Products.ToList();
            return View(listP);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            Product p = da.Products.FirstOrDefault(q => q.ProductID == id);
            return View(p);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewData["NCC"] = new SelectList(da.Suppliers, "SupplierID", "CompanyName");
            ViewData["LSP"] = new SelectList(da.Categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product, FormCollection collection)
        {
            try
            {
                Product p = new Product();
                p = product;

                p.CategoryID = int.Parse(collection["LSP"]);
                p.SupplierID = int.Parse(collection["NCC"]);

                da.Products.InsertOnSubmit(p);
                da.SubmitChanges();

                return RedirectToAction("ListProduct");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            Product p = da.Products.FirstOrDefault(s => s.ProductID == id);
            ViewData["NCC"] = new SelectList(da.Suppliers, "SupplierID", "CompanyName", p.SupplierID);
            ViewData["LSP"] = new SelectList(da.Categories, "CategoryID", "CategoryName", p.CategoryID);

            return View(p);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product, FormCollection collection)
        {
            try
            {
                Product p = da.Products.FirstOrDefault(s => s.ProductID == product.ProductID);

                p.ProductName = product.ProductName;
                p.QuantityPerUnit = product.QuantityPerUnit;
                p.UnitPrice = product.UnitPrice;
                p.UnitsInStock = product.UnitsInStock;
                p.UnitsOnOrder = product.UnitsOnOrder;
                p.SupplierID = int.Parse(collection["NCC"]);
                p.ReorderLevel = product.ReorderLevel;
                p.CategoryID = int.Parse(collection["LSP"]);

                da.SubmitChanges();

                return RedirectToAction("ListProduct");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            Product p = da.Products.FirstOrDefault(s => s.ProductID == id);


            return View(p);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Product p = da.Products.First(s => s.ProductID == id);
                da.Products.DeleteOnSubmit(p);

                da.SubmitChanges();

                return RedirectToAction("ListProduct");
            }
            catch
            {
                return View();
            }
        }
    }
}
