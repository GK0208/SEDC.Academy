using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Sedc.Academy.App.Models;
using Services;

namespace Sedc.Academy.App.Controllers
{
    public class StudentController : Controller
    {
        private IStudentService _studentService;
        private IProjectService _projectService;

        public StudentController(IStudentService studentService, IProjectService projectService)
        {
            _studentService = studentService;
            _projectService = projectService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Student> students = _studentService.GetAllStudents();
            foreach(var student in students)
            {
                student.Projects = _projectService.GetAllSubjects().Where(x => x.StudentId == student.Id).ToList();

            }
            StudentViewModel studentModel = new StudentViewModel()
            {
                Students = students
            };

            return View(studentModel);
        }

        public IActionResult AddStudent()
        {
            InsertStudentViewModel model = new InsertStudentViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddStudent(InsertStudentViewModel model)
        {
            Student student = new Student()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                Academy = model.Academy,
            };

            _studentService.InsertNewStudent(student);
             return RedirectToAction("Index", "Home");
        }

        public IActionResult Details(Student student)
        {
            InsertStudentViewModel model = new InsertStudentViewModel()
            {
                Id=student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Age = student.Age,
                Academy = student.Academy
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Details(InsertStudentViewModel model)
        {
            Student student = _studentService.GetStudentById(model.Id);
            student.Age = model.Age;
            student.FirstName = model.FirstName;
            student.LastName = model.LastName;
            student.Academy = model.Academy;
            student.Projects = model.Projects;

            _studentService.UpdateStudent(student);
            return RedirectToAction("Index", "Student");
        }
        public IActionResult AddProject(InsertStudentViewModel model)
        {
            ProjectViewModel project = new ProjectViewModel()
            {
                StudentId = model.Id
            };
            return View(project);

        }
        [HttpPost]
        public IActionResult AddProject(ProjectViewModel model)
        {
            Student student = _studentService.GetStudentById(model.StudentId);
            Project project = new Project()
            {
                StudentId = model.StudentId,
                Title = model.Title,
                EstimatedTime = model.EstimatedTime,
                TimeSpent = model.TimeSpent,
                Student=student
            };
            _projectService.InsertNewProject(project);
            return RedirectToAction("Index", "Student");

        }
    }
}