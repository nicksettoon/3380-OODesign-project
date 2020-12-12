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

            var coursesTest = GetPreviouslyTakenCourses(1);

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
                            if (coursesTest.Contains(course.CourseId))
                            {
                                nodes += $"{{ key: \"{course.CourseCodeAbbriviation} {course.Number}\", items: [ \"({course.Hours})\", \"{course.CourseCodeAbbriviation} {course.Number}\", \"{course.Description}\"], layer: {semesterCounter}, color: \"#00cc66\" }}, ";

                            }
                            else
                            {
                                nodes += $"{{ key: \"{course.CourseCodeAbbriviation} {course.Number}\", items: [ \"({course.Hours})\", \"{course.CourseCodeAbbriviation} {course.Number}\", \"{course.Description}\"], layer: {semesterCounter}, color: \"white\" }}, ";
                            }

                        }

                        semesterCounter--;
                    }
                }
            }

            if (nodes != null && nodes != "")
            {
                nodes = nodes.Remove(nodes.Length - 1, 1);
            }
            if (links != null && nodes != "")
            {
                links = links.Remove(links.Length - 1, 1);
            }

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

        public static IList<int> GetPreviouslyTakenCourses(int StudentId)
        {
            using (var context = new xCourseContext())
            {
                var users = context.Users.Select(u => u).Where(u => u.UserId == StudentId)
                    .Include(u => u.UserCourses)
                    .ThenInclude(uc => uc.Course)
                    .ThenInclude(c => c.Prerequisites)
                    .Include(u => u.UserCourses)
                    .ThenInclude(uc => uc.Course)
                    .ThenInclude(c => c.PrereqFor)
                    .Include(u => u.UserCourses)
                    .ThenInclude(uc => uc.Course)
                    .ThenInclude(c => c.SemesterCourses)
                    .ToList();

                var courses = users.First().UserCourses.Select(uc => uc.Course.CourseId).ToList();

                return courses;
            }
        }

    }
}
