using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentForm.Models.Entity
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Provide Name")]
        [MinLength(2, ErrorMessage = "Name Must be>2 Characters")]
        [MaxLength(10)]
        public string Name { get; set; }
        [Required]
        public string Dob { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]

        public float Cgpa { get; set; }
    }
}