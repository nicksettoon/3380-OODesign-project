using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace xCourse.Entities
{
    public class Semester
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public List<Course> Courses { get; set; }

        public int getTotalHours()
        {
            int hours = 0;
            foreach (var course in Courses)
            {
                hours += course.Hours;
            }

            return hours;
        }

        public Semester()
        {

        }

        public Semester(int _id, List<Course> _courses)
        {
            ID = _id;
            Courses = _courses;
        }
    }
}
