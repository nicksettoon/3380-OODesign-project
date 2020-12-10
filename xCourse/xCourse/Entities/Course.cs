using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static xCourse.Data.xCourseContext;

namespace xCourse.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        
        public string CourseCodeAbbriviation { get; set; }
       
        public string Number { get; set; }

        public int Hours { get; set; }

        public string Description { get; set; }

        public virtual List<SemesterCourse> SemesterCourses { get; set; }

        public virtual List<UserCourse> UserCourses { get; set; }

        public virtual List<Prerequisite> Prerequisites { get; set; }

        public virtual List<Prerequisite> PrereqFor { get; set; }
    }
}
