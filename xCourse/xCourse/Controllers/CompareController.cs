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
    public class CompareController : Controller
    {
        public IActionResult Index(string compareDegree)
        {
            string cmpDegreeAbr = compareDegree;
            switch (compareDegree)
            {
                case "Computer Engineering":
                    cmpDegreeAbr = "EEC";
                    break;
                case "Computer Science Second Discipline":
                    cmpDegreeAbr = "CSC SD";
                    break;
                case "Electrical Engineering":
                    cmpDegreeAbr = "EE";
                    break;
                default:
                    Console.WriteLine("Invalid Compare Degree");
                    break;
            }
            using (var context = new FlowchartContext())
            {
                var DegreeList = context.Degree
                    .Include(degree => degree.Semesters)
                        .ThenInclude(semsester => semsester.Courses)
                        .ThenInclude(course => course.Prerequisites)
                    .ToList();


                string nodesPrimary = "";

                string linksPrimary = "";

                string compareNodes = "";
                
                string compareLinks = "";


                foreach (var degree in DegreeList)
                {
                    if (degree.DegreeAbbriviation.Equals("CSC SD"))
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
                                        linksPrimary += $"{{ to: \"{course.CourseCodeAbbriviation} {course.Number}\", from: \"{prereq.CourseCodeAbbriviation} {prereq.Number}\"}}, ";


                                    }

                                }

                                nodesPrimary += $"{{ key: \"{course.CourseCodeAbbriviation} {course.Number}\", items: [ \"({course.Hours})\", \"{course.CourseCodeAbbriviation} {course.Number}\", \"{course.Description}\"], layer: {semesterCounter} }}, ";


                            }

                            semesterCounter--;
                        }
                    }
                    
                    if (degree.DegreeAbbriviation.Equals(cmpDegreeAbr))
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
                                        compareLinks += $"{{ to: \"{course.CourseCodeAbbriviation} {course.Number}\", from: \"{prereq.CourseCodeAbbriviation} {prereq.Number}\"}}, ";


                                    }

                                }

                                compareNodes += $"{{ key: \"{course.CourseCodeAbbriviation} {course.Number}\", items: [ \"({course.Hours})\", \"{course.CourseCodeAbbriviation} {course.Number}\", \"{course.Description}\"], layer: {semesterCounter} }}, ";


                            }

                            semesterCounter--;
                        }
                    }
                }
                nodesPrimary = nodesPrimary.Remove(nodesPrimary.Length - 1, 1);
                linksPrimary = linksPrimary.Remove(linksPrimary.Length - 1, 1);
                if (!string.IsNullOrEmpty(compareNodes))
                {
                    compareNodes = compareNodes.Remove(compareNodes.Length - 1, 1);
                }
                if (!string.IsNullOrEmpty(compareLinks))
                {
                    compareLinks = compareLinks.Remove(compareLinks.Length - 1, 1);
                }
                
                return View("Index", new CompareModel()
                {
                    FirstDegreeNodes = nodesPrimary,
                    FirstDegreeLinks = linksPrimary,
                    SecondDegreeNodes = compareNodes,
                    SecondDegreeLinks = compareLinks
                });

            }
        }

        public IActionResult Submit(CompareModel data)
        {
            if (!(data.CompareDegree == null))
            {

            }

            return View();
        }
    }
}
