using System;
using Baltazar.Data.Contracts;
using Baltazar.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Baltazar.Data.Repositories
{
	public class AppUserManagerRepository : IAppUserManagerRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AppUserManagerRepository(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}

        public async Task<ApplicationUser?> GetUserByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<ApplicationUser?> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);

            return result;
        }

        public async Task<ApplicationUser?> FindUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }
    }
}

