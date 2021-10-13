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
    public class OrderController : Controller
    {
        public ActionResult Order()
        {
            Customer user = null;

            var u = Session["user"];

            user = new JavaScriptSerializer().Deserialize<Customer>((string)u);

            List<Order> order = null;

            Database db = new Database();
            order = db.Orders.Get(user.CId);

           
            return View(order);
        }
    }
}