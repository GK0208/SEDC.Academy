using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int EstimatedTime { get; set; }
        public int TimeSpent { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
