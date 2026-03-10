using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Class;
using backend.Features.Commands;
using backend.Interfaces;
using MediatR;

namespace backend.Features.CommandHandler
{
    public class CreateProjectTasksCommandHandler : IRequestHandler<CreateProjectTaskCommand, Guid?>
    {
        private readonly IProjectTasksRepository _repoTasks;
        private readonly IProjectRepository _repoProj;

        public CreateProjectTasksCommandHandler(
            IProjectTasksRepository repoTasks,
            IProjectRepository repoProj
        )
        {
            _repoTasks = repoTasks;
            _repoProj = repoProj;
        }

        public async Task<Guid?> Handle(
            CreateProjectTaskCommand request,
            CancellationToken cancellationToken
        )
        {
            var projId = await _repoProj.FindProjectById(request.Id);
            if (projId == Guid.Empty)
            {
                return null;
            }

            var createdTask = new ProjectTasks
            {
                ProjectId = request.Id,
                ProjectTaskName = request.projTaskName,
                ProjectTaskDescription = request.ProjectTaskDescription,
            };

            await _repoTasks.CreateProjectTask(createdTask);

            await _repoTasks.SaveChangesAsync();

            return createdTask.ProjectTaskId;
        }
    }
}
