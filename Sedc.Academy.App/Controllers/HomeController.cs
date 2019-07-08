using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sedc.Academy.App.Models;
using Services;

namespace Sedc.Academy.App.Controllers
{
    public class HomeController : Controller
    {
        private IStudentService _studentService;
        private IProjectService _projectService;

        public HomeController(IStudentService studentService, IProjectService projectService)
        {
            _studentService = studentService;
            _projectService = projectService;
        }
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
