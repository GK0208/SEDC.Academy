using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class AcademyDbContext : DbContext
    {
        public AcademyDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
               .HasMany(x => x.Projects).WithOne(x => x.Student).HasForeignKey(x => x.StudentId);
            modelBuilder.Entity<Student>().HasData(
                  new Student()
                  {
                      Id = 1,
                      FirstName = "Goce",
                      LastName = "Kabov",
                      Age = 26,
                      Academy = Domain.Enums.Academy.Design,
                      Projects = new List<Project>()
                  },
                  new Student()
                  {
                      Id = 2,
                      FirstName = "Kire",
                      LastName = "Davitkov",
                      Age = 28,
                      Academy = Domain.Enums.Academy.Network,
                      Projects = new List<Project>()
                  }
              );
            modelBuilder.Entity<Project>()
                   .HasOne(x => x.Student);
            modelBuilder.Entity<Project>().HasData(
                new Project()
                {
                    Id = 1,
                    EstimatedTime = 55,
                    TimeSpent = 22,
                    StudentId = 1,
                    Title = "JavaScript"
                },
                new Project()
                {
                    Id = 2,
                    Title = "EntityFramework",
                    EstimatedTime = 65,
                    TimeSpent = 33,
                    StudentId = 1
                },
                new Project()
                {
                    Id = 3,
                    Title = "SqlDatabase",
                    EstimatedTime = 25,
                    TimeSpent = 5,
                    StudentId = 1
                },
                new Project()
                {
                    Id = 4,
                    Title = "SqlDatabase",
                    EstimatedTime = 25,
                    TimeSpent = 22,
                    StudentId = 2
                },
                new Project()
                {
                    Id = 5,
                    Title = "DataDriven",
                    EstimatedTime = 55,
                    TimeSpent = 22,
                    StudentId = 2
                }
                );
        }
    }
}
