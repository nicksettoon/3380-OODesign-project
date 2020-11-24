using System.Linq;
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
        }
    }
}
