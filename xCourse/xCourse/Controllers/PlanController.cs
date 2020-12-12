using System.Collections.Generic;
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

            var DegreeList = FlowchartMethods.GetDegreeList();

            var FlowchartStrings = FlowchartMethods.GenerateFlowchartStrings(DegreeList, CourseAbbrev);

            string Degree;

            switch (CourseAbbrev)
            {
                case "EEC":
                    Degree = "Computer Engineering";
                    break;
                case "CSC SD":
                    Degree = "Computer Science Second Discipline";
                    break;
                case "IE":
                    Degree = "Industrial Engineering";
                    break;
                default:
                    Degree = "Invalid Compare Degree";
                    break;
            }

            return View("Index", new PlanModel(Degree, FlowchartStrings[0], FlowchartStrings[1]));

        }
    }
}
