﻿using ProductForm.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductForm.Models;

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


        [HttpPost]
        public ActionResult Delete(Product p)
        {
            Database db = new Database();
            db.Products.Delete(p);
            return View();

        }
    }
}