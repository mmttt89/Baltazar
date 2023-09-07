using Baltazar.Domain.Contracts;
using Baltazar.Infra.Common.DTOs;
using Baltazar.Infra.Utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Baltazar.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(string email, string username, string password)
        {
            try
            {
                if (!ValidationUtils.IsValidEmail(email) || !ValidationUtils.IsValidUsername(username) || !ValidationUtils.IsValidPassword(password))
                {
                    return BadRequest(new ErrorResponse("Invalid email, username, or password."));
                }

                var result = await _userService.RegisterAndSignInUserAsync(username, email, password);

                if (result.Succeeded)
                {
                    return Ok(new OkResponse<string>("Registration successful."));
                }
                else
                {
                    return BadRequest(new ErrorResponse("Registration failed. Please check your input and try again."));
                }
            }
            catch
            {
                return StatusCode(500, new ErrorResponse("An unexpected error occurred. Please try again later."));
            }

        }

    }
}

