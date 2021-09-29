using ProductForm.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductForm.Models;
using System.Web.Script.Serialization;

namespace ProductForm.Controllers
{
    public class ProductController : Controller
    {
        public object Name { get; private set; }
        public object Price { get; private set; }
        public object Quantity { get; private set; }
        public object Description { get; private set; }

        public ActionResult Index()
        {
            Database db = new Database();
            var products = db.Products.GetAll();
            return View(products);
        }



        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                db.Products.Add(p);
                return RedirectToAction("Index");
            }
            return View();

        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            Database db = new Database();
            var p = db.Products.Get(id);
            return View(p);
        }


        [HttpPost]
        public ActionResult Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                db.Products.Edit(p);
                return RedirectToAction("Index");
            }
            return View();

        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            Database db = new Database();
            var p = db.Products.Get(id);
            return View(p);

        }

        [HttpPost]
        public ActionResult Delete(Product p)
        {
            Database db = new Database();
            db.Products.Delete(p);
            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult Cart(int id)
        {
            List<Product> products = null;

            Database db = new Database();
            var product = db.Products.Get(id);

            if (Session["cart"] == null)
            {

                products = new List<Product>();
                products.Add(product);
                string json = new JavaScriptSerializer().Serialize(products);
                Session["cart"] = json;
            }

            else
            {
                var item = Session["cart"];
                products = new JavaScriptSerializer().Deserialize<List<Product>>((string)item);
                products.Add(product);
                string json = new JavaScriptSerializer().Serialize(products);
                Session["cart"] = json;
            }
            return View(products);
        }


        [HttpPost]
        public ActionResult Cart()
        {
            List<Product> products = null;
            var item = Session["cart"];
            products = new JavaScriptSerializer().Deserialize<List<Product>>((string)item);


            Database db = new Database();
            db.Orders.AddToCart(products);

            Session["cart"] = null;

            return RedirectToAction("Index");

        }
    }
}