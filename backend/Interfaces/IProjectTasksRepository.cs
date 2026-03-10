using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Class;

namespace backend.Interfaces
{
    public interface IProjectTasksRepository
    {
        Task CreateProjectTask(ProjectTasks projectTasks);
        Task SaveChangesAsync();
    }
}
