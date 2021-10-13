using ProductForm.Models;
using ProductForm.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ProductForm.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(Customer c)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                Customer customer = db.Customers.Validate(c);
                if(customer != null)
                {


                    string json = new JavaScriptSerializer().Serialize(customer);
                    Session["user"] = json;

                    return RedirectToAction("Index", "Product");
                }
                
            }
            return View();

        }
    }
}