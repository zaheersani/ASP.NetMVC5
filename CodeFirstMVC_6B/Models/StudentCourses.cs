using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeFirstMVC_6B.Models
{
    public class StudentCourses
    {
        public int ID { get; set; }

        public int StudentID { get; set; }

        public int CourseID { get; set; }

        [Display(Name = "Enrollment Date")]
        [DataType(DataType.Date)]
        public DateTime AssignedOn { get; set; }

        public Student StudentObj { get; set; }
        public Course CourseObj { get; set; }
    }
}