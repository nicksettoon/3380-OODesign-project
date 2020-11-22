using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace xCourse.Entities
{
    public class School
    {
        [Key]
        public string Name { get; set; }

        [Required]
        public string SchoolsCollege { get; set; }

        [Required]
        public string CourseCodeAbbriviation { get; set; }

        public School()
        {

        }

        public School(string _name, string _schoolsCollege, string _abbr)
        {
            Name = _name;
            SchoolsCollege = _schoolsCollege;
            CourseCodeAbbriviation = _abbr;
        }
    }
}
