using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static xCourse.Data.xCourseContext;

namespace xCourse.Entities
{
    public class Semester
    {
        public int SemesterId { get; set; }

        public virtual List<DegreeSemester> DegreeSemesters { get; set; }

        public virtual List<SemesterCourse> SemesterCourses { get; set; }

        /*public int getTotalHours()
        {
            int hours = 0;
            foreach (var course in Courses)
            {
                hours += course.Hours;
            }

            return hours;
        }*/
    }
}
