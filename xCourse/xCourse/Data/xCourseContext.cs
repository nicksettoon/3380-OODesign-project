using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xCourse.Entities;

namespace xCourse.Data
{
    public class xCourseContext : DbContext
    {
        public DbSet<Degree> Degrees { get; set; }

        public DbSet<Semester> Semesters { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<DegreeSemester> DegreeSemesters { get; set; }

        public DbSet<SemesterCourse> SemesterCourses { get; set; }

        public DbSet<Prerequisite> Prerequisites { get; set; }
        
        public DbSet<UserCourse> UserCourses { get; set; }

        public xCourseContext(DbContextOptions<xCourseContext> options) 
            : base(options) 
        { }

        public xCourseContext()
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=xCourse;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // DegreeSemester
            modelBuilder.Entity<DegreeSemester>()
                .HasKey(ds => new { ds.DegreeId, ds.SemesterId});

            modelBuilder.Entity<DegreeSemester>()
                .HasOne(ds => ds.Degree)
                .WithMany(d => d.DegreeSemesters)
                .HasForeignKey(ds => ds.DegreeId);

            modelBuilder.Entity<DegreeSemester>()
                .HasOne(ds => ds.Semester)
                .WithMany(s => s.DegreeSemesters)
                .HasForeignKey(ds => ds.SemesterId);

            // SemesterCourse
            modelBuilder.Entity<SemesterCourse>()
                .HasKey(sc => new { sc.SemesterId, sc.CourseId });

            modelBuilder.Entity<SemesterCourse>()
                .HasOne(sc => sc.Semester)
                .WithMany(s => s.SemesterCourses)
                .HasForeignKey(sc => sc.SemesterId);

            modelBuilder.Entity<SemesterCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.SemesterCourses)
                .HasForeignKey(sc => sc.CourseId);

/*            // Prerequisite
            modelBuilder.Entity<Prerequisite>()
                .HasKey(pr => new { pr.PrerequisiteId });*/

            modelBuilder.Entity<Prerequisite>()
                .HasOne(pr => pr.Course)
                .WithMany(c => c.Prerequisites)
                
                .HasForeignKey(pr => pr.SubCourseId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prerequisite>()
                .HasOne(pr => pr.PrerequisiteCourse)
                .WithMany(pc => pc.PrereqFor)
                
                .HasForeignKey(pr => pr.PrerequisiteCourseId).OnDelete(DeleteBehavior.Restrict);

            // UserCourse
            modelBuilder.Entity<UserCourse>()
                .HasKey(uc => new { uc.UserId, uc.CourseId });

            modelBuilder.Entity<UserCourse>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.UserCourses)
                .HasForeignKey(uc => uc.UserId);

            modelBuilder.Entity<UserCourse>()
                .HasOne(uc => uc.Course)
                .WithMany(c => c.UserCourses)
                .HasForeignKey(uc => uc.CourseId);

            var degrees = new[]
            {
                new Degree
                {
                    DegreeId = 1,
                    DegreeAbbriviation = "CSC SD",
                    Major = "Computer Science Second Discipline"
                }
            };

            var semesters = new[]
            {
                new Semester()
                {
                    SemesterId = 1
                },
                new Semester()
                {
                    SemesterId = 2
                },
                new Semester()
                {
                    SemesterId = 3
                },
                new Semester()
                {
                    SemesterId = 4
                },
                new Semester()
                {
                    SemesterId = 5
                },
                new Semester()
                {
                    SemesterId = 6
                },
                new Semester()
                {
                    SemesterId = 7
                },
                new Semester()
                {
                    SemesterId = 8
                }
            };

