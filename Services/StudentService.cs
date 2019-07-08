using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Domain.Models;

namespace Services
{
    public class StudentService : IStudentService
    {
        private IRepository<Student> _studentRepository;

        public StudentService(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public void DeleteStudent(Student entity)
        {
            _studentRepository.Delete(entity);
        }

        public List<Student> GetAllStudents()
        {
            return _studentRepository.GetAll();
        }

        public Student GetStudentById(int id)
        {
            return _studentRepository.GetById(id);
        }

        public void InsertNewStudent(Student entity)
        {
            _studentRepository.Insert(entity);
        }

        public void UpdateStudent(Student entity)
        {
            _studentRepository.Update(entity);
        }
    }
}
