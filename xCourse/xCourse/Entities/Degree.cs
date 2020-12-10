using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static xCourse.Data.xCourseContext;

namespace xCourse.Entities
{
    public class Degree
    {   
        public int DegreeId { get; set; }
        public string DegreeAbbriviation { get; set; }
        public string Major { get; set; }

        public virtual List<DegreeSemester> DegreeSemesters { get; set; }
    }
}