            var courses = new[]
            {
                new Course() {
                    CourseId = 1,
                    CourseCodeAbbriviation = "CSC",
                    Number = "1350",
                    Hours = 4,
                    Description = "Intro to CS I for Majors"
                },
                new Course() {
                    CourseId = 2,
                    CourseCodeAbbriviation = "MATH",
                    Number = "1550",
                    Hours = 5,
                    Description = "Calc I"
                },
                new Course() {
                    CourseId = 3,
                    CourseCodeAbbriviation = "ENGL",
                    Number = "1001",
                    Hours = 3,
                    Description = "Comp I"
                },
                new Course() {
                    CourseId = 4,
                    CourseCodeAbbriviation = "BIOL",
                    Number = "1001",
                    Hours = 3,
                    Description = ""
                },

                // CSC SD SEM 2
                new Course() {
                    CourseId = 5,
                    CourseCodeAbbriviation = "CSC",
                    Number = "1351",
                    Hours = 4,
                    Description = "Intro to CS II for Majors"
                },
                new Course() {
                    CourseId = 6,
                    CourseCodeAbbriviation = "MATH",
                    Number = "1552",
                    Hours = 4,
                    Description = "Calc II"
                },
                new Course() {
                    CourseId = 7,
                    CourseCodeAbbriviation = "Gen Ed Hum",
                    Number = null,
                    Hours = 3,
                    Description = "ENGL or HNRS 2000+"
                },
                new Course() {
                    CourseId = 8,
                    CourseCodeAbbriviation = "Physical Sci.",
                    Number = null,
                    Hours = 3,
                    Description = "(restricted list)"
                },
                new Course() {
                    CourseId = 9,
                    CourseCodeAbbriviation = "Science Sequence",
                    Number = null,
                    Hours = 1,
                    Description = "I or II Lab"
                },

                // CSC SD SEM 3
                new Course() {
                    CourseId = 10,
                    CourseCodeAbbriviation = "CSC",
                    Number = "3102",
                    Hours = 3,
                    Description = "Adv Data Str"
                },
                new Course() {
                    CourseId = 11,
                    CourseCodeAbbriviation = "CSC",
                    Number = "2259",
                    Hours = 3,
                    Description = "Discrete Structures"
                },
                new Course() {
                    CourseId = 12,
                    CourseCodeAbbriviation = "MATH",
                    Number = "2090",
                    Hours = 4,
                    Description = "DE & Lin Alg"
                },
                new Course() {
                    CourseId = 13,
                    CourseCodeAbbriviation = "Gen Ed",
                    Number = null,
                    Hours = 3,
                    Description = "Humanity"
                },

                // CSC SD SEM 4
                new Course() {
                    CourseId = 14,
                    CourseCodeAbbriviation = "CSC",
                    Number = "3380",
                    Hours = 3,
                    Description = "OO Design"
                },
                new Course() {
                    CourseId = 15,
                    CourseCodeAbbriviation = "CSC",
                    Number = "3501",
                    Hours = 3,
                    Description = "Comp Org & Design"
                },
                new Course() {
                    CourseId = 16,
                    CourseCodeAbbriviation = "CSC",
                    Number = "2262",
                    Hours = 3,
                    Description = "Num Methods"
                },
                new Course() {
                    CourseId = 17,
                    CourseCodeAbbriviation = "ENGL",
                    Number = "2000",
                    Hours = 3,
                    Description = ""
                },
                new Course() {
                    CourseId = 18,
                    CourseCodeAbbriviation = "Gen Ed Hum",
                    Number = null,
                    Hours = 3,
                    Description = "CMST"
                },

                // CSC SD SEM 5
                new Course() {
                    CourseId = 19,
                    CourseCodeAbbriviation = "CSC",
                    Number = "4330",
                    Hours = 3,
                    Description = "Software Sys"
                },
                new Course() {
                    CourseId = 20,
                    CourseCodeAbbriviation = "CSC",
                    Number = "2+++",
                    Hours = 3,
                    Description = ""
                },
                new Course() {
                    CourseId = 21,
                    CourseCodeAbbriviation = "IE",
                    Number = "3302",
                    Hours = 3,
                    Description = "Statistics"
                },
                new Course() {
                    CourseId = 22,
                    CourseCodeAbbriviation = "Area Elective",
                    Number = null,
                    Hours = 3,
                    Description = "(2nd Discipline)"
                },
                new Course() {
                    CourseId = 23,
                    CourseCodeAbbriviation = "Tech Elective",
                    Number = null,
                    Hours = 3,
                    Description = "A"
                },

                // CSC SD SEM 6
                new Course() {
                    CourseId = 24,
                    CourseCodeAbbriviation = "CSC",
                    Number = "4103",
                    Hours = 3,
                    Description = "Op Sys"
                },
                new Course() {
                    CourseId = 25,
                    CourseCodeAbbriviation = "CSC",
                    Number = "2+++",
                    Hours = 3,
                    Description = ""
                },
                new Course() {
                    CourseId = 26,
                    CourseCodeAbbriviation = "Area Elective",
                    Number = null,
                    Hours = 3,
                    Description = "(2nd Discipline)"
                },
                new Course() {
                    CourseId = 27,
                    CourseCodeAbbriviation = "Tech Elective",
                    Number = null,
                    Hours = 3,
                    Description = "A or B"
                },
                new Course() {
                    CourseId = 28,
                    CourseCodeAbbriviation = "Gen Ed",
                    Number = null,
                    Hours = 3,
                    Description = "Socl Science"
                },

                // CSC SD SEM 7
                new Course() {
                    CourseId = 29,
                    CourseCodeAbbriviation = "CSC",
                    Number = "4101",
                    Hours = 3,
                    Description = "Prog Lang"
                },
                new Course() {
                    CourseId = 30,
                    CourseCodeAbbriviation = "CSC",
                    Number = "4+++",
                    Hours = 3,
                    Description = ""
                },
                new Course() {
                    CourseId = 31,
                    CourseCodeAbbriviation = "CSC",
                    Number = "3200",
                    Hours = 1,
                    Description = "Ethics in Computing"
                },
                new Course() {
                    CourseId = 32,
                    CourseCodeAbbriviation = "Area Elective",
                    Number = null,
                    Hours = 3,
                    Description = "(2nd Discipline)"
                },
                new Course() {
                    CourseId = 33,
                    CourseCodeAbbriviation = "Area Elective",
                    Number = null,
                    Hours = 3,
                    Description = "(2nd Discipline)"
                },

                // CSC SD SEM 8
                new Course() {
                    CourseId = 34,
                    CourseCodeAbbriviation = "CSC",
                    Number = "3+++",
                    Hours = 3,
                    Description = ""
                },
                new Course() {
                    CourseId = 35,
                    CourseCodeAbbriviation = "CSC",
                    Number = "4+++",
                    Hours = 3,
                    Description = ""
                },
                new Course() {
                    CourseId = 36,
                    CourseCodeAbbriviation = "Area Elective",
                    Number = null,
                    Hours = 3,
                    Description = "(2nd Discipline)"
                },
                new Course() {
                    CourseId = 37,
                    CourseCodeAbbriviation = "Gen Ed",
                    Number = null,
                    Hours = 3,
                    Description = "Art"
                },
                new Course() {
                    CourseId = 38,
                    CourseCodeAbbriviation = "Gen Ed",
                    Number = null,
                    Hours = 3,
                    Description = "Socl Science 2+++"
                }

                // Comp Eng SEM 1 
            };

