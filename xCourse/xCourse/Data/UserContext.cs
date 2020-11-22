﻿using Microsoft.EntityFrameworkCore;

namespace xCourse.Entities
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) 
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}
