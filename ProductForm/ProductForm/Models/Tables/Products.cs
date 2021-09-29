using ProductForm.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProductForm.Models.Tables
{
    public class Products
    {
        SqlConnection conn;

        public Products(SqlConnection conn)
        {
            this.conn = conn;
        }


        public void Add(Product p)
        {
            string query = String.Format("Insert into Products values ('{0}','{1}','{2}', '{3}')", p.Name, p.Price, p.Quantity, p.Description);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Delete(Product p)
        {
            string query = String.Format("Delete from Products where Id = {0}", p.Id);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }


        public Product Get(int id)
        {

            conn.Open();
            string query = String.Format("Select * from Products where Id={0}", id);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Product p = null;
            while (reader.Read())
            {
                p = new Product()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Price = (float)reader.GetDouble(reader.GetOrdinal("Price")),
                    Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                };
            }
            conn.Close();
            return p;
        }


        public void Edit(Product p)
        {

            string query = String.Format("Update Products  SET Name = '{0}', Price = {1}, Quantity = {2}, Description = '{3}' where Id={4}", p.Name, p.Price, p.Quantity, p.Description, p.Id);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }


        public List<Product> GetAll()
        {
            string query = String.Format("select * from Products");
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            List<Product> products = new List<Product>();

            while (reader.Read())
            {
                Product p = new Product()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Price = (float)reader.GetDouble(reader.GetOrdinal("Price")),
                    Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                };

                products.Add(p);

            };
            conn.Close();
            return products;
        }


    }
    
}