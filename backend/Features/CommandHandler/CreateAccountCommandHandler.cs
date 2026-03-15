using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Class;
using backend.Controllers;
using backend.Features.Commands;
using backend.Interfaces;
using MediatR;

namespace backend.Features.CommandHandler
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Guid>
    {
        private readonly IAccountRepository _repoAcc;

        public CreateAccountCommandHandler(IAccountRepository repoAcc)
        {
            {
                _repoAcc = repoAcc;
            }
        }

        public async Task<Guid> Handle(
            CreateAccountCommand request,
            CancellationToken cancellationToken
        )
        {
            var createdAcc = new UserAccount { Name = request.name, Email = request.email };
            await _repoAcc.RegisterAccount(createdAcc);
            await _repoAcc.SaveChangesAsync();
            return createdAcc.UserId;
        }
    }
}
