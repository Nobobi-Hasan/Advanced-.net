using ProductForm.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProductForm.Models
{
    public class Database
    {
        public Products Products { get; set; }

        public Orders Orders{ get; set; }

        public Customers Customers { get; set; }

        public Database()
        {
            string connString = @"Server=DESKTOP-45823CR\SQLEXPRESS;Database=PMS;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connString);
            Products = new Products(conn);
            Orders = new Orders(conn);
            Customers = new Customers(conn);

        }

    }
}