using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Class;
using Microsoft.EntityFrameworkCore;

namespace backend.DBContext
{
    public class ProjectManagementDbContext : DbContext
    {
        public ProjectManagementDbContext(DbContextOptions<ProjectManagementDbContext> options)
            : base(options) { }

        public DbSet<Project> projects { get; set; }
        public DbSet<ProjectTasks> projectTasks { get; set; }
        public DbSet<TaskOrProjectStatus> taskOrProjectStatuses { get; set; }
    }
}
