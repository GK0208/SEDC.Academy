using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class StudentRepository : IRepository<Student>
    {
        private AcademyDbContext _dbContext;
        public StudentRepository(AcademyDbContext context)
        {
            _dbContext = context;
        }

        public void Delete(Student entity)
        {
            _dbContext.Students.Remove(entity);
            _dbContext.SaveChanges();
        }

        public List<Student> GetAll()
        {
            return _dbContext.Students.ToList();
        }

        public Student GetById(int id)
        {
            Student student = _dbContext.Students.SingleOrDefault(x => x.Id == id);
            return student;
        }

        public void Insert(Student entity)
        {
            _dbContext.Students.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Student entity)
        {
            Student student = _dbContext.Students.SingleOrDefault(x => x.Id == entity.Id);
            if (student != null)
            {
                student.FirstName = entity.FirstName;
                student.LastName = entity.LastName;
                student.Age = entity.Age;
                student.Projects = entity.Projects;
            };
            _dbContext.SaveChanges();
        }
    }
}
