using System.Collections.Generic;
using ProjectService.Models;

namespace ProjectService.Data
{
    public interface IProjectRepo
    {
        bool SaveChanges();

        IEnumerable<Project> GetAllProjects();
        Project GetProjectById(int id);
        void CreateProject(Project plat);
    }
}