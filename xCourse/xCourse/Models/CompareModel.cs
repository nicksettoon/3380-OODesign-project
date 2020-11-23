using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xCourse.Models
{
    public class CompareModel
    {
        public List<string> DegreeName = new List<string> { "Computer Engineering", "Computer Science Second Discipline" };

        public string CompareDegree { get; set; }

        public string firstDegreeNodes { get; set; }

        public string firstDegreeLinks { get; set; }

        public string secondDegreeNodes { get; set; }

        public string secondDegreeLinks { get; set; }

    }
}
