using System;
using Microsoft.AspNetCore.Identity;

namespace Baltazar.Domain.Contracts
{
    public interface IUserService
    {
        public Task<IdentityResult> RegisterAndSignInUserAsync(string username, string email, string password);
    }
}

