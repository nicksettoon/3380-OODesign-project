using Microsoft.VisualStudio.TestTools.UnitTesting;
using xCourse;
using xCourse.Controllers;
using xCourse.Entities;

namespace xCourseTests
{
    [TestClass]
    public class DegreeDatabaseTest
    {
        [TestMethod]
        public void GetDegreesTest()
        {
            var DegreeList = FlowchartMethods.GetDegreeList();

            Assert.IsNotNull(DegreeList, "The GetDegreeList Method is not correctly getting the degree list");

        }

        [TestMethod]
        public void GenerateFlowchartTest()
        {
            var DegreeList = FlowchartMethods.GetDegreeList();
            var flowchart = FlowchartMethods.GenerateFlowchartStrings(DegreeList, "CSC SD");
            string expected = "";

            Assert.AreEqual(expected, flowchart[0], "The Generate flowchart method does not generate the nodes string correctely.");
            Assert.AreEqual(expected, flowchart[1], "The Generate flowchart method does not generate the links string correctely.");
        }

        [TestMethod]
        public void PreviouslyTakenCoursesTest()
        {
           var userCourses = FlowchartMethods.GetPreviouslyTakenCourses(1);

        }

    }
}
