using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage;

namespace backend.Features.Commands
{
    public record CreateProjectCommand(string projName, string projectDescription)
        : IRequest<Guid?> { }
}
