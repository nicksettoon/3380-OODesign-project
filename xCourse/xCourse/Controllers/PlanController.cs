using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using xCourse.Entities;
using xCourse.Models;

namespace xCourse.Controllers
{
    public class PlanController : Controller
    {
        public IActionResult Index(string CourseAbbrev)
        {
            if (CourseAbbrev == null)
            {
                return View(new PlanModel("Select a major", "", ""));
            }
            using (var context = new FlowchartContext())
            {
                var DegreeList = context.Degree
                    .Include(degree => degree.Semesters)
                        .ThenInclude(semsester => semsester.Courses)
                        .ThenInclude(course => course.Prerequisites)
                    .ToList();


                string nodes = "";

                string links = "";



                foreach (var degree in DegreeList)
                {
                    if (degree.DegreeAbbriviation.Equals(CourseAbbrev))
                    {
                        int semesterCounter = 7;
                        foreach (var semester in degree.Semesters)
                        {
                            foreach (var course in semester.Courses)
                            {
                                if (course.Prerequisites != null)
                                {
                                    foreach (var prereq in course.Prerequisites)
                                    {
                                        links += $"{{ to: \"{course.CourseCodeAbbriviation} {course.Number}\", from: \"{prereq.CourseCodeAbbriviation} {prereq.Number}\"}}, ";

                                        
                                    }
                                    
                                }

                                nodes += $"{{ key: \"{course.CourseCodeAbbriviation} {course.Number}\", items: [ \"({course.Hours})\", \"{course.CourseCodeAbbriviation} {course.Number}\", \"{course.Description}\"], layer: {semesterCounter} }}, ";

                                
                            }

                            semesterCounter--;
                        }
                    }
                }

                nodes = nodes.Remove(nodes.Length - 1, 1);
                links = links.Remove(links.Length - 1, 1);

                return View("Index", new PlanModel("Computer Science - Software Engineering", nodes, links));
            }

            //var computerScience = new School("Computer Science", "Engineering", "CSC");
            //var nodes = new List<Course>() { new Course(computerScience, 1350, 4, "Intro CS I for Majors", null) };

            //string nodeStrings = "{key: \"CSC 1350\", items: [\"(4)\", \"CSC 1350\", \"Intro CS I for Majors\"], layer: 7 },{key: \"MATH 1550\", items: [\"(5)\", \"MATH 1550\", \"Calc I\"], layer: 7 },{key: \"ENGL 1001\", items: [\"(3)\", \"ENGL 1001\", \"Comp I\"], layer:  7},{key: \"BIOL\", items: [\"(3)\", \"BIOL\", \"Sequence I\"], layer:  7},{key: \"CSC 1351\", items: [\"(4)\", \"CSC 1351\", \"Intro CS II for Majors\"], layer: 6 },{key: \"MATH 1552\", items: [\"(4)\", \"MATH 1552\", \"Calc II\"], layer:  6},{key: \"ENGL OR HNRS\", items: [\"(3)\", \"Gen Ed Hum\", \"ENGL or HNRS 2000+\"], layer:  6},{key: \"Physical Sci.\", items: [\"(3)\", \"Physical Sci.\", \"(restricted list)\"], layer:  6},{key: \"Science Seq Lab I\", items: [\"(1)\", \"Science Sequence\", \"I or II Lab\"], layer:  6},{key: \"CSC 3102\", items: [\"(3)\", \"CSC 3102\", \"Adv Data Str\"], layer: 5 },{key: \"CSC 2259\", items: [\"(3)\", \"CSC 2259\", \"Discrete Structures\"], layer: 5 },{key: \"MATH 2090\", items: [\"(4)\", \"MATH 2090\", \"DE & Lin Alg\"], layer:  5},{key: \"GEN ED\", items: [\"(3)\", \"Gen Ed\", \"Humanity\"], layer:  5},{key: \"Physical Sci. II\", items: [\"(3)\", \"Science Sequence II\", \"Requirement\"], layer:  5},{key: \"Science Seq Lab II\", items: [\"(1)\", \"Science Sequence\", \"Lab I or II Lab\"], layer:  5},{key: \"CSC 3380\", items: [\"(3)\", \"CSC 3380\", \"OO Design\"], layer: 4 },{key: \"CSC 3501\", items: [\"(3)\", \"CSC 3501\", \"Comp Org & Design\"], layer: 4 },{key: \"CSC 2262\", items: [\"(3)\", \"CSC 2262\", \"Num Methods\"], layer: 4 },{key: \"ENGL 2000\", items: [\"(3)\", \"ENGL 2000\", \"\"], layer:  4},{key: \"CMST\", items: [\"(3)\", \"Gen Ed Hum\", \"CMST\"], layer:  4},{key: \"CSC 4330\", items: [\"(3)\", \"CSC 4330\", \"Software Sys\"], layer: 3 },{key: \"CSC 2+++\", items: [\"(3)\", \"CSC 2+++\", \"\"], layer:  3},{key: \"IE 3302\", items: [\"(3)\", \"IE 3302\", \"Statistics\"], layer:  3},{key: \"Area Elective\", items: [\"**(3)\", \"Area Elective\", \"(2nd Discipline)\"], layer:  3},{key: \"Tech Ele A\", items: [\"*(3)\", \"Tech Elective\", \"A\"], layer:  3},{key: \"CSC 4103\", items: [\"(3)\", \"CSC 4103\", \"Op Sys\"], layer: 2 },{key: \"CSC 4+++\", items: [\"(3)\", \"CSC 4+++\", \"\"], layer:  2},{key: \"Area Elective\", items: [\"**(3)\", \"Area Elective\", \"(2nd Discipline)\"], layer:  2},{key: \"Tech Ele A or B\", items: [\"*(3)\", \"Tech Elective\", \"A or B\"], layer:  2},{key: \"GEN ED SOCL SCI\", items: [\"(3)\", \"Gen Ed\", \"Socl Science\"], layer:  2},{key: \"CSC 4101\", items: [\"(3)\", \"CSC 4101\", \"Prog Lang\"], layer: 1 },{key: \"CSC 3200\", items: [\"(3)\", \"CSC 3200\", \"Ethics in Computing\"], layer: 1 },{key: \"CSC 4+++\", items: [\"(3)\", \"CSC 4+++\", \"\"], layer: 1 },{key: \"Area Elective\", items: [\"**(3)\", \"Area Elective\", \"(2nd Discipline)\"], layer:  1},{key: \"Area Elective\", items: [\"**(3)\", \"Area Elective\", \"(2nd Discipline)\"], layer:  1},{key: \"CSC 3+++\", items: [\"(3)\", \"CSC 3+++\", \"\"], layer: 0 },{key: \"CSC 4+++\", items: [\"(3)\", \"CSC 4+++\", \"\"], layer: 0 },{key: \"Area Elective\", items: [\"**(3)\", \"Area Elective\", \"(2nd Discipline)\"], layer:  0},{key: \"GEN ED ART\", items: [\"(3)\", \"Gen Ed\", \"Art\"], layer:  0},{key: \"GEN ED SOCL SCI\", items: [\"(3)\", \"Gen Ed\", \"Socl Science 2+++\"], layer:  0}";

            //string links = "{to: \"CSC 1351\", from: \"CSC 1350\"},{to: \"MATH 1552\", from: \"MATH 1550\"},{to: \"MATH 2090\", from: \"MATH 1552\"},{to: \"CSC 2262\", from: \"MATH 1552\"},{to: \"IE 3302\", from: \"MATH 1552\"},{to: \"IE 3302\", from: \"CSC 2259\"},{to: \"Science Seq Lab II\", from: \"Science Seq Lab I\"},{to: \"CSC 3200\", from: \"ENGL 2000\"},{to: \"CSC 3102\", from: \"CSC 1351\"},{to: \"CSC 4101\", from: \"CSC 3102\"},{to: \"CSC 4103\", from: \"CSC 3102\"},{to: \"CSC 3200\", from: \"CSC 3102\"},{to: \"CSC 3380\", from: \"CSC 1351\"},{to: \"CSC 4330\", from: \"CSC 3102\"},{to: \"CSC 4330\", from: \"CSC 3380\"},{to: \"CSC 2259\", from: \"CSC 1351\"},{to: \"CSC 3501\", from: \"CSC 2259\"},{to: \"CSC 2262\", from: \"CSC 1351\"}";

            // Call database for users degree and flowchart
            
        }

/*        [HttpGet("{degree}")]
        public Task<IActionResult<FlowchartModel>> GetNodes(string degree)
        {

        }*/
    }
}
