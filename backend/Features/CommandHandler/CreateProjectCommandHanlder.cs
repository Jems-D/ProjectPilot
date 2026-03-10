using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using backend.Class;
using backend.DTO;
using backend.Features.Commands;
using backend.Interfaces;
using MediatR;

namespace backend.Features
{
    public class CreateProjectCommandHanlder : IRequestHandler<CreateProjectCommand, Guid?>
    {
        private readonly IProjectRepository _repoProj;

        public CreateProjectCommandHanlder(IProjectRepository repoProj)
        {
            _repoProj = repoProj;
        }

        public async Task<Guid?> Handle(
            CreateProjectCommand request,
            CancellationToken cancellationToken
        )
        {
            var createdProj = new Project
            {
                ProjectName = request.projName,
                Description = request.projectDescription,
            };
            await _repoProj.CreateProject(createdProj);
            await _repoProj.SaveChangesAsync();

            return createdProj.ProjectId;
        }
    }
}
