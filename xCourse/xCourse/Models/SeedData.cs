using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using xCourse.Entities;
using System.Collections.Generic;

namespace xCourse.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new FlowchartContext(
                serviceProvider.GetRequiredService<DbContextOptions<FlowchartContext>>()))
            {
                if (context.Degree.Any())
                {
                    return;
                }

                var i = 0;

                context.Degree.AddRange(
                    new Degree
                    {
                        DegreeAbbriviation = "CSC SD",
                        Major = "Computer Science (Second Dicsipline)",
                        Semesters = new List<Semester>()
                        {
                            new Semester() {
                                Courses = new List<Course>() {
                                    new Course() {
                                        CourseCodeAbbriviation = "CSC",
                                        Number = "1350",
                                        Hours = 4,
                                        Description = "Intro to CS I for Majors",
                                        Prerequisites = null
                                    },
                                    new Course() {
                                        CourseCodeAbbriviation = "MATH",
                                        Number = "1550",
                                        Hours = 5,
                                        Description = "Calc I",
                                        Prerequisites = null
                                    },
                                    new Course() {
                                        CourseCodeAbbriviation = "ENGL",
                                        Number = "1001",
                                        Hours = 3,
                                        Description = "Comp I",
                                        Prerequisites = null
                                    },
                                    new Course() {
                                        CourseCodeAbbriviation = "BIOL",
                                        Number = "1001",
                                        Hours = 3,
                                        Description = "",
                                        Prerequisites = null
                                    }
                                }},
                            new Semester() {
                                Courses = new List<Course>() {
                                new Course() {
                                        CourseCodeAbbriviation = "CSC",
                                        Number = "1351",
                                        Hours = 4,
                                        Description = "Intro to CS II for Majors",
                                        Prerequisites = new List<Course>()
                                        {
                                            new Course()
                                            {
                                                CourseCodeAbbriviation = "CSC",
                                                Number = "1350",
                                                Hours = 4,
                                                Description = "Intro to CS I for Majors",
                                                Prerequisites = null
                                            }
                                        }
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "MATH",
                                        Number = "1552",
                                        Hours = 4,
                                        Description = "Calc II",
                                        Prerequisites = new List<Course>()
                                        {
                                            new Course() {
                                                CourseCodeAbbriviation = "MATH",
                                                Number = "1550",
                                                Hours = 5,
                                                Description = "Calc I",
                                                Prerequisites = null
                                            }
                                        }
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "Gen Ed Hum",
                                        Number = null,
                                        Hours = 3,
                                        Description = "ENGL or HNRS 2000+",
                                        Prerequisites = null
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "Physical Sci.",
                                        Number = null,
                                        Hours = 3,
                                        Description = "(restricted list)",
                                        Prerequisites = null
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "Science Sequence",
                                        Number = null,
                                        Hours = 1,
                                        Description = "I or II Lab",
                                        Prerequisites = null
                                    }
                            }

                        },
                        new Semester() {
                                Courses = new List<Course>() {
                                new Course() {
                                        CourseCodeAbbriviation = "CSC",
                                        Number = "3102",
                                        Hours = 3,
                                        Description = "Adv Data Str",
                                        Prerequisites = new List<Course>() {
                                            new Course()
                                                {
                                                    CourseCodeAbbriviation = "CSC",
                                                    Number = "1351",
                                                    Hours = 4,
                                                    Description = "Intro to CS II for Majors",
                                                    Prerequisites = null
                                                }
                                            }
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "CSC",
                                        Number = "2259",
                                        Hours = 3,
                                        Description = "Discrete Structures",
                                        Prerequisites = new List<Course>() {
                                            new Course() {
                                                    CourseCodeAbbriviation = "CSC",
                                                    Number = "1351",
                                                    Hours = 4,
                                                    Description = "Intro to CS II for Majors",
                                                    Prerequisites = null
                                            },
                                            new Course()
                                                {
                                                    CourseCodeAbbriviation = "MATH",
                                                    Number = "1552",
                                                    Hours = 4,
                                                    Description = "Calc II",
                                                    Prerequisites = null
                                                }
                                            }
                                        },
                                new Course() {
                                        CourseCodeAbbriviation = "MATH",
                                        Number = "2090",
                                        Hours = 4,
                                        Description = "DE & Lin Alg",
                                        Prerequisites = new List<Course>()
                                        {
                                            new Course()
                                                {
                                                    CourseCodeAbbriviation = "MATH",
                                                    Number = "1552",
                                                    Hours = 4,
                                                    Description = "Calc II",
                                                    Prerequisites = null
                                             }
                                        }
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "Gen Ed",
                                        Number = null,
                                        Hours = 3,
                                        Description = "Humanity",
                                        Prerequisites = null
                                    }
                            }

                        },
                        new Semester() {
                                Courses = new List<Course>() {
                                new Course() {
                                        CourseCodeAbbriviation = "CSC",
                                        Number = "3380",
                                        Hours = 3,
                                        Description = "OO Design",
                                        Prerequisites = new List<Course>() {
                                            new Course()
                                                {
                                                    CourseCodeAbbriviation = "CSC",
                                                    Number = "1351",
                                                    Hours = 4,
                                                    Description = "Intro to CS II for Majors",
                                                    Prerequisites = null
                                                }
                                            }
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "CSC",
                                        Number = "3501",
                                        Hours = 3,
                                        Description = "Comp Org & Design",
                                        Prerequisites = new List<Course>() {
                                            new Course() {
                                                    CourseCodeAbbriviation = "CSC",
                                                    Number = "2259",
                                                    Hours = 3,
                                                    Description = "Discrete Structures",
                                                    Prerequisites = null
                                            }
                                        }
                                },
                                new Course() {
                                        CourseCodeAbbriviation = "CSC",
                                        Number = "2262",
                                        Hours = 3,
                                        Description = "Num Methods",
                                        Prerequisites = new List<Course>()
                                        {
                                            new Course()
                                                {
                                                    CourseCodeAbbriviation = "MATH",
                                                    Number = "1552",
                                                    Hours = 4,
                                                    Description = "Calc II",
                                                    Prerequisites = null
                                             }
                                        }
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "ENGL",
                                        Number = "2000",
                                        Hours = 3,
                                        Description = "",
                                        Prerequisites = null
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "Gen Ed Hum",
                                        Number = null,
                                        Hours = 3,
                                        Description = "CMST",
                                        Prerequisites = null
                                    }
                            }

                        },
                        new Semester() {
                                Courses = new List<Course>() {
                                new Course() {
                                        CourseCodeAbbriviation = "CSC",
                                        Number = "4330",
                                        Hours = 3,
                                        Description = "Software Sys",
                                        Prerequisites = new List<Course>() {
                                            new Course()
                                                {
                                                    CourseCodeAbbriviation = "CSC",
                                                    Number = "3380",
                                                    Hours = 3,
                                                    Description = "OO Design",
                                                    Prerequisites = null
                                                },
                                            new Course()
                                                {
                                                    CourseCodeAbbriviation = "CSC",
                                                    Number =  "3102",
                                                    Hours = 3,
                                                    Description = "Adv Data Str",
                                                    Prerequisites = null
                                                }
                                            }
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "CSC",
                                        Number = "2+++",
                                        Hours = 3,
                                        Description = "",
                                        Prerequisites = null
                                },
                                new Course() {
                                        CourseCodeAbbriviation = "IE",
                                        Number = "3302",
                                        Hours = 3,
                                        Description = "Statistics",
                                        Prerequisites = new List<Course>()
                                        {
                                            new Course()
                                                {
                                                    CourseCodeAbbriviation = "MATH",
                                                    Number = "1552",
                                                    Hours = 4,
                                                    Description = "Calc II",
                                                    Prerequisites = null
                                             },
                                            new Course()
                                                {
                                                    CourseCodeAbbriviation = "CSC",
                                                    Number = "2259",
                                                    Hours = 3,
                                                    Description = "Discrete Structures",
                                                    Prerequisites = null
                                             }
                                        }
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "Area Elective",
                                        Number = null,
                                        Hours = 3,
                                        Description = "(2nd Discipline)",
                                        Prerequisites = null
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "Tech Elective",
                                        Number = null,
                                        Hours = 3,
                                        Description = "A",
                                        Prerequisites = null
                                    }
                            }

                        },
                        new Semester() {
                                Courses = new List<Course>() {
                                new Course() {
                                        CourseCodeAbbriviation = "CSC",
                                        Number = "4103",
                                        Hours = 3,
                                        Description = "Op Sys",
                                        Prerequisites = new List<Course>() {
                                            new Course()
                                                {
                                                    CourseCodeAbbriviation = "CSC",
                                                    Number =  "3102",
                                                    Hours = 3,
                                                    Description = "Adv Data Str",
                                                    Prerequisites = null
                                                }
                                            }
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "CSC",
                                        Number = "2+++",
                                        Hours = 3,
                                        Description = "",
                                        Prerequisites = null
                                },
                                new Course() {
                                        CourseCodeAbbriviation = "Area Elective",
                                        Number = null,
                                        Hours = 3,
                                        Description = "(2nd Discipline)",
                                        Prerequisites = null
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "Tech Elective",
                                        Number = null,
                                        Hours = 3,
                                        Description = "A or B",
                                        Prerequisites = null
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "Gen Ed",
                                        Number = null,
                                        Hours = 3,
                                        Description = "Socl Science",
                                        Prerequisites = null
                                    }
                            }

                        },
                        new Semester() {
                                Courses = new List<Course>() {
                                new Course() {
                                        CourseCodeAbbriviation = "CSC",
                                        Number = "4101",
                                        Hours = 3,
                                        Description = "Prog Lang",
                                        Prerequisites = new List<Course>() {
                                            new Course()
                                                {
                                                    CourseCodeAbbriviation = "CSC",
                                                    Number =  "3102",
                                                    Hours = 3,
                                                    Description = "Adv Data Str",
                                                    Prerequisites = null
                                                }
                                            }
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "CSC",
                                        Number = "4+++",
                                        Hours = 3,
                                        Description = "",
                                        Prerequisites = null
                                },
                                new Course() {
                                        CourseCodeAbbriviation = "CSC",
                                        Number = "3200",
                                        Hours = 1,
                                        Description = "Ethics in Computing",
                                        Prerequisites = null
                                },
                                new Course() {
                                        CourseCodeAbbriviation = "Area Elective",
                                        Number = null,
                                        Hours = 3,
                                        Description = "(2nd Discipline)",
                                        Prerequisites = null
                                },
                                new Course() {
                                        CourseCodeAbbriviation = "Area Elective",
                                        Number = null,
                                        Hours = 3,
                                        Description = "(2nd Discipline)",
                                        Prerequisites = null
                                }
                            }

                        },
                        new Semester() {
                                Courses = new List<Course>() {
                                new Course() {
                                        CourseCodeAbbriviation = "CSC",
                                        Number = "3+++",
                                        Hours = 3,
                                        Description = "",
                                        Prerequisites = null
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "CSC",
                                        Number = "4+++",
                                        Hours = 3,
                                        Description = "",
                                        Prerequisites = null
                                },
                                new Course() {
                                        CourseCodeAbbriviation = "Area Elective",
                                        Number = null,
                                        Hours = 3,
                                        Description = "(2nd Discipline)",
                                        Prerequisites = null
                                },
                                new Course() {
                                        CourseCodeAbbriviation = "Gen Ed",
                                        Number = null,
                                        Hours = 3,
                                        Description = "Art",
                                        Prerequisites = null
                                },
                                new Course() {
                                        CourseCodeAbbriviation = "Gen Ed",
                                        Number = null,
                                        Hours = 3,
                                        Description = "Socl Science 2+++",
                                        Prerequisites = null
                                }
                            }

                        },
                    }
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
