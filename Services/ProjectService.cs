using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Domain.Models;

namespace Services
{
    public class ProjectService : IProjectService
    {
        private IRepository<Project> _projectRepository;

        public ProjectService(IRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public void DeleteProject(Project entity)
        {
            _projectRepository.Delete(entity);
        }

        public List<Project> GetAllSubjects()
        {
            return _projectRepository.GetAll();
        }

        public Project GetProjectById(int id)
        {
            return _projectRepository.GetById(id);
        }

        public void InsertNewProject(Project entity)
        {
            _projectRepository.Insert(entity);
        }

        public void UpdateProject(Project entity)
        {
            _projectRepository.Update(entity);
        }
    }
}
