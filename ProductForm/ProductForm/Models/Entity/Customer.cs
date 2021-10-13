using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductForm.Models.Entity
{
    public class Customer
    {
        public int CId { get; set; }
        public int Phone { get; set; }
        public string Password { get; set; }
    }
}