using System;
using Baltazar.Data.Contracts;
using Baltazar.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Baltazar.Data.Repositories
{
	public class AppRoleManagerRepository : IAppRoleManagerRepository
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AppRoleManagerRepository(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<ApplicationRole?> GetRoleByIdAsync(string roleId)
        {
            return await _roleManager.FindByIdAsync(roleId);
        }

        public async Task<ApplicationRole?> GetRoleByNameAsync(string roleName)
        {
            return await _roleManager.FindByNameAsync(roleName);
        }

        public async Task<IEnumerable<ApplicationRole>> GetAllRolesAsync()
        {
            return await _roleManager.Roles.ToListAsync();
        }
    }
}

