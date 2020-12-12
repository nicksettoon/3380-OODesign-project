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
                case "Industrial Engineering":
                    cmpDegreeAbr = "IE";
                    break;
                default:
                    Console.WriteLine("Invalid Compare Degree");
                    break;
            }
            var DegreeList = FlowchartMethods.GetDegreeList();

            var PrimaryDegreeStrings = FlowchartMethods.GenerateFlowchartStrings(DegreeList, "CSC SD");
            var CompareDegreeStrings = FlowchartMethods.GenerateFlowchartStrings(DegreeList, cmpDegreeAbr);
            
                
                return View("Index", new CompareModel()
                {
                    FirstDegreeNodes = PrimaryDegreeStrings[0],
                    FirstDegreeLinks = PrimaryDegreeStrings[1],
                    SecondDegreeNodes = CompareDegreeStrings[0],
                    SecondDegreeLinks = CompareDegreeStrings[1]
                });

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
