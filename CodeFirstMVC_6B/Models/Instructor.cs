using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstMVC_6B.Models
{
    public class Instructor
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Designation { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}