using ProductForm.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProductForm.Models.Tables
{
    public class Customers
    {
        SqlConnection conn;

        public Customers(SqlConnection conn)
        {
            this.conn = conn;
        }


        public void Add(Customer c)
        {
            string query = String.Format("Insert into Customers values ({0},'{1}')", c.Phone, c.Password);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }

        public Customer Validate(Customer c)
        {

            conn.Open();
            string query = String.Format("Select * from Customers where Phone={0} and Password = '{1}'", c.Phone, c.Password);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Customer customer = null;
            while (reader.Read())
            {
                customer = new Customer()
                {
                    CId = reader.GetInt32(reader.GetOrdinal("CId")),
                    Phone = reader.GetInt32(reader.GetOrdinal("Phone")),
                    Password = reader.GetString(reader.GetOrdinal("Password")),
                };
            }
            conn.Close();
            return customer;
        }
    }
}