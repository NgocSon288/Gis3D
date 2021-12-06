using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebApp.Entities;
using WebApp.Extensions;

namespace WebApp.EF
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure using Fluent API
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.OptionSeeding(); 
        }

        public DbSet<Body> Bodies { get; set; }
        public DbSet<Face> Faces { get; set; }
        public DbSet<FaceType> FaceTypes { get; set; }
        public DbSet<FaceTypeOption> FaceTypeOptions { get; set; }
        public DbSet<FaceTypeOptionValue> FaceTypeOptionValues { get; set; }
        public DbSet<Line> Lines { get; set; }
        public DbSet<LineType> LineTypes { get; set; }
        public DbSet<LineTypeOption> LineTypeOptions { get; set; }
        public DbSet<LineTypeOptionValue> LineTypeOptionValues { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<PointType> PointTypes { get; set; }
        public DbSet<PointTypeOption> PointTypeOptions { get; set; }
        public DbSet<PointTypeOptionValue> PointTypeOptionValues { get; set; }
        public DbSet<Node> Nodes { get; set; } 
        public DbSet<Option> Options { get; set; } 

    }
}
