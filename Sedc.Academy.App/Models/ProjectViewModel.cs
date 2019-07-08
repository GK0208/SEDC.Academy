using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sedc.Academy.App.Models
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int EstimatedTime { get; set; }
        public int TimeSpent { get; set; }
        public int StudentId { get; set; }
    }
}
