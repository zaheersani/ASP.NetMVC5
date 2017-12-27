using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstMVC_6B.Models
{
    public class Course
    {
        public int ID { get; set; }

        [MaxLength(6)]
        public string Code { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Instructor> Instructors { get; set; }
    }
}