            var users = new[]
            {
                new User()
                {
                    UserId = 1,
                    Name = "Seth Richard",
                    DegreeAbbrev = "CSC SD"
                }
            };

            var degreeSemesters = new[]
            {
                new DegreeSemester()
                {
                    DegreeId = 1,
                    SemesterId = 1,
                    layer = 1
                },
                new DegreeSemester()
                {
                    DegreeId = 1,
                    SemesterId = 2,
                    layer = 2
                },
                new DegreeSemester()
                {
                    DegreeId = 1,
                    SemesterId = 3,
                    layer = 3
                },
                new DegreeSemester()
                {
                    DegreeId = 1,
                    SemesterId = 4,
                    layer = 4
                },new DegreeSemester()
                {
                    DegreeId = 1,
                    SemesterId = 5,
                    layer = 5
                },
                new DegreeSemester()
                {
                    DegreeId = 1,
                    SemesterId = 6,
                    layer = 6
                },
                new DegreeSemester()
                {
                    DegreeId = 1,
                    SemesterId = 7,
                    layer = 7
                },
                new DegreeSemester()
                {
                    DegreeId = 1,
                    SemesterId = 8,
                    layer = 8
                }
            };

            var semesterCourses = new[]
            {
                new SemesterCourse()
                {
                    SemesterId = 1,
                    CourseId = 1
                },
                new SemesterCourse()
                {
                    SemesterId = 1,
                    CourseId = 2
                },
                new SemesterCourse()
                {
                    SemesterId = 1,
                    CourseId = 3
                },
                new SemesterCourse()
                {
                    SemesterId = 1,
                    CourseId = 4
                },
                new SemesterCourse()
                {
                    SemesterId = 2,
                    CourseId = 5
                },
                new SemesterCourse()
                {
                    SemesterId = 2,
                    CourseId = 6
                },
                new SemesterCourse()
                {
                    SemesterId = 2,
                    CourseId = 7
                },
                new SemesterCourse()
                {
                    SemesterId = 2,
                    CourseId = 8
                },
                new SemesterCourse()
                {
                    SemesterId = 2,
                    CourseId = 9
                },
                new SemesterCourse()
                {
                    SemesterId = 3,
                    CourseId = 10
                },
                new SemesterCourse()
                {
                    SemesterId = 3,
                    CourseId = 11
                },
                new SemesterCourse()
                {
                    SemesterId = 3,
                    CourseId = 12
                },
                new SemesterCourse()
                {
                    SemesterId = 3,
                    CourseId = 13
                },
                new SemesterCourse()
                {
                    SemesterId = 4,
                    CourseId = 14
                },
                new SemesterCourse()
                {
                    SemesterId = 4,
                    CourseId = 15
                },
                new SemesterCourse()
                {
                    SemesterId = 4,
                    CourseId = 16
                },
                new SemesterCourse()
                {
                    SemesterId = 4,
                    CourseId = 17
                },
                new SemesterCourse()
                {
                    SemesterId = 4,
                    CourseId = 18
                },
                new SemesterCourse()
                {
                    SemesterId = 5,
                    CourseId = 19
                },
                new SemesterCourse()
                {
                    SemesterId = 5,
                    CourseId = 20
                },
                new SemesterCourse()
                {
                    SemesterId = 5,
                    CourseId = 21
                },
                new SemesterCourse()
                {
                    SemesterId = 5,
                    CourseId = 22
                },
                new SemesterCourse()
                {
                    SemesterId = 5,
                    CourseId = 23
                },
                new SemesterCourse()
                {
                    SemesterId = 6,
                    CourseId = 24
                },
                new SemesterCourse()
                {
                    SemesterId = 6,
                    CourseId = 25
                },
                new SemesterCourse()
                {
                    SemesterId = 6,
                    CourseId = 26
                },
                new SemesterCourse()
                {
                    SemesterId = 6,
                    CourseId = 27
                },
                new SemesterCourse()
                {
                    SemesterId = 6,
                    CourseId = 28
                },
                new SemesterCourse()
                {
                    SemesterId = 7,
                    CourseId = 29
                },
                new SemesterCourse()
                {
                    SemesterId = 7,
                    CourseId = 30
                },
                new SemesterCourse()
                {
                    SemesterId = 7,
                    CourseId = 31
                },
                new SemesterCourse()
                {
                    SemesterId = 7,
                    CourseId = 32
                },
                new SemesterCourse()
                {
                    SemesterId = 7,
                    CourseId = 33
                },
                new SemesterCourse()
                {
                    SemesterId = 8,
                    CourseId = 34
                },
                new SemesterCourse()
                {
                    SemesterId = 8,
                    CourseId = 35
                },
                new SemesterCourse()
                {
                    SemesterId = 8,
                    CourseId = 36
                },
                new SemesterCourse()
                {
                    SemesterId = 8,
                    CourseId = 37
                },
                new SemesterCourse()
                {
                    SemesterId = 8,
                    CourseId = 38
                }
            };


