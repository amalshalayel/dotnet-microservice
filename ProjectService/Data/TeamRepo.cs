using System;
using System.Collections.Generic;
using System.Linq;
using ProjectService.Models;

namespace ProjectService.Data
{
    public class ProjectRepo : IProjectRepo
    {
        private readonly AppDbContext _context;

        public ProjectRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateProject(Project plat)
        {
            if(plat == null)
            {
                throw new ArgumentNullException(nameof(plat));
            }

            _context.Projects.Add(plat);
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return _context.Projects.ToList();
        }

        public Project GetProjectById(int id)
        {
            return _context.Projects.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}