using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IProjectService
    {
        List<Project> GetAllSubjects();
        Project GetProjectById(int id);
        void InsertNewProject(Project entity);
        void UpdateProject(Project entity);
        void DeleteProject(Project entity);
    }
}
