using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeFirstMVC_6B.Models
{
    public class Student
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Registration No")]
        public string RollNo { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        //[DataType()]
        public City PresentCity { get; set; }
    }

    public enum City { Islamabad, Lahore, Karachi }
}