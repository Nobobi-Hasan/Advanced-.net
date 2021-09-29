using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductForm.Models.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}