using System;
using Baltazar.Entity.Entities;

namespace Baltazar.Data.Contracts
{
	public interface IAppRoleManagerRepository
	{
        Task<ApplicationRole?> GetRoleByIdAsync(string roleId);
        Task<ApplicationRole?> GetRoleByNameAsync(string roleName);
        Task<IEnumerable<ApplicationRole>> GetAllRolesAsync();
    }
}

