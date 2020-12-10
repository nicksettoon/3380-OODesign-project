using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xCourse.Data;

namespace xCourse.Entities
{
    public class FlowchartMethods
    {
        public static string[] GenerateFlowchartStrings(IList<Degree> DegreeList, string CourseAbbrev)
        {
            string nodes = "";

            string links = "";



            foreach (var degree in DegreeList)
            {
                if (degree.DegreeAbbriviation.Equals(CourseAbbrev))
                {
                    int semesterCounter = 7;
                    var semesterList = degree.DegreeSemesters.Select(ds => ds.Semester);
                    foreach (var semester in semesterList)
                    {
                        var courses = semester.SemesterCourses.Select(sem => sem.Course).ToList();
                        foreach (var course in courses)
                        {
                            if (course.Prerequisites != null)
                            {
                                foreach (var prereq in course.Prerequisites)
                                {
                                    links += $"{{ to: \"{course.CourseCodeAbbriviation} {course.Number}\", from: \"{prereq.PrerequisiteCourse.CourseCodeAbbriviation} {prereq.PrerequisiteCourse.Number}\"}}, ";


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
            return new string[] { nodes, links };
        }

        public static IList<Degree> GetDegreeList()
        {
            using (var context = new xCourseContext())
            {
                var DegreeList = context.Degrees
                    .Include(degree => degree.DegreeSemesters)
                    .ThenInclude(degreeSemesters => degreeSemesters.Semester)
                    .ThenInclude(semester => semester.SemesterCourses)
                    .ThenInclude(semesterCourses => semesterCourses.Course)
                    .ThenInclude(course => course.Prerequisites)
                    .ThenInclude(prerequisites => prerequisites.PrerequisiteCourse)
                    .ToList();
                return DegreeList;
            }
        }
    }
}
