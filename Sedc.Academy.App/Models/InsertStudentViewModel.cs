using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;

namespace Sedc.Academy.App.Models
{
    public class InsertStudentViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public List<Project> Projects { get; set; }
        public Domain.Enums.Academy Academy { get; set; }
    }
}
