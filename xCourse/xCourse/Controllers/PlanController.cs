using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using xCourse.Models;

namespace xCourse.Controllers
{
    public class PlanController : Controller
    {
        public IActionResult Index()
        {
            // Call database for users degree and flowchart
            return View("Index", new PlanModel("Computer Science - Software Engineering"));
        }
    }
}
