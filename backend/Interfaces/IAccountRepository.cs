using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Class;
using backend.Controllers;

namespace backend.Interfaces
{
    public interface IAccountRepository
    {
        Task RegisterAccount(UserAccount newAccount);
        Task SaveChangesAsync();
    }
}
