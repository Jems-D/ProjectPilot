using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Class;
using backend.DBContext;
using backend.Interfaces;

namespace backend.Repository
{
    public class ProjectTaskRepository : IProjectTasksRepository
    {
        private readonly ProjectManagementDbContext _context;

        public ProjectTaskRepository(ProjectManagementDbContext context)
        {
            _context = context;
        }

        public async Task CreateProjectTask(ProjectTasks projectTasks)
        {
            await _context.projectTasks.AddAsync(projectTasks);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