            var prereqs = new[]
            {
                new Prerequisite()
                {
                    PrerequisiteId = 1,
                    SubCourseId = 5,
                    PrerequisiteCourseId = 1
                },
                new Prerequisite()
                {
                    PrerequisiteId = 2,
                    SubCourseId = 6,
                    PrerequisiteCourseId = 2
                },
                new Prerequisite()
                {
                    PrerequisiteId = 3,
                    SubCourseId = 10,
                    PrerequisiteCourseId = 5
                },
                new Prerequisite()
                {
                    PrerequisiteId = 4,
                    SubCourseId = 11,
                    PrerequisiteCourseId = 5
                },
                new Prerequisite()
                {
                    PrerequisiteId = 5,
                    SubCourseId = 11,
                    PrerequisiteCourseId = 6
                },
                new Prerequisite()
                {
                    PrerequisiteId = 6,
                    SubCourseId = 12,
                    PrerequisiteCourseId = 6
                },
                new Prerequisite()
                {
                    PrerequisiteId = 7,
                    SubCourseId = 14,
                    PrerequisiteCourseId = 5
                },
                new Prerequisite()
                {
                    PrerequisiteId = 8,
                    SubCourseId = 15,
                    PrerequisiteCourseId = 11
                },
                new Prerequisite()
                {
                    PrerequisiteId = 9,
                    SubCourseId = 16,
                    PrerequisiteCourseId = 6
                },
                new Prerequisite()
                {
                    PrerequisiteId = 10,
                    SubCourseId = 19,
                    PrerequisiteCourseId = 14
                },
                new Prerequisite()
                {
                    PrerequisiteId = 11,
                    SubCourseId = 19,
                    PrerequisiteCourseId = 10
                },
                new Prerequisite()
                {
                    PrerequisiteId = 12,
                    SubCourseId = 21,
                    PrerequisiteCourseId = 6
                },
                new Prerequisite()
                {
                    PrerequisiteId = 13,
                    SubCourseId = 21,
                    PrerequisiteCourseId = 11
                },
                new Prerequisite()
                {
                    PrerequisiteId = 14,
                    SubCourseId = 24,
                    PrerequisiteCourseId = 10
                },
                new Prerequisite()
                {
                    PrerequisiteId = 15,
                    SubCourseId = 29,
                    PrerequisiteCourseId = 10
                }
            };

