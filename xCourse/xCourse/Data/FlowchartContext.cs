using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xCourse.Entities
{
    public class FlowchartContext : DbContext
    {
        public DbSet<Degree> Degree { get; set; }

        public FlowchartContext(DbContextOptions<FlowchartContext> options)
            : base(options)
        { }

        public FlowchartContext()
            : base()
        { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=xCourse;Integrated Security=True");
        }
    }



    
}
