using System;
using Baltazar.Data.Contracts;
using Baltazar.Domain.Contracts;
using Baltazar.Entity.Entities;
using Microsoft.AspNetCore.Identity;

namespace Baltazar.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAppUserManagerRepository _appUserManagerRepository;

        public UserService(
            IAppUserManagerRepository appUserManagerRepository,
           SignInManager<ApplicationUser> signInManager)
        {
            _appUserManagerRepository = appUserManagerRepository;
            _signInManager = signInManager;

        }

        public async Task<IdentityResult> RegisterAndSignInUserAsync(string username, string email, string password)
        {
            var user = new ApplicationUser { UserName = username, Email = email };
            var result = await _appUserManagerRepository.CreateUserAsync(user, password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent:false);
            }

            return result;
        }
    }
}

