using System;
using Baltazar.Entity.Entities;
using Microsoft.AspNetCore.Identity;

namespace Baltazar.Data.Contracts
{
	public interface IAppUserManagerRepository
	{
        Task<ApplicationUser?> GetUserByIdAsync(string userId);
        Task<ApplicationUser?> GetUserByEmailAsync(string email);
        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
        Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password);
        Task<ApplicationUser?> FindUserByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
    }
}

