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
                .HasKey(ds => new { ds.DegreeId, ds.SemesterId });

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
                },
                new Degree
                {
                    DegreeId = 2,
                    DegreeAbbriviation = "EEC",
                    Major = "Computer Engineering"
                },
                new Degree
                {
                    DegreeId = 3,
                    DegreeAbbriviation = "IE",
                    Major = "Industrial Engineering"
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
                },
                new Semester()
                {
                    SemesterId = 9
                },
                new Semester()
                {
                    SemesterId = 10
                },
                new Semester()
                {
                    SemesterId = 11
                },
                new Semester()
                {
                    SemesterId = 12
                },
                new Semester()
                {
                    SemesterId = 13
                },
                new Semester()
                {
                    SemesterId = 14
                },
                new Semester()
                {
                    SemesterId = 15
                },
                new Semester()
                {
                    SemesterId = 16
                },
                new Semester()
                {
                    SemesterId = 17
                },
                new Semester()
                {
                    SemesterId = 18
                },
                new Semester()
                {
                    SemesterId = 19
                },
                new Semester()
                {
                    SemesterId = 20
                },
                new Semester()
                {
                    SemesterId = 21
                },
                new Semester()
                {
                    SemesterId = 22
                },
                new Semester()
                {
                    SemesterId = 23
                },
                new Semester()
                {
                    SemesterId = 24
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
                },

                // Comp Eng SEM 1 
                new Course() {
                    CourseId = 39,
                    CourseCodeAbbriviation = "CHEM",
                    Number = "1201",
                    Hours = 3,
                    Description = "Basic Chem."
                },
                new Course() {
                    CourseId = 40,
                    CourseCodeAbbriviation = "EE",
                    Number = "1810",
                    Hours = 2,
                    Description = "Intro to ECE"
                },
                new Course() {
                    CourseId = 41,
                    CourseCodeAbbriviation = "EE",
                    Number = "2741",
                    Hours = 3,
                    Description = "Dig Logic I"
                },
                new Course() {
                    CourseId = 42,
                    CourseCodeAbbriviation = "CSC",
                    Number = "1253",
                    Hours = 3,
                    Description = "Intro CSC"
                },
                new Course() {
                    CourseId = 43,
                    CourseCodeAbbriviation = "PHYS",
                    Number = "2110",
                    Hours = 3,
                    Description = "Gen Phys I"
                 },
                new Course() {
                    CourseId = 44,
                    CourseCodeAbbriviation = "PHYS",
                    Number = "2108",
                    Hours = 1,
                    Description = "Phys Lab"
                },
                new Course() {
                    CourseId = 45,
                    CourseCodeAbbriviation = "Gen Ed",
                    Number = null,
                    Hours = 3,
                    Description = "Life-Science"
                },
                new Course() {
                    CourseId = 46,
                    CourseCodeAbbriviation = "EE",
                    Number = "2742",
                    Hours = 2,
                    Description = "Dig Logic II"
                },
                new Course() {
                    CourseId = 47,
                    CourseCodeAbbriviation = "CSC",
                    Number = "1254",
                    Hours = 3,
                    Description = "Intro CSC II"
                },
                new Course() {
                    CourseId = 48,
                    CourseCodeAbbriviation = "MATH",
                    Number = "2070",
                    Hours = 4,
                    Description = "Engr Math"
                },
                new Course() {
                    CourseId = 49,
                    CourseCodeAbbriviation = "EE",
                    Number = "2120",
                    Hours = 3,
                    Description = "Circuits"
                },
                new Course() {
                    CourseId = 50,
                    CourseCodeAbbriviation = "PHYS",
                    Number = "2113",
                    Hours = 3,
                    Description = "Gen Phys III"
                },
                new Course() {
                    CourseId = 51,
                    CourseCodeAbbriviation = "EE",
                    Number = "2810",
                    Hours = 2,
                    Description = "ECE Tools"
                },
                new Course() {
                    CourseId = 52,
                    CourseCodeAbbriviation = "MATH",
                    Number = "2057",
                    Hours = 3,
                    Description = "Calc III"
                },
                new Course()
                {
                    CourseId = 53,
                    CourseCodeAbbriviation = "EE",
                    Number = "2130",
                    Hours = 3,
                    Description = "Circuits II"
                },
                new Course()
                {
                    CourseId = 54,
                    CourseCodeAbbriviation = "EE",
                    Number = "2230",
                    Hours = 3,
                    Description = "Electronics 1"
                },
                new Course()
                {
                    CourseId = 55,
                    CourseCodeAbbriviation = "EE",
                    Number = "2231",
                    Hours = 3,
                    Description = "Elect. 1 Lab"
                },
                new Course() {
                    CourseId = 56,
                    CourseCodeAbbriviation = "EE",
                    Number = "3755",
                    Hours = 3,
                    Description = "Comp Org"
                },
                new Course() {
                    CourseId = 57,
                    CourseCodeAbbriviation = "EE",
                    Number = "3752",
                    Hours = 3,
                    Description = "Micro+ Lab"
                },
                new Course() {
                    CourseId = 58,
                    CourseCodeAbbriviation = "EE",
                    Number = "3150",
                    Hours = 3,
                    Description = "Probability"
                },
                new Course() {
                    CourseId = 59,
                    CourseCodeAbbriviation = "EEC",
                    Number = null,
                    Hours = 3,
                    Description = "Breadth"
                },
                new Course() {
                    CourseId = 60,
                    CourseCodeAbbriviation = "HUMN",
                    Number = null,
                    Hours = 3,
                    Description = "PHIL 2018 #"
                },
                new Course() {
                    CourseId = 61,
                    CourseCodeAbbriviation = "EE",
                    Number = "4740",
                    Hours = 3,
                    Description = "Dis. Math"
                },
                new Course() {
                    CourseId = 62,
                    CourseCodeAbbriviation = "EE",
                    Number = "3710",
                    Hours = 3,
                    Description = "Comm in Comp"
                },
                new Course() {
                    CourseId = 63,
                    CourseCodeAbbriviation = "EE",
                    Number = "4755",
                    Hours = 3,
                    Description = "HDL&DIG"
                },
                new Course() {
                    CourseId = 64,
                    CourseCodeAbbriviation = "EE",
                    Number = "4810",
                    Hours = 1,
                    Description = "SR DSN 1"
                },
                new Course() {
                    CourseId = 65,
                    CourseCodeAbbriviation = "Tech Elect",
                    Number = null,
                    Hours = 3,
                    Description = ""
                },
                new Course() {
                    CourseId = 66,
                    CourseCodeAbbriviation = "EE Design",
                    Number = null,
                    Hours = 3,
                    Description = ""
                },
                new Course() {
                    CourseId = 67,
                    CourseCodeAbbriviation = "EE",
                    Number = "4720",
                    Hours = 3,
                    Description = "Comp Arch"
                },
                new Course() {
                    CourseId = 68,
                    CourseCodeAbbriviation = "EE",
                    Number = "4820",
                    Hours = 3,
                    Description = "SR DSN 2"
                },
                new Course() {
                    CourseId = 69,
                    CourseCodeAbbriviation = "CMST",
                    Number = null,
                    Hours = 3,
                    Description = "1061 or 2060"
                },
                new Course() {
                    CourseId = 70,
                    CourseCodeAbbriviation = "IE",
                    Number = "1002",
                    Hours = 3,
                    Description = "IE Fundamentals"
                },
                new Course() {
                    CourseId = 71,
                    CourseCodeAbbriviation = "IE",
                    Number = "2400",
                    Hours = 3,
                    Description = "Methods & System Engr"
                },
                new Course() {
                    CourseId = 72,
                    CourseCodeAbbriviation = "ECON",
                    Number = "2030",
                    Hours = 3,
                    Description = "Econ Prin"
                },
                new Course() {
                    CourseId = 73,
                    CourseCodeAbbriviation = "EE",
                    Number = "2950",
                    Hours = 3,
                    Description = "Comp EE"
                },
                new Course() {
                    CourseId = 74,
                    CourseCodeAbbriviation = "PHYS",
                    Number = "2112",
                    Hours = 3,
                    Description = "Gen Phys"
                },
                new Course() {
                    CourseId = 75,
                    CourseCodeAbbriviation = "ME",
                    Number = "2733",
                    Hours = 3,
                    Description = "Engr Mat"
                },
                new Course() {
                    CourseId = 76,
                    CourseCodeAbbriviation = "CE",
                    Number = "2450",
                    Hours = 3,
                    Description = "Statics"
                },
                new Course() {
                    CourseId = 77,
                    CourseCodeAbbriviation = "IE",
                    Number = "2060",
                    Hours = 3,
                    Description = "Intro Comp"
                },
                new Course() {
                    CourseId = 78,
                    CourseCodeAbbriviation = "IE",
                    Number = "3201",
                    Hours = 3,
                    Description = "Engr Econ"
                },
                new Course() {
                    CourseId = 79,
                    CourseCodeAbbriviation = "CE",
                    Number = "3400",
                    Hours = 3,
                    Description = "Strength"
                },
                new Course() {
                    CourseId = 80,
                    CourseCodeAbbriviation = "IE",
                    Number = "4362",
                    Hours = 3,
                    Description = "Adv Stat"
                },
                new Course() {
                    CourseId = 81, 
                    CourseCodeAbbriviation = "IE",
                    Number = "3520",
                    Hours = 3,
                    Description = "Supply Chain Logistics I"
                },
                 new Course() {
                    CourseId = 82,
                    CourseCodeAbbriviation = "IE",
                    Number = "4461",
                    Hours = 3,
                    Description = "Hum. Fac."
                 },
                 new Course() {
                    CourseId = 83,
                    CourseCodeAbbriviation = "ME",
                    Number = "3633",
                    Hours = 3,
                    Description = "Mfg Proc"
                 },
                 new Course() {
                    CourseId = 84,
                    CourseCodeAbbriviation = "IE",
                    Number = "4113",
                    Hours = 3,
                    Description = "Proj Mgmt",
                },
                 new Course() {
                    CourseId = 85,
                    CourseCodeAbbriviation = "IE",
                    Number = "4453",
                    Hours = 3,
                    Description = "QC & Six Sigma"
                 },
                  new Course() {
                    CourseId = 86,
                    CourseCodeAbbriviation = "IE",
                    Number = "4520",
                    Hours = 3,
                    Description = "Supply Chain Logisitcs II"
                  },
                 new Course() {
                    CourseId = 87,
                    CourseCodeAbbriviation = "IE",
                    Number = "4425",
                    Hours = 3,
                    Description = "Info Sys"
                 },
                 new Course() {
                    CourseId = 88,
                    CourseCodeAbbriviation = "Tech Elect",
                    Number = null,
                    Hours = 3,
                    Description = ""
                },
                 new Course() {
                    CourseId = 89,
                    CourseCodeAbbriviation = "IE",
                    Number = "4530",
                    Hours = 3,
                    Description = "Learn Mfg"
                 },
                 new Course() {
                    CourseId = 90,
                    CourseCodeAbbriviation = "IE",
                    Number = "4597",
                    Hours = 2,
                    Description = "Senior Design I"
                 },
                 new Course() {
                    CourseId = 91,
                    CourseCodeAbbriviation = "IE",
                    Number = "4530",
                    Hours = 3,
                    Description = "Learn Mfg"
                 },
                 new Course() {
                    CourseId = 92,
                    CourseCodeAbbriviation = "IE",
                    Number = "4598",
                    Hours = 2,
                    Description = "Senior Design II"
                 }

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
                },
                new DegreeSemester()
                {
                    DegreeId = 2,
                    SemesterId = 9,
                    layer = 1
                },
                new DegreeSemester()
                {
                    DegreeId = 2,
                    SemesterId = 10,
                    layer = 2
                },
                new DegreeSemester()
                {
                    DegreeId = 2,
                    SemesterId = 11,
                    layer = 3
                },
                new DegreeSemester()
                {
                    DegreeId = 2,
                    SemesterId = 12,
                    layer = 4
                },
                new DegreeSemester()
                {
                    DegreeId = 2,
                    SemesterId = 13,
                    layer = 5
                },
                new DegreeSemester()
                {
                    DegreeId = 2,
                    SemesterId = 14,
                    layer = 6
                },
                new DegreeSemester()
                {
                    DegreeId = 2,
                    SemesterId = 15,
                    layer = 7
                },
                new DegreeSemester()
                {
                    DegreeId = 2,
                    SemesterId = 16,
                    layer = 8
                }, 
                new DegreeSemester()
                {
                    DegreeId = 3,
                    SemesterId = 17,
                    layer = 1
                },
                new DegreeSemester()
                {
                    DegreeId = 3,
                    SemesterId = 18,
                    layer = 2
                },
                new DegreeSemester()
                {
                    DegreeId = 3,
                    SemesterId = 19,
                    layer = 3
                },
                new DegreeSemester()
                {
                    DegreeId = 3,
                    SemesterId = 20,
                    layer = 4
                },
                new DegreeSemester()
                {
                    DegreeId = 3,
                    SemesterId = 21,
                    layer = 5
                },
                new DegreeSemester()
                {
                    DegreeId = 3,
                    SemesterId = 22,
                    layer = 6
                },
                new DegreeSemester()
                {
                    DegreeId = 3,
                    SemesterId = 23,
                    layer = 7
                },
                new DegreeSemester()
                {
                    DegreeId = 3,
                    SemesterId = 24,
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
                    CourseId = 22
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
                    CourseId = 22
                },
                new SemesterCourse()
                {
                    SemesterId = 7,
                    CourseId = 26
                },
                new SemesterCourse()
                {
                    SemesterId = 8,
                    CourseId = 34
                },
                new SemesterCourse()
                {
                    SemesterId = 8,
                    CourseId = 30
                },
                new SemesterCourse()
                {
                    SemesterId = 8,
                    CourseId = 22
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
                },
                new SemesterCourse()
                {
                    SemesterId = 9,
                    CourseId = 39
                },
                new SemesterCourse()
                {
                    SemesterId = 9,
                    CourseId = 2
                },
                new SemesterCourse()
                {
                    SemesterId = 9,
                    CourseId = 40
                },
                new SemesterCourse()
                {
                    SemesterId = 9,
                    CourseId = 37
                },
                new SemesterCourse()
                {
                    SemesterId = 9,
                    CourseId = 3
                },
                new SemesterCourse()
                {
                    SemesterId = 10,
                    CourseId = 41
                },
                new SemesterCourse()
                {
                    SemesterId = 10,
                    CourseId = 42
                },
                new SemesterCourse()
                {
                    SemesterId = 10,
                    CourseId = 43
                },
                new SemesterCourse()
                {
                    SemesterId = 10,
                    CourseId = 6
                },
                new SemesterCourse()
                {
                    SemesterId = 10,
                    CourseId = 44
                },
                new SemesterCourse()
                {
                    SemesterId = 10,
                    CourseId = 45
                },
                new SemesterCourse()
                {
                    SemesterId = 11,
                    CourseId = 46
                },
                new SemesterCourse()
                {
                    SemesterId = 11,
                    CourseId = 47
                },
                new SemesterCourse()
                {
                    SemesterId = 11,
                    CourseId = 48
                },
                new SemesterCourse()
                {
                    SemesterId = 11,
                    CourseId = 49
                },
                new SemesterCourse()
                {
                    SemesterId = 11,
                    CourseId = 50
                },
                new SemesterCourse()
                {
                    SemesterId = 12,
                    CourseId = 51
                },
                new SemesterCourse()
                {
                    SemesterId = 12,
                    CourseId = 52
                },
                new SemesterCourse()
                {
                    SemesterId = 12,
                    CourseId = 53
                },
                new SemesterCourse()
                {
                    SemesterId = 12,
                    CourseId = 54
                },new SemesterCourse()
                {
                    SemesterId = 12,
                    CourseId = 55
                },
                new SemesterCourse()
                {
                    SemesterId = 12,
                    CourseId = 17
                },
                new SemesterCourse()
                {
                    SemesterId = 13,
                    CourseId = 56
                },
                new SemesterCourse()
                {
                    SemesterId = 13,
                    CourseId = 57
                },
                new SemesterCourse()
                {
                    SemesterId = 13,
                    CourseId = 58
                },
                new SemesterCourse()
                {
                    SemesterId = 13,
                    CourseId = 59
                },
                new SemesterCourse()
                {
                    SemesterId = 13,
                    CourseId = 60
                },
                new SemesterCourse()
                {
                    SemesterId = 13,
                    CourseId = 28
                },
                new SemesterCourse()
                {
                    SemesterId = 14,
                    CourseId = 61
                },
                new SemesterCourse()
                {
                    SemesterId = 14,
                    CourseId = 10
                },
                new SemesterCourse()
                {
                    SemesterId = 14,
                    CourseId = 62
                },
                new SemesterCourse()
                {
                    SemesterId = 14,
                    CourseId = 38
                },
                new SemesterCourse()
                {
                    SemesterId = 14,
                    CourseId = 13
                },
                new SemesterCourse()
                {
                    SemesterId = 15,
                    CourseId = 63
                },
                new SemesterCourse()
                {
                    SemesterId = 15,
                    CourseId = 24
                },
                new SemesterCourse()
                {
                    SemesterId = 15,
                    CourseId = 64
                },
                new SemesterCourse()
                {
                    SemesterId = 15,
                    CourseId = 65
                },
                new SemesterCourse()
                {
                    SemesterId = 15,
                    CourseId = 66
                },
                new SemesterCourse()
                {
                    SemesterId = 16,
                    CourseId = 67
                },
                new SemesterCourse()
                {
                    SemesterId = 16,
                    CourseId = 68
                },
                new SemesterCourse()
                {
                    SemesterId = 16,
                    CourseId = 65
                },
                new SemesterCourse()
                {
                    SemesterId = 16,
                    CourseId = 66
                },
                new SemesterCourse()
                {
                    SemesterId = 16,
                    CourseId = 13
                },
                new SemesterCourse()
                {
                    SemesterId = 17,
                    CourseId = 3
                },
                new SemesterCourse()
                {
                    SemesterId = 17,
                    CourseId = 69
                },
                new SemesterCourse()
                {
                    SemesterId = 17,
                    CourseId = 39
                },
                new SemesterCourse()
                {
                    SemesterId = 17,
                    CourseId = 2
                },
                new SemesterCourse()
                {
                    SemesterId = 17,
                    CourseId = 70
                },
                new SemesterCourse()
                {
                    SemesterId = 18,
                    CourseId = 13
                },
                new SemesterCourse()
                {
                    SemesterId = 18,
                    CourseId = 43
                },
                new SemesterCourse()
                {
                    SemesterId = 18,
                    CourseId = 44
                },
                new SemesterCourse()
                {
                    SemesterId = 18,
                    CourseId = 6
                },
                new SemesterCourse()
                {
                    SemesterId = 18,
                    CourseId = 71
                },
                new SemesterCourse()
                {
                    SemesterId = 19,
                    CourseId = 45
                },
                new SemesterCourse()
                {
                    SemesterId = 19,
                    CourseId = 72
                },
                new SemesterCourse()
                {
                    SemesterId = 19,
                    CourseId = 73
                },
                new SemesterCourse()
                {
                    SemesterId = 19,
                    CourseId = 74
                },
                new SemesterCourse()
                {
                    SemesterId = 19,
                    CourseId = 12
                },
                new SemesterCourse()
                {
                    SemesterId = 20,
                    CourseId = 17
                },
                new SemesterCourse()
                {
                    SemesterId = 20,
                    CourseId = 75
                },
                new SemesterCourse()
                {
                    SemesterId = 20,
                    CourseId = 76
                },
                new SemesterCourse()
                {
                    SemesterId = 20,
                    CourseId = 21
                },
                new SemesterCourse()
                {
                    SemesterId = 20,
                    CourseId = 77
                },
                new SemesterCourse()
                {
                    SemesterId = 21,
                    CourseId = 78
                },
                new SemesterCourse()
                {
                    SemesterId = 21,
                    CourseId = 79
                },
                new SemesterCourse()
                {
                    SemesterId = 21,
                    CourseId = 80
                },
                new SemesterCourse()
                {
                    SemesterId = 21,
                    CourseId = 81
                },
                new SemesterCourse()
                {
                    SemesterId = 21,
                    CourseId = 82
                },
                new SemesterCourse()
                {
                    SemesterId = 22,
                    CourseId = 82
                },
                new SemesterCourse()
                {
                    SemesterId = 22,
                    CourseId = 83
                },
                new SemesterCourse()
                {
                    SemesterId = 22,
                    CourseId = 84
                },
                new SemesterCourse()
                {
                    SemesterId = 22,
                    CourseId = 85
                },
                new SemesterCourse()
                {
                    SemesterId = 22,
                    CourseId = 86
                },
                new SemesterCourse()
                {
                    SemesterId = 22,
                    CourseId = 87
                },
                new SemesterCourse()
                {
                    SemesterId = 23,
                    CourseId = 65
                },
                new SemesterCourse()
                {
                    SemesterId = 23,
                    CourseId = 89
                },
                new SemesterCourse()
                {
                    SemesterId = 23,
                    CourseId = 90
                },
                new SemesterCourse()
                {
                    SemesterId = 23,
                    CourseId = 91
                },
                new SemesterCourse()
                {
                    SemesterId = 24,
                    CourseId = 37
                },
                new SemesterCourse()
                {
                    SemesterId = 24,
                    CourseId = 13
                },
                new SemesterCourse()
                {
                    SemesterId = 24,
                    CourseId = 65
                },
                new SemesterCourse()
                {
                    SemesterId = 24,
                    CourseId = 88
                },
                new SemesterCourse()
                {
                    SemesterId = 24,
                    CourseId = 92
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
                },
                new Prerequisite()
                {
                    PrerequisiteId = 16,
                    SubCourseId = 41,
                    PrerequisiteCourseId = 2
                },
                new Prerequisite()
                {
                    PrerequisiteId = 17,
                    SubCourseId = 42,
                    PrerequisiteCourseId = 2
                },
                new Prerequisite()
                {
                    PrerequisiteId = 18,
                    SubCourseId = 46,
                    PrerequisiteCourseId = 41
                },
                new Prerequisite()
                {
                    PrerequisiteId = 19,
                    SubCourseId = 47,
                    PrerequisiteCourseId = 42
                },
                new Prerequisite()
                {
                    PrerequisiteId = 20,
                    SubCourseId = 48,
                    PrerequisiteCourseId = 6
                },
                new Prerequisite()
                {
                    PrerequisiteId = 21,
                    SubCourseId = 49,
                    PrerequisiteCourseId = 40
                },
                new Prerequisite()
                {
                    PrerequisiteId = 1000,
                    SubCourseId = 50,
                    PrerequisiteCourseId = 43
                },
                new Prerequisite()
                {
                    PrerequisiteId = 22,
                    SubCourseId = 50,
                    PrerequisiteCourseId = 6
                },
                new Prerequisite()
                {
                    PrerequisiteId = 23,
                    SubCourseId = 51,
                    PrerequisiteCourseId = 42
                },
                new Prerequisite()
                {
                    PrerequisiteId = 24,
                    SubCourseId = 52,
                    PrerequisiteCourseId = 6
                },
                new Prerequisite()
                {
                    PrerequisiteId = 25,
                    SubCourseId = 53,
                    PrerequisiteCourseId = 48
                },
                new Prerequisite()
                {
                    PrerequisiteId = 26,
                    SubCourseId = 53,
                    PrerequisiteCourseId = 49
                },
                new Prerequisite()
                {
                    PrerequisiteId = 27,
                    SubCourseId = 53,
                    PrerequisiteCourseId = 50
                },
                new Prerequisite()
                {
                    PrerequisiteId = 28,
                    SubCourseId = 54,
                    PrerequisiteCourseId = 49
                },
                new Prerequisite()
                {
                    PrerequisiteId = 29,
                    SubCourseId = 56,
                    PrerequisiteCourseId = 46
                },
                new Prerequisite()
                {
                    PrerequisiteId = 30,
                    SubCourseId = 57,
                    PrerequisiteCourseId = 46
                },
                new Prerequisite()
                {
                    PrerequisiteId = 31,
                    SubCourseId = 58,
                    PrerequisiteCourseId = 42
                },
                new Prerequisite()
                {
                    PrerequisiteId = 32,
                    SubCourseId = 59,
                    PrerequisiteCourseId = 53
                },
                new Prerequisite()
                {
                    PrerequisiteId = 33,
                    SubCourseId = 61,
                    PrerequisiteCourseId = 41
                },
                new Prerequisite()
                {
                    PrerequisiteId = 34,
                    SubCourseId = 62,
                    PrerequisiteCourseId = 41
                },
                new Prerequisite()
                {
                    PrerequisiteId = 35,
                    SubCourseId = 62,
                    PrerequisiteCourseId = 58
                },
                new Prerequisite()
                {
                    PrerequisiteId = 36,
                    SubCourseId = 10,
                    PrerequisiteCourseId = 47
                },
                new Prerequisite()
                {
                    PrerequisiteId = 37,
                    SubCourseId = 10,
                    PrerequisiteCourseId = 41
                },
                new Prerequisite()
                {
                    PrerequisiteId = 38,
                    SubCourseId = 63,
                    PrerequisiteCourseId = 56
                },
                new Prerequisite()
                {
                    PrerequisiteId = 39,
                    SubCourseId = 64,
                    PrerequisiteCourseId = 57
                },
                new Prerequisite()
                {
                    PrerequisiteId = 40,
                    SubCourseId = 64,
                    PrerequisiteCourseId = 57
                },
                new Prerequisite()
                {
                    PrerequisiteId = 41,
                    SubCourseId = 64,
                    PrerequisiteCourseId = 17
                },
                new Prerequisite()
                {
                    PrerequisiteId = 42,
                    SubCourseId = 67,
                    PrerequisiteCourseId = 56
                },
                new Prerequisite()
                {
                    PrerequisiteId = 43,
                    SubCourseId = 67,
                    PrerequisiteCourseId = 57
                },
                new Prerequisite()
                {
                    PrerequisiteId = 44,
                    SubCourseId = 68,
                    PrerequisiteCourseId = 64
                },
                new Prerequisite()
                {
                    PrerequisiteId = 45,
                    SubCourseId = 71,
                    PrerequisiteCourseId = 70
                },
                new Prerequisite()
                {
                    PrerequisiteId = 46,
                    SubCourseId = 73,
                    PrerequisiteCourseId = 6
                },
                new Prerequisite()
                {
                    PrerequisiteId = 47,
                    SubCourseId = 74,
                    PrerequisiteCourseId = 6
                },
                new Prerequisite()
                {
                    PrerequisiteId = 1001,
                    SubCourseId = 74,
                    PrerequisiteCourseId = 43
                },
                new Prerequisite()
                {
                    PrerequisiteId = 48,
                    SubCourseId = 17,
                    PrerequisiteCourseId = 3
                },
                new Prerequisite()
                {
                    PrerequisiteId = 49,
                    SubCourseId = 75,
                    PrerequisiteCourseId = 74
                },
                new Prerequisite()
                {
                    PrerequisiteId = 50,
                    SubCourseId = 76,
                    PrerequisiteCourseId = 43
                },
                new Prerequisite()
                {
                    PrerequisiteId = 51,
                    SubCourseId = 76,
                    PrerequisiteCourseId = 6
                },
                new Prerequisite()
                {
                    PrerequisiteId = 52,
                    SubCourseId = 21,
                    PrerequisiteCourseId = 74
                },
                new Prerequisite()
                {
                    PrerequisiteId = 53,
                    SubCourseId = 77,
                    PrerequisiteCourseId = 70
                },
                new Prerequisite()
                {
                    PrerequisiteId = 54,
                    SubCourseId = 79,
                    PrerequisiteCourseId = 76
                },
                new Prerequisite()
                {
                    PrerequisiteId = 55,
                    SubCourseId = 80,
                    PrerequisiteCourseId = 21
                },
                new Prerequisite()
                {
                    PrerequisiteId = 56,
                    SubCourseId = 81,
                    PrerequisiteCourseId = 6
                },
                new Prerequisite()
                {
                    PrerequisiteId = 57,
                    SubCourseId = 81,
                    PrerequisiteCourseId = 21
                },
                new Prerequisite()
                {
                    PrerequisiteId = 58,
                    SubCourseId = 82,
                    PrerequisiteCourseId = 71
                },
                new Prerequisite()
                {
                    PrerequisiteId = 59,
                    SubCourseId = 83,
                    PrerequisiteCourseId = 75
                },
                new Prerequisite()
                {
                    PrerequisiteId = 60,
                    SubCourseId = 85,
                    PrerequisiteCourseId = 21
                },
                new Prerequisite()
                {
                    PrerequisiteId = 61,
                    SubCourseId = 86,
                    PrerequisiteCourseId = 81
                },
                new Prerequisite()
                {
                    PrerequisiteId = 62,
                    SubCourseId = 87,
                    PrerequisiteCourseId = 77
                },
                new Prerequisite()
                {
                    PrerequisiteId = 63,
                    SubCourseId = 89,
                    PrerequisiteCourseId = 78
                },
                new Prerequisite()
                {
                    PrerequisiteId = 64,
                    SubCourseId = 89,
                    PrerequisiteCourseId = 81
                },
                new Prerequisite()
                {
                    PrerequisiteId = 65,
                    SubCourseId = 89,
                    PrerequisiteCourseId = 84
                },
                new Prerequisite()
                {
                    PrerequisiteId = 66,
                    SubCourseId = 90,
                    PrerequisiteCourseId = 82
                },
                new Prerequisite()
                {
                    PrerequisiteId = 67,
                    SubCourseId = 90,
                    PrerequisiteCourseId = 83
                },
                new Prerequisite()
                {
                    PrerequisiteId = 68,
                    SubCourseId = 90,
                    PrerequisiteCourseId = 85
                },
                new Prerequisite()
                {
                    PrerequisiteId = 69,
                    SubCourseId = 91,
                    PrerequisiteCourseId = 77
                },
                new Prerequisite()
                {
                    PrerequisiteId = 70,
                    SubCourseId = 91,
                    PrerequisiteCourseId = 81
                },
                new Prerequisite()
                {
                    PrerequisiteId = 71,
                    SubCourseId = 92,
                    PrerequisiteCourseId = 90
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
