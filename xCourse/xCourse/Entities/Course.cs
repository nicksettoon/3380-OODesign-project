using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xCourse.Entities
{
    public class Course
    {
        public School CourseSchool { get; set; }

        public int Number { get; set; }

        public int Hours { get; set; }

        public string Description { get; set; }

        public LinkedList<Course> Prerequisites { get; set; }
    }
}
