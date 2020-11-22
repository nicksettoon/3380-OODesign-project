using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace xCourse.Entities
{
    public class Course
    {
        [Key]
        public int ID { get; set; }
        
        public string CourseCodeAbbriviation { get; set; }

       
        public int Number { get; set; }

        [Required]
        public int Hours { get; set; }

        public string Description { get; set; }

        public List<Course> Prerequisites { get; set; }

        public Course()
        {

        }

        public Course(string _abbriv, int _courseNumber, int _hours, string _description, List<Course> _prereqs)
        {
            CourseCodeAbbriviation = _abbriv;

            Number = _courseNumber; 

            Hours = _hours;

            Description = _description;

            Prerequisites = _prereqs;
        }
    }
}
