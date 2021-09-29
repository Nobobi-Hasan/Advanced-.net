using ProductForm.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProductForm.Models.Tables
{
    public class Orders
    {
        SqlConnection conn;

        public Orders(SqlConnection conn)
        {
            this.conn = conn;
        }

        public void AddToCart(List<Product> products)
        {

            foreach (var p in products)
            {
                string query = String.Format("Insert into Orders values ('{0}',{1}, {2}, '{3}', {4})", p.Name, p.Price, p.Quantity, p.Description, 0);
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                int r = cmd.ExecuteNonQuery();
                conn.Close();
            }


        }
    }
}