using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace backend.Features.Commands
{
    public record CreateAccountCommand(string name, string email) : IRequest<Guid> { }
}
