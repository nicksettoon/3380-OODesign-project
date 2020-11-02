using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xCourse.Entities
{
    public class Semester
    {
        LinkedList<Course> Courses { get; set; }

        public int getTotalHours()
        {
            int hours = 0;
            foreach (var course in Courses)
            {
                hours += course.Hours;
            }

            return hours;
        }
    }
}
