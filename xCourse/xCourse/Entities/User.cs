using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace xCourse.Entities
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string DeegreeAbbriv { get; set; }

        [Required]
        public List<Course> PreviouslyTakenCourses { get; set; }
    }
}