using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xCourse.Models
{
    public class PlanModel
    {
        public string Degree { get; set; }
        
        public PlanModel(string _Degree)
        {
            Degree = _Degree;
        }
    }
}
