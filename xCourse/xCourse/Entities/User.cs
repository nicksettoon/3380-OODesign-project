using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static xCourse.Data.xCourseContext;

namespace xCourse.Entities
{
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string DegreeAbbrev { get; set; }

        public virtual List<UserCourse> UserCourses { get; set; }
    }
}