using StudentForm.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using StudentForm.Models;

namespace StudentForm.Controllers
{
    public class StudentController : Controller
    {
        public object Name { get; private set; }
        public object Dob { get; private set; }
        public object Gender { get; private set; }

        // GET: Student
        public ActionResult Index()
        {
            Database db = new Database();
            var students = db.Students.GetAll();
            return View(students);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s){

            if(ModelState.IsValid)
            {
                Database db = new Database();
                db.Students.Add(s);
                return RedirectToAction("Index");
            }
            return View();
            
        }
    }
}