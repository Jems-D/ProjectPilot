using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Class;
using backend.DBContext;
using backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ProjectManagementDbContext _context;

        public AccountRepository(ProjectManagementDbContext context)
        {
            _context = context;
        }

        public async Task RegisterAccount(UserAccount newAccount)
        {
            await _context.userAccounts.AddAsync(newAccount);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
