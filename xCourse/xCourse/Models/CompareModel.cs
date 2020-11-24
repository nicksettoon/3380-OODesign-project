using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xCourse.Models
{
    public class CompareModel
    {
        public List<string> DegreeName = new List<string> { "Computer Engineering", "Computer Science Second Discipline", "Electrical Engineering" };

        public string CompareDegree { get; set; }

        public string FirstDegreeNodes { get; set; }

        public string FirstDegreeLinks { get; set; }

        public string SecondDegreeNodes { get; set; }

        public string SecondDegreeLinks { get; set; }

    }
}