            var userCourses = new[]
            {
                new UserCourse()
                {
                    UserId = 1,
                    CourseId = 1
                },
                new UserCourse()
                {
                    UserId = 1,
                    CourseId = 2
                },
                new UserCourse()
                {
                    UserId = 1,
                    CourseId = 3
                },
                new UserCourse()
                {
                    UserId = 1,
                    CourseId = 4
                },
                new UserCourse()
                {
                    UserId = 1,
                    CourseId = 5
                },
                new UserCourse()
                {
                    UserId = 1,
                    CourseId = 6
                },
                new UserCourse()
                {
                    UserId = 1,
                    CourseId = 7
                },
                new UserCourse()
                {
                    UserId = 1,
                    CourseId = 8
                },
                new UserCourse()
                {
                    UserId = 1,
                    CourseId = 9
                },
                new UserCourse()
                {
                    UserId = 1,
                    CourseId = 10
                },
                new UserCourse()
                {
                    UserId = 1,
                    CourseId = 11
                },
                new UserCourse()
                {
                    UserId = 1,
                    CourseId = 12
                },
                new UserCourse()
                {
                    UserId = 1,
                    CourseId = 13
                },
                new UserCourse()
                {
                    UserId = 1,
                    CourseId = 15
                },
                new UserCourse()
                {
                    UserId = 1,
                    CourseId = 16
                },
                new UserCourse()
                {
                    UserId = 1,
                    CourseId = 17
                },
                new UserCourse()
                {
                    UserId = 1,
                    CourseId = 18
                },
                new UserCourse()
                {
                    UserId = 1,
                    CourseId = 21
                },
                new UserCourse()
                {
                    UserId = 1,
                    CourseId = 23
                },
                new UserCourse()
                {
                    UserId = 1,
                    CourseId = 24
                },
                new UserCourse()
                {
                    UserId = 1,
                    CourseId = 22
                },
                new UserCourse()
                {
                    UserId = 1,
                    CourseId = 26
                },
                new UserCourse()
                {
                    UserId = 1,
                    CourseId = 32
                },
                new UserCourse()
                {
                    UserId = 1,
                    CourseId = 33
                },
                new UserCourse()
                {
                    UserId = 1,
                    CourseId = 36
                }
            };

            modelBuilder.Entity<Degree>().HasData(degrees);
            modelBuilder.Entity<Semester>().HasData(semesters);
            modelBuilder.Entity<Course>().HasData(courses);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<DegreeSemester>().HasData(degreeSemesters);
            modelBuilder.Entity<SemesterCourse>().HasData(semesterCourses);
            modelBuilder.Entity<Prerequisite>().HasData(prereqs);
            modelBuilder.Entity<UserCourse>().HasData(userCourses);
            base.OnModelCreating(modelBuilder);
        }

        public class DegreeSemester
        {
            public int DegreeId { get; set; }
            public Degree Degree { get; set; }
            
            public int SemesterId { get; set; }
            public Semester Semester { get; set; }

            public int layer { get; set; }
        }

        public class SemesterCourse
        {
            public int SemesterId { get; set; }
            public Semester Semester { get; set; }

            public int CourseId { get; set; }
            public Course Course { get; set; }
        }

        public class Prerequisite
        {
            public int PrerequisiteId { get; set; }
            public int? SubCourseId { get; set; }
            public Course Course { get; set; }

            public int? PrerequisiteCourseId { get; set; }
            public Course PrerequisiteCourse { get; set; }
        }

        public class UserCourse
        {
            public int UserId { get; set; }
            public User User { get; set; }

            public int CourseId { get; set; }
            public Course Course { get; set; }
        }
    }
}
