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

        public void AddToCart(List<Product> products, Customer user)
        {

            foreach (var p in products)
            {
                string query = String.Format("Insert into Orders values ('{0}',{1}, {2}, '{3}', {4})", p.Name, p.Price, p.Quantity, p.Description, user.CId);
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                int r = cmd.ExecuteNonQuery();
                conn.Close();
            }


        }

        public List<Order> Get(int id)
        {

            string query = String.Format("select * from Orders where UserId = {0}", id);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            List<Order> orders = new List<Order>();

            while (reader.Read())
            {
                Order o = new Order()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Price = (float)reader.GetDouble(reader.GetOrdinal("Price")),
                    Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                };

                orders.Add(o);

            };
            conn.Close();
            return orders;
        }
    }
}