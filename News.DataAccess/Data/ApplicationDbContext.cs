using Microsoft.EntityFrameworkCore;
using News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ): base(options) { }
       
        public DbSet<Topic> Topics { get; set; }

        public DbSet<Post> Posts { get; set; }



        // add this when you want to add a seeded data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Topic>().HasData(
               new Topic { Id = 1, Name="Activism"},
               new Topic { Id = 2, Name="Community"},
               new Topic { Id = 3, Name="Culture"},
               new Topic { Id = 4, Name="Education"},
               new Topic { Id = 5, Name="Innovation"},
               new Topic { Id = 6, Name="Sport"}
             );
        }
    }
}
