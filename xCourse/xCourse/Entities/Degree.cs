using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace xCourse.Entities
{
    public class Degree
    {   

        [Key]
        public string DegreeAbbriviation { get; set; }
        public string Major { get; set; }

        public List<Semester> Semesters { get; set; }

    }
}
