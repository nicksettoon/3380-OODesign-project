using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xCourse.Entities
{
    public class School
    {
        public string Name { get; set; }

        public College SchoolsCollege { get; set; }

        public string CourseCodeAbbriviation { get; set; }
    }
}
