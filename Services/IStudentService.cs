using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IStudentService
    {
        List<Student> GetAllStudents();
        Student GetStudentById(int id);
        void InsertNewStudent(Student entity);
        void UpdateStudent(Student entity);
        void DeleteStudent(Student entity);
    }
}
