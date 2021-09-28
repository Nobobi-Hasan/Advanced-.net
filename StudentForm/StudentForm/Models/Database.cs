using StudentForm.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentForm.Models
{
    public class Database
    {
        public Students Students { get; set; }
        //public Courses courses { get; set; }

        public Database()
        {
            string connString = @"Server=DESKTOP-45823CR\SQLEXPRESS;Database=UMS;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connString);
            Students = new Students(conn);
            //Courses = new Courses();

        }
    }
}