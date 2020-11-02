using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xCourse.Entities
{
    public class Degree
    {   
        public string Major { get; set; }

        public LinkedList<Semester> Semesters { get; set; }

    }
}
