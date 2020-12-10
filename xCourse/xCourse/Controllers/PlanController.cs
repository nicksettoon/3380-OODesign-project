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

            return View("Index", new PlanModel("Computer Science - Software Engineering", FlowchartStrings[0], FlowchartStrings[1]));

        }
    }
}
