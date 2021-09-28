using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductForm.Models.Entity
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Provide Name")]
        [MinLength(2, ErrorMessage = "Name Must be>2 Characters")]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]

        public string Description { get; set; }
    }
}