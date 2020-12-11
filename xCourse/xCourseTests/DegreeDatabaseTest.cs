using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
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

            Assert.IsNotNull(DegreeList, "The GetDegreeList Method is not correctly getting the degree list.");

        }

        [TestMethod]
        public void GenerateFlowchartTest()
        {
            var DegreeList = FlowchartMethods.GetDegreeList();
            var flowchart = FlowchartMethods.GenerateFlowchartStrings(DegreeList, "CSC SD");
            string expectedNodes = "{ key: \"CSC 1350\", items: [ \"(4)\", \"CSC 1350\", \"Intro to CS I for Majors\"], layer: 7, color: \"yellow\" }, { key: \"MATH 1550\", items: [ \"(5)\", \"MATH 1550\", \"Calc I\"], layer: 7, color: \"yellow\" }, { key: \"ENGL 1001\", items: [ \"(3)\", \"ENGL 1001\", \"Comp I\"], layer: 7, color: \"yellow\" }, { key: \"BIOL 1001\", items: [ \"(3)\", \"BIOL 1001\", \"\"], layer: 7, color: \"yellow\" }, { key: \"CSC 1351\", items: [ \"(4)\", \"CSC 1351\", \"Intro to CS II for Majors\"], layer: 6, color: \"yellow\" }, { key: \"MATH 1552\", items: [ \"(4)\", \"MATH 1552\", \"Calc II\"], layer: 6, color: \"yellow\" }, { key: \"Gen Ed Hum \", items: [ \"(3)\", \"Gen Ed Hum \", \"ENGL or HNRS 2000+\"], layer: 6, color: \"yellow\" }, { key: \"Physical Sci. \", items: [ \"(3)\", \"Physical Sci. \", \"(restricted list)\"], layer: 6, color: \"yellow\" }, { key: \"Science Sequence \", items: [ \"(1)\", \"Science Sequence \", \"I or II Lab\"], layer: 6, color: \"yellow\" }, { key: \"CSC 3102\", items: [ \"(3)\", \"CSC 3102\", \"Adv Data Str\"], layer: 5, color: \"yellow\" }, { key: \"CSC 2259\", items: [ \"(3)\", \"CSC 2259\", \"Discrete Structures\"], layer: 5, color: \"yellow\" }, { key: \"MATH 2090\", items: [ \"(4)\", \"MATH 2090\", \"DE & Lin Alg\"], layer: 5, color: \"yellow\" }, { key: \"Gen Ed \", items: [ \"(3)\", \"Gen Ed \", \"Humanity\"], layer: 5, color: \"yellow\" }, { key: \"CSC 3380\", items: [ \"(3)\", \"CSC 3380\", \"OO Design\"], layer: 4, color: \"white\" }, { key: \"CSC 3501\", items: [ \"(3)\", \"CSC 3501\", \"Comp Org & Design\"], layer: 4, color: \"yellow\" }, { key: \"CSC 2262\", items: [ \"(3)\", \"CSC 2262\", \"Num Methods\"], layer: 4, color: \"yellow\" }, { key: \"ENGL 2000\", items: [ \"(3)\", \"ENGL 2000\", \"\"], layer: 4, color: \"yellow\" }, { key: \"Gen Ed Hum \", items: [ \"(3)\", \"Gen Ed Hum \", \"CMST\"], layer: 4, color: \"yellow\" }, { key: \"CSC 4330\", items: [ \"(3)\", \"CSC 4330\", \"Software Sys\"], layer: 3, color: \"white\" }, { key: \"CSC 2+++\", items: [ \"(3)\", \"CSC 2+++\", \"\"], layer: 3, color: \"white\" }, { key: \"IE 3302\", items: [ \"(3)\", \"IE 3302\", \"Statistics\"], layer: 3, color: \"yellow\" }, { key: \"Area Elective \", items: [ \"(3)\", \"Area Elective \", \"(2nd Discipline)\"], layer: 3, color: \"yellow\" }, { key: \"Tech Elective \", items: [ \"(3)\", \"Tech Elective \", \"A\"], layer: 3, color: \"yellow\" }, { key: \"CSC 4103\", items: [ \"(3)\", \"CSC 4103\", \"Op Sys\"], layer: 2, color: \"yellow\" }, { key: \"CSC 2+++\", items: [ \"(3)\", \"CSC 2+++\", \"\"], layer: 2, color: \"white\" }, { key: \"Area Elective \", items: [ \"(3)\", \"Area Elective \", \"(2nd Discipline)\"], layer: 2, color: \"yellow\" }, { key: \"Tech Elective \", items: [ \"(3)\", \"Tech Elective \", \"A or B\"], layer: 2, color: \"white\" }, { key: \"Gen Ed \", items: [ \"(3)\", \"Gen Ed \", \"Socl Science\"], layer: 2, color: \"white\" }, { key: \"CSC 4101\", items: [ \"(3)\", \"CSC 4101\", \"Prog Lang\"], layer: 1, color: \"white\" }, { key: \"CSC 4+++\", items: [ \"(3)\", \"CSC 4+++\", \"\"], layer: 1, color: \"white\" }, { key: \"CSC 3200\", items: [ \"(1)\", \"CSC 3200\", \"Ethics in Computing\"], layer: 1, color: \"white\" }, { key: \"Area Elective \", items: [ \"(3)\", \"Area Elective \", \"(2nd Discipline)\"], layer: 1, color: \"yellow\" }, { key: \"Area Elective \", items: [ \"(3)\", \"Area Elective \", \"(2nd Discipline)\"], layer: 1, color: \"yellow\" }, { key: \"CSC 3+++\", items: [ \"(3)\", \"CSC 3+++\", \"\"], layer: 0, color: \"white\" }, { key: \"CSC 4+++\", items: [ \"(3)\", \"CSC 4+++\", \"\"], layer: 0, color: \"white\" }, { key: \"Area Elective \", items: [ \"(3)\", \"Area Elective \", \"(2nd Discipline)\"], layer: 0, color: \"yellow\" }, { key: \"Gen Ed \", items: [ \"(3)\", \"Gen Ed \", \"Art\"], layer: 0, color: \"white\" }, { key: \"Gen Ed \", items: [ \"(3)\", \"Gen Ed \", \"Socl Science 2+++\"], layer: 0, color: \"white\" },";
            string expectedLinks = "{ to: \"CSC 1351\", from: \"CSC 1350\"}, { to: \"MATH 1552\", from: \"MATH 1550\"}, { to: \"CSC 3102\", from: \"CSC 1351\"}, { to: \"CSC 2259\", from: \"CSC 1351\"}, { to: \"CSC 2259\", from: \"MATH 1552\"}, { to: \"MATH 2090\", from: \"MATH 1552\"}, { to: \"CSC 3380\", from: \"CSC 1351\"}, { to: \"CSC 3501\", from: \"CSC 2259\"}, { to: \"CSC 2262\", from: \"MATH 1552\"}, { to: \"CSC 4330\", from: \"CSC 3380\"}, { to: \"CSC 4330\", from: \"CSC 3102\"}, { to: \"IE 3302\", from: \"MATH 1552\"}, { to: \"IE 3302\", from: \"CSC 2259\"}, { to: \"CSC 4103\", from: \"CSC 3102\"}, { to: \"CSC 4101\", from: \"CSC 3102\"},";

            Assert.AreEqual(expectedNodes, flowchart[0], "The Generate flowchart method does not generate the nodes string correctely.");
            Assert.AreEqual(expectedLinks, flowchart[1], "The Generate flowchart method does not generate the links string correctely.");
        }

        [TestMethod]
        public void PreviouslyTakenCoursesTest()
        {
            var expectedList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 15, 16, 17, 18, 21, 23, 24, 22, 26, 32, 33, 36 };
            var userCourses = new List<int>(FlowchartMethods.GetPreviouslyTakenCourses(1));

            Assert.AreEqual(expectedList, userCourses, "The Previously Taken Courses method does not pull the users courses correctly.");
        }
    }
}
