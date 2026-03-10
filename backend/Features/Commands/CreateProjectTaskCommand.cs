using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace backend.Features.Commands
{
    public record CreateProjectTaskCommand(
        string projTaskName,
        string ProjectTaskDescription,
        Guid Id
    ) : IRequest<Guid?> { }
}
