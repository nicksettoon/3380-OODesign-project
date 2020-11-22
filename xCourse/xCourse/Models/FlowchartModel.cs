using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using xCourse.Entities;

namespace xCourse.Models
{
    public class FlowchartModel
    {   
        [Key]
        public string CourseCodeAbbriviation { get; set; }
        public Degree Degree { get; set; }
    }
}
