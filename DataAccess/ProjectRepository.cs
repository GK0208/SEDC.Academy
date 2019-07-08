using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class ProjectRepository : IRepository<Project>
    {
        private AcademyDbContext _dbContext;
        public ProjectRepository(AcademyDbContext context)
        {
            _dbContext = context;
        }

        public void Delete(Project entity)
        {
            _dbContext.Projects.Remove(entity);
            _dbContext.SaveChanges();
        }

        public List<Project> GetAll()
        {
            return _dbContext.Projects.ToList();
        }

        public Project GetById(int id)
        {
            Project project = _dbContext.Projects.SingleOrDefault(x => x.Id == id);
            return project;
        }

        public void Insert(Project entity)
        {
            _dbContext.Projects.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Project entity)
        {
            Project project = _dbContext.Projects.SingleOrDefault(x => x.Id == entity.Id);
            if (project != null)
            {
                project.Title = entity.Title;
                project.TimeSpent = entity.TimeSpent;
                project.EstimatedTime = entity.EstimatedTime;
                project.StudentId = entity.StudentId;
                project.Student = entity.Student;
            };
            _dbContext.SaveChanges();
        }
    }
}
