using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using backend.DTO;

namespace backend.Extensions
{
    public static class Claims
    {
        public static UserAccountDTO GetUserNameEmail(this ClaimsPrincipal user)
        {
            return new UserAccountDTO
            {
                Name = user.FindFirstValue(ClaimTypes.Name)!,
                EmailAddress = user.FindFirstValue(ClaimTypes.Email)!,
            };
        }
    }
}
