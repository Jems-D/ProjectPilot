using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Class;
using backend.DBContext;
using backend.DTO;
using backend.Interfaces;
using backend.Mappers;

namespace backend.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ProjectManagementDbContext _context;

        public ProjectRepository(ProjectManagementDbContext context)
        {
            _context = context;
        }

        public async Task CreateProject(Project newProj)
        {
            await _context.projects.AddAsync(newProj);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
