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
                    },
                    new Degree
                    {
                        DegreeAbbriviation = "EEC",
                        Major = "Computer Engineering",
                        Semesters = new List<Semester>()
                        {
                            new Semester() {
                                Courses = new List<Course>() {
                                    new Course() {
                                        CourseCodeAbbriviation = "CHEM",
                                        Number = "1201",
                                        Hours = 3,
                                        Description = "Basic Chem.",
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
                                        CourseCodeAbbriviation = "EE",
                                        Number = "1810",
                                        Hours = 2,
                                        Description = "Intro to ECE",
                                        Prerequisites = null
                                    },
                                    new Course() {
                                        CourseCodeAbbriviation = "ART",
                                        Number = "1001",
                                        Hours = 3,
                                        Description = "",
                                        Prerequisites = null
                                    },
                                    new Course() {
                                        CourseCodeAbbriviation = "ENGL",
                                        Number = "1001",
                                        Hours = 3,
                                        Description = "Comp I",
                                        Prerequisites = null
                                    }
                                }},
                            new Semester() {
                                Courses = new List<Course>() {
                                new Course() {
                                        CourseCodeAbbriviation = "EE",
                                        Number = "2741",
                                        Hours = 3,
                                        Description = "Dig Logic I",
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
                                        CourseCodeAbbriviation = "CSC",
                                        Number = "1253",
                                        Hours = 3,
                                        Description = "Intro CSC",
                                        Prerequisites = null
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
                                        CourseCodeAbbriviation = "PHYS",
                                        Number = "2110",
                                        Hours = 3,
                                        Description = "Gen Phys I",
                                        Prerequisites = null
                                     },
                                new Course() {
                                        CourseCodeAbbriviation = "PHYS",
                                        Number = "2108",
                                        Hours = 1,
                                        Description = "Phys Lab",
                                        Prerequisites = null
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "Life-Science",
                                        Number = null,
                                        Hours = 3,
                                        Description = "Gen Ed",
                                        Prerequisites = null
                                    }
                            }

                        },
                        new Semester() {
                                Courses = new List<Course>() {
                                new Course() {
                                        CourseCodeAbbriviation = "EE",
                                        Number = "2742",
                                        Hours = 2,
                                        Description = "Dig Logic II",
                                        Prerequisites = new List<Course>() {
                                            new Course()
                                                {
                                                    CourseCodeAbbriviation = "EE",
                                                    Number = "2741",
                                                    Hours = 3,
                                                    Description = "Dig Logic I",
                                                    Prerequisites = null
                                                }
                                            }
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "CSC",
                                        Number = "1254",
                                        Hours = 3,
                                        Description = "Intro CSC II",
                                        Prerequisites = new List<Course>() {
                                            new Course() {
                                                    CourseCodeAbbriviation = "CSC",
                                                    Number = "1253",
                                                    Hours = 3,
                                                    Description = "Intro to CSC I",
                                                    Prerequisites = null
                                            }
                                        }
                                        },
                                new Course() {
                                        CourseCodeAbbriviation = "MATH",
                                        Number = "2070",
                                        Hours = 4,
                                        Description = "Engr Math",
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
                                        CourseCodeAbbriviation = "EE",
                                        Number = "2120",
                                        Hours = 3,
                                        Description = "Circuits",
                                        Prerequisites = null
                                },
                                new Course() {
                                        CourseCodeAbbriviation = "PHYS",
                                        Number = "2113",
                                        Hours = 3,
                                        Description = "Gen Phys III",
                                        Prerequisites = new List<Course>()
                                        {
                                            new Course()
                                            {
                                                CourseCodeAbbriviation = "MATH",
                                                Number = "1552"
                                            },
                                            new Course()
                                            {
                                                CourseCodeAbbriviation = "PHYS",
                                                Number = "2110"
                                            }
                                        }
                                    }
                            }

                        },
                        new Semester() {
                                Courses = new List<Course>() {
                                new Course() {
                                        CourseCodeAbbriviation = "EE",
                                        Number = "2810",
                                        Hours = 2,
                                        Description = "ECE Tools",
                                        Prerequisites = new List<Course>() {
                                            new Course()
                                                {
                                                    CourseCodeAbbriviation = "CSC",
                                                    Number = "1253",
                                                    Hours = 3,
                                                    Description = "Intro CSC",
                                                    Prerequisites = null
                                                }
                                            }
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "MATH",
                                        Number = "2057",
                                        Hours = 3,
                                        Description = "Calc III",
                                        Prerequisites = new List<Course>() {
                                            new Course() {
                                                    CourseCodeAbbriviation = "MATH",
                                                    Number = "1552",
                                                    Hours = 3,
                                                    Description = "Calc II",
                                                    Prerequisites = null
                                            }
                                        }
                                },
                                new Course()
                                {
                                    CourseCodeAbbriviation = "EE",
                                    Number = "2130",
                                    Hours = 3,
                                    Description = "Circuits II",
                                    Prerequisites = new List<Course>() {
                                        new Course() {
                                            CourseCodeAbbriviation = "EE",
                                            Number = "2120",
                                            Hours = 3,
                                            Description = "Circuits",
                                            Prerequisites = null
                                        }
                                    }
                                },
                                new Course()
                                {
                                    CourseCodeAbbriviation = "EE",
                                    Number = "2230",
                                    Hours = 3,
                                    Description = "Electronics 1",
                                    Prerequisites = new List<Course>() {
                                        new Course() {
                                            CourseCodeAbbriviation = "EE",
                                            Number = "2120",
                                            Hours = 3,
                                            Description = "Circuits",
                                            Prerequisites = null
                                        }
                                    }
                                },
                                new Course()
                                {
                                    CourseCodeAbbriviation = "EE",
                                    Number = "2231",
                                    Hours = 3,
                                    Description = "Elect. 1 Lab",
                                    Prerequisites = null
                                },
                                new Course()
                                {
                                    CourseCodeAbbriviation = "ENGL",
                                    Number = "2000",
                                    Hours = 3,
                                    Description = "Comp II",
                                    Prerequisites = new List<Course>()
                                    {
                                        new Course()
                                        {
                                            CourseCodeAbbriviation = "ENGL",
                                            Number = "1001",
                                            Hours = 3,
                                            Description = "Comp 1",
                                            Prerequisites = null
                                        }
                                    }
                                }
                            }

                        },
                        new Semester() {
                                Courses = new List<Course>() {
                                new Course() {
                                        CourseCodeAbbriviation = "EE",
                                        Number = "3755",
                                        Hours = 3,
                                        Description = "Comp Org",
                                        Prerequisites = new List<Course>() {
                                            new Course()
                                                {
                                                    CourseCodeAbbriviation = "EE",
                                                    Number =  "2742",
                                                    Hours = 2,
                                                    Description = "Dig Logic II",
                                                    Prerequisites = null
                                                }
                                            }
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "EE",
                                        Number = "3752",
                                        Hours = 3,
                                        Description = "Micro+ Lab",
                                        Prerequisites = new List<Course>()
                                        {
                                            new Course()
                                            {
                                                CourseCodeAbbriviation = "EE",
                                                Number = "2742"
                                            },
                                            new Course()
                                            {
                                                CourseCodeAbbriviation = "CSC",
                                                Number = "1253"
                                            }
                                        }
                                },
                                new Course() {
                                        CourseCodeAbbriviation = "EE",
                                        Number = "3150",
                                        Hours = 3,
                                        Description = "Probability",
                                        Prerequisites = new List<Course>()
                                        {
                                            new Course()
                                                {
                                                    CourseCodeAbbriviation = "MATH",
                                                    Number = "2057",
                                                    Hours = 3,
                                                    Description = "Calc III",
                                                    Prerequisites = null
                                             }
                                        }
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "EEC",
                                        Number = null,
                                        Hours = 3,
                                        Description = "Breadth",
                                        Prerequisites = new List<Course>()
                                        {
                                            new Course()
                                                {
                                                    CourseCodeAbbriviation = "EE",
                                                    Number = "2130",
                                                    Hours = 4,
                                                    Description = "Circuits II",
                                                    Prerequisites = null
                                             }
                                        }
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "HUMN",
                                        Number = null,
                                        Hours = 3,
                                        Description = "PHIL 2018 #",
                                        Prerequisites = null
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "SOCL SCI",
                                        Number = null,
                                        Hours = 3,
                                        Description = "Gen Ed",
                                        Prerequisites = null
                                    }
                            }

                        },
                        new Semester() {
                                Courses = new List<Course>() {
                                new Course() {
                                        CourseCodeAbbriviation = "EE",
                                        Number = "4740",
                                        Hours = 3,
                                        Description = "Dis. Math",
                                        Prerequisites = new List<Course>() {
                                            new Course()
                                                {
                                                    CourseCodeAbbriviation = "EE",
                                                    Number =  "2741",
                                                    Hours = 3,
                                                    Description = "Dig Logic I",
                                                    Prerequisites = null
                                                }
                                            }
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "CSC",
                                        Number = "3102",
                                        Hours = 3,
                                        Description = "Adv Struct",
                                        Prerequisites = new List<Course>() {
                                            new Course()
                                                {
                                                    CourseCodeAbbriviation = "CSC",
                                                    Number =  "1254",
                                                    Hours = 3,
                                                    Description = "Intro CSC II",
                                                    Prerequisites = null
                                                }
                                            }
                                },
                                new Course() {
                                        CourseCodeAbbriviation = "EE",
                                        Number = "3750",
                                        Hours = 3,
                                        Description = "Comm in Comp",
                                        Prerequisites = new List<Course>() {
                                            new Course()
                                                {
                                                    CourseCodeAbbriviation = "EE",
                                                    Number =  "2741",
                                                    Hours = 3,
                                                    Description = "Dig Logic I",
                                                    Prerequisites = null
                                                }
                                            }
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "2000+ Level",
                                        Number = null,
                                        Hours = 3,
                                        Description = "Social Science Elective",
                                        Prerequisites = null
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "HUMN",
                                        Number = null,
                                        Hours = 3,
                                        Description = "Gen Ed",
                                        Prerequisites = null
                                    }
                            }

                        },
                        new Semester() {
                                Courses = new List<Course>() {
                                new Course() {
                                        CourseCodeAbbriviation = "EE",
                                        Number = "4755",
                                        Hours = 3,
                                        Description = "HDL&DIG",
                                        Prerequisites = new List<Course>() {
                                            new Course()
                                                {
                                                    CourseCodeAbbriviation = "EE",
                                                    Number = "3755",
                                                    Hours = 3,
                                                    Description = "Comp Org",
                                                    Prerequisites = null
                                                }
                                        }
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "CSC",
                                        Number = "4103",
                                        Hours = 3,
                                        Description = "Op Sys",
                                        Prerequisites = null
                                },
                                new Course() {
                                        CourseCodeAbbriviation = "EE",
                                        Number = "4810",
                                        Hours = 1,
                                        Description = "SR DSN 1",
                                        Prerequisites = null
                                },
                                new Course() {
                                        CourseCodeAbbriviation = "Tech Elect",
                                        Number = null,
                                        Hours = 3,
                                        Description = "",
                                        Prerequisites = null
                                },
                                new Course() {
                                        CourseCodeAbbriviation = "EE Design",
                                        Number = null,
                                        Hours = 3,
                                        Description = "",
                                        Prerequisites = null
                                }
                            }

                        },
                        new Semester() {
                                Courses = new List<Course>() {
                                new Course() {
                                        CourseCodeAbbriviation = "EE",
                                        Number = "4720",
                                        Hours = 3,
                                        Description = "Comp Arch",
                                        Prerequisites = new List<Course>() {
                                            new Course()
                                                {
                                                    CourseCodeAbbriviation = "EE",
                                                    Number = "3755",
                                                    Hours = 3,
                                                    Description = "Comp Org",
                                                    Prerequisites = null
                                                },


                                            new Course()
                                            {
                                                CourseCodeAbbriviation = "EE",
                                                    Number = "3752",
                                                    Hours = 3,
                                                    Description = "Micro+Lab",
                                                    Prerequisites = null
                                            }
                                        }
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "EE",
                                        Number = "4820",
                                        Hours = 3,
                                        Description = "SR DSN 2",
                                        Prerequisites = new List<Course>()
                                        {
                                            new Course()
                                            {
                                                CourseCodeAbbriviation = "EE",
                                                    Number = "4810",
                                                    Hours = 3,
                                                    Description = "SR DSN 1",
                                                    Prerequisites = null
                                            }
                                        }
                                },
                                new Course() {
                                        CourseCodeAbbriviation = "Tech Elect",
                                        Number = null,
                                        Hours = 3,
                                        Description = "",
                                        Prerequisites = null
                                },
                                new Course() {
                                        CourseCodeAbbriviation = "EE Design",
                                        Number = null,
                                        Hours = 3,
                                        Description = "",
                                        Prerequisites = null
                                },
                                new Course() {
                                        CourseCodeAbbriviation = "HUMN",
                                        Number = null,
                                        Hours = 3,
                                        Description = "Gen Ed",
                                        Prerequisites = null
                                }
                            }

                        },
                    }
                    },

                    new Degree
                    {
                        DegreeAbbriviation = "CSC SEG",
                        Major = "Computer Science (Software Engineering)",
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
                        new Semester() 
                        {
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
                                    },
                                new Course() {
                                    CourseCodeAbbriviation = "Science Sequence II",
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
                                    Prerequisites = new List<Course> ()
                                    {
                                        new Course() {
                                            CourseCodeAbbriviation = "Science Sequence",
                                            Number = null,
                                            Hours = 1,
                                            Description = "I or II Lab",
                                            Prerequisites = null
                                        }
                                    }

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
                                        Number = "4101",
                                        Hours = 3,
                                        Description = "",
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
                                        CourseCodeAbbriviation = "CSC",
                                        Number = "3200",
                                        Hours = 3,
                                        Description = "Ethics in Computing",
                                        Prerequisites = new List<Course>()
                                        {
                                            new Course()
                                                {
                                                    CourseCodeAbbriviation = "ENGL",
                                                    Number = "2000",
                                                    Hours = 3,
                                                    Description = "",
                                                    Prerequisites = null
                                             }
                                        }
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
                                        Number = "4351",
                                        Hours = 3,
                                        Description = "Cmplr Constr",
                                        Prerequisites = new List<Course>() {
                                            new Course()
                                                {
                                                    CourseCodeAbbriviation = "CSC",
                                                    Number =  "4101",
                                                    Hours = 3,
                                                    Description = "Prog Lang",
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
                                        Number = "4402",
                                        Hours = 3,
                                        Description = "DB Mgt Sys",
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
                                        Description = "(SEG)",
                                        Prerequisites = null
                                },
                                new Course() {
                                        CourseCodeAbbriviation = "Area Elective",
                                        Number = null,
                                        Hours = 3,
                                        Description = "(SEG)",
                                        Prerequisites = null
                                },
                                new Course() {
                                        CourseCodeAbbriviation = "Approved Elective",
                                        Number = null,
                                        Hours = 3,
                                        Description = "",
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
                                        Description = "(SEG)",
                                        Prerequisites = null
                                },
                                new Course() {
                                        CourseCodeAbbriviation = "Area Elective",
                                        Number = null,
                                        Hours = 3,
                                        Description = "(SEG)",
                                        Prerequisites = null
                                },
                                new Course() {
                                        CourseCodeAbbriviation = "Approved Elective",
                                        Number = null,
                                        Hours = 3,
                                        Description = "",
                                        Prerequisites = null
                                },
                                new Course() {
                                        CourseCodeAbbriviation = "Gen Ed",
                                        Number = null,
                                        Hours = 3,
                                        Description = "Art",
                                        Prerequisites = null
                                }
                            }

                        },
                    }
                    },

                    new Degree
                    {
                        DegreeAbbriviation = "IE",
                        Major = "Industrial Engineering",
                        Semesters = new List<Semester>()
                        {
                            new Semester() {
                                Courses = new List<Course>() {
                                    new Course() {
                                        CourseCodeAbbriviation = "IE",
                                        Number = "1002",
                                        Hours = 3,
                                        Description = "IE Fundamentals",
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
                                        CourseCodeAbbriviation = "CHEM",
                                        Number = "1201",
                                        Hours = 3,
                                        Description = "Basic Chem",
                                        Prerequisites = null
                                    },
                                    new Course() {
                                        CourseCodeAbbriviation = "CMST",
                                        Number = null,
                                        Hours = 3,
                                        Description = "1061 or 2060",
                                        Prerequisites = null
                                    },
                                    new Course() {
                                        CourseCodeAbbriviation = "ENGL",
                                        Number = "1001",
                                        Hours = 3,
                                        Description = "Comp I",
                                        Prerequisites = null
                                    }
                                }},
                            new Semester() {
                                Courses = new List<Course>() {
                                new Course() {
                                        CourseCodeAbbriviation = "IE",
                                        Number = "2400",
                                        Hours = 3,
                                        Description = "Methods & System Engr",
                                        Prerequisites = new List<Course>()
                                        {
                                            new Course()
                                            {
                                                CourseCodeAbbriviation = "IE",
                                                Number = "1002",
                                                Hours = 3,
                                                Description = "IE Fundamentals",
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
                                        CourseCodeAbbriviation = "PHYS",
                                        Number = "2110",
                                        Hours = 3,
                                        Description = "Gen Phys",
                                        Prerequisites = null
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "PHYS",
                                        Number = "2108",
                                        Hours = 1,
                                        Description = "Phys Lab",
                                        Prerequisites = null
                                    },
                                    new Course() {
                                        CourseCodeAbbriviation = "HUMN",
                                        Number = null,
                                        Hours = 3,
                                        Description = "Gen Ed",
                                        Prerequisites = null
                                    }
                            }

                        },
                        new Semester() {
                                Courses = new List<Course>() {
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
                                        CourseCodeAbbriviation = "PHYS",
                                        Number = "2112",
                                        Hours = 3,
                                        Description = "Gen Phys",
                                        Prerequisites = new List<Course>() {
                                            new Course() {
                                                    CourseCodeAbbriviation = "PHYS",
                                                    Number = "2110",
                                                    Hours = 3,
                                                    Description = "Gen Phys",
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
                                        CourseCodeAbbriviation = "EE",
                                        Number = "2950",
                                        Hours = 3,
                                        Description = "Comp EE",
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
                                        CourseCodeAbbriviation = "ECON",
                                        Number = "2030",
                                        Hours = 3,
                                        Description = "Econ Prin",
                                        Prerequisites = null
                                    },
                                new Course() {
                                    CourseCodeAbbriviation = "Life Science",
                                    Number = null,
                                    Hours = 3,
                                    Description = "",
                                    Prerequisites = null
                                }
                                }
                        },
                        new Semester() {
                                Courses = new List<Course>() {
                                new Course() {
                                        CourseCodeAbbriviation = "IE",
                                        Number = "2060",
                                        Hours = 3,
                                        Description = "Intro Comp",
                                        Prerequisites = new List<Course>() {
                                            new Course()
                                                {
                                                    CourseCodeAbbriviation = "IE",
                                                    Number = "1002",
                                                    Hours = 3,
                                                    Description = "IE Fundamentals",
                                                    Prerequisites = null
                                                }
                                            }
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "IE",
                                        Number = "3302",
                                        Hours = 3,
                                        Description = "Basic Stat",
                                        Prerequisites = new List<Course>() {
                                            new Course() {
                                                    CourseCodeAbbriviation = "PHYS",
                                                    Number = "2112",
                                                    Hours = 3,
                                                    Description = "Gen Phys",
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
                                        CourseCodeAbbriviation = "CE",
                                        Number = "2450",
                                        Hours = 3,
                                        Description = "Statics",
                                        Prerequisites = new List<Course>() {
                                            new Course() {
                                                    CourseCodeAbbriviation = "PHYS",
                                                    Number = "2110",
                                                    Hours = 3,
                                                    Description = "Gen Phys",
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
                                        CourseCodeAbbriviation = "ME",
                                        Number = "2733",
                                        Hours = 3,
                                        Description = "Engr Mat",
                                        Prerequisites = new List<Course>() {
                                            new Course() {
                                                    CourseCodeAbbriviation = "PHYS",
                                                    Number = "2112",
                                                    Hours = 3,
                                                    Description = "Gen Phys",
                                                    Prerequisites = null
                                            },
                                            new Course()
                                                {
                                                    CourseCodeAbbriviation = "CHEM",
                                                    Number = "1201",
                                                    Hours = 3,
                                                    Description = "Basic Chem",
                                                    Prerequisites = null
                                                }
                                            }
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "ENGL",
                                        Number = "2000",
                                        Hours = 3,
                                        Description = "Comp II",
                                        Prerequisites = null
                                    }
                            }

                        },
                        new Semester() {
                                Courses = new List<Course>() {
                                new Course() {
                                        CourseCodeAbbriviation = "IE",
                                        Number = "4461",
                                        Hours = 3,
                                        Description = "Hum. Fac.",
                                        Prerequisites = new List<Course>() {
                                            new Course()
                                                {
                                                    CourseCodeAbbriviation = "IE",
                                                    Number = "2400",
                                                    Hours = 3,
                                                    Description = "Methods & System Engr",
                                                    Prerequisites = null
                                                }
                                            }
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "IE",
                                        Number = "3520",
                                        Hours = 3,
                                        Description = "Supply Chain Logistics I",
                                        Prerequisites = new List<Course>() {
                                            new Course()
                                                {
                                                    CourseCodeAbbriviation = "MATH",
                                                    Number =  "2090",
                                                    Hours = 4,
                                                    Description = "DE & Lin Alg",
                                                    Prerequisites = null
                                                },
                                            new Course() {
                                                    CourseCodeAbbriviation = "IE",
                                                    Number = "3302",
                                                    Hours = 3,
                                                    Description = "Basic Stat",
                                                    Prerequisites = null
                                                }
                                            }
                                },
                                new Course() {
                                        CourseCodeAbbriviation = "IE",
                                        Number = "4362",
                                        Hours = 3,
                                        Description = "Adv Stat",
                                        Prerequisites = new List<Course>()
                                        {
                                            new Course() {
                                                    CourseCodeAbbriviation = "IE",
                                                    Number = "3302",
                                                    Hours = 3,
                                                    Description = "Basic Stat",
                                                    Prerequisites = null
                                                }
                                        }
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "CE",
                                        Number = "3400",
                                        Hours = 3,
                                        Description = "Strength",
                                        Prerequisites = new List<Course>()
                                        {
                                            new Course()
                                                {
                                                    CourseCodeAbbriviation = "CE",
                                                    Number = "2450",
                                                    Hours = 3,
                                                    Description = "Statics",
                                                    Prerequisites = null
                                             }
                                        }
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "IE",
                                        Number = "3201",
                                        Hours = 3,
                                        Description = "Engr Econ",
                                        Prerequisites = null
                                    }
                            }

                        },
                        new Semester() {
                                Courses = new List<Course>() {
                                new Course() {
                                        CourseCodeAbbriviation = "IE",
                                        Number = "4425",
                                        Hours = 3,
                                        Description = "Info Sys",
                                        Prerequisites = new List<Course>() {
                                            new Course()
                                                {
                                                    CourseCodeAbbriviation = "IE",
                                                    Number =  "2060",
                                                    Hours = 3,
                                                    Description = "Intro Comp",
                                                    Prerequisites = null
                                                }
                                            }
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "IE",
                                        Number = "4520",
                                        Hours = 3,
                                        Description = "Supply Chain Logisitcs II",
                                        Prerequisites = new List<Course>() {
                                            new Course()
                                                {
                                                    CourseCodeAbbriviation = "IE",
                                                    Number =  "3520",
                                                    Hours = 3,
                                                    Description = "Supply Chain Logisitcs I",
                                                    Prerequisites = null
                                                }
                                            }
                                },
                                new Course() {
                                        CourseCodeAbbriviation = "IE",
                                        Number = "4453",
                                        Hours = 3,
                                        Description = "QC & Six Sigma",
                                        Prerequisites = new List<Course>()
                                        {
                                            new Course() {
                                                    CourseCodeAbbriviation = "IE",
                                                    Number = "3302",
                                                    Hours = 3,
                                                    Description = "Basic Stat",
                                                    Prerequisites = null
                                                }
                                        }
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "IE",
                                        Number = "4113",
                                        Hours = 3,
                                        Description = "Proj Mgmt",
                                        Prerequisites = null
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "ME",
                                        Number = "3633",
                                        Hours = 3,
                                        Description = "Mfg Proc",
                                        Prerequisites = new List<Course>()
                                        {
                                            new Course() {
                                                    CourseCodeAbbriviation = "ME",
                                                    Number = "2733",
                                                    Hours = 3,
                                                    Description = "Engr Mat",
                                                    Prerequisites = null
                                                }
                                        }
                                    }
                            }

                        },
                        new Semester() {
                                Courses = new List<Course>() {
                                new Course() {
                                        CourseCodeAbbriviation = "IE",
                                        Number = "4530",
                                        Hours = 3,
                                        Description = "Learn Mfg",
                                        Prerequisites = new List<Course>() {
                                            new Course()
                                                {
                                                    CourseCodeAbbriviation = "IE",
                                                    Number =  "2060",
                                                    Hours = 3,
                                                    Description = "Intro Comp",
                                                    Prerequisites = null
                                                },
                                                new Course()
                                                {
                                                    CourseCodeAbbriviation = "IE",
                                                    Number =  "3520",
                                                    Hours = 3,
                                                    Description = "Supply Chain Logisitcs I",
                                                    Prerequisites = null
                                                }

                                            }
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "IE",
                                        Number = "4597",
                                        Hours = 2,
                                        Description = "Senior Design I",
                                        Prerequisites = new List<Course>() {
                                            new Course()
                                                {
                                                    CourseCodeAbbriviation = "IE",
                                                    Number =  "4425",
                                                    Hours = 3,
                                                    Description = "Info Sys",
                                                    Prerequisites = null
                                                },
                                                new Course()
                                                {
                                                    CourseCodeAbbriviation = "IE",
                                                    Number =  "4520",
                                                    Hours = 3,
                                                    Description = "Supply Chain Logisitcs II",
                                                    Prerequisites = null
                                                },
                                                new Course()
                                                {
                                                    CourseCodeAbbriviation = "IE",
                                                    Number =  "4461",
                                                    Hours = 3,
                                                    Description = "Hum. Fac.",
                                                    Prerequisites = null
                                                },
                                                new Course()
                                                {
                                                    CourseCodeAbbriviation = "ME",
                                                    Number =  "3633",
                                                    Hours = 3,
                                                    Description = "Mfg Proc.",
                                                    Prerequisites = null
                                                }

                                            }
                                },
                                new Course() {
                                        CourseCodeAbbriviation = "IE",
                                        Number = "4516",
                                        Hours = 3,
                                        Description = "Plant Layout",
                                        Prerequisites = new List<Course>() {
                                            new Course()
                                                {
                                                    CourseCodeAbbriviation = "IE",
                                                    Number =  "3201",
                                                    Hours = 3,
                                                    Description = "Engr Econ",
                                                    Prerequisites = null
                                                },
                                                new Course()
                                                {
                                                    CourseCodeAbbriviation = "IE",
                                                    Number =  "4113",
                                                    Hours = 3,
                                                    Description = "Proj Mgmt",
                                                    Prerequisites = null
                                                }
                                            }
                                },
                                new Course() {
                                        CourseCodeAbbriviation = "Tech Elective",
                                        Number = null,
                                        Hours = 3,
                                        Description = "",
                                        Prerequisites = null
                                },
                                new Course() {
                                        CourseCodeAbbriviation = "SOCL SCI",
                                        Number = null,
                                        Hours = 3,
                                        Description = "Gen Ed",
                                        Prerequisites = null
                                }
                            }

                        },
                        new Semester() {
                                Courses = new List<Course>() {
                                new Course() {
                                        CourseCodeAbbriviation = "IE",
                                        Number = "4598",
                                        Hours = 2,
                                        Description = "Senior Design II",
                                        Prerequisites = new List<Course>()
                                        {
                                            new Course()
                                                {
                                                    CourseCodeAbbriviation = "IE",
                                                    Number =  "4597",
                                                    Hours = 2,
                                                    Description = "Senior Design I",
                                                    Prerequisites = null
                                                }
                                        }
                                    },
                                new Course() {
                                        CourseCodeAbbriviation = "Tech Elective",
                                        Number = null,
                                        Hours = 3,
                                        Description = "",
                                        Prerequisites = null
                                },
                                new Course() {
                                        CourseCodeAbbriviation = "Tech Elective",
                                        Number = null,
                                        Hours = 3,
                                        Description = "",
                                        Prerequisites = null
                                },
                                new Course() {
                                        CourseCodeAbbriviation = "HUMN",
                                        Number = null,
                                        Hours = 3,
                                        Description = "Gen Ed",
                                        Prerequisites = null
                                },
                                new Course() {
                                        CourseCodeAbbriviation = "ART",
                                        Number = null,
                                        Hours = 3,
                                        Description = "Gen Ed",
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
