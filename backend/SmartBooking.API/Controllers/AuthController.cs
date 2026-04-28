using Microsoft.AspNetCore.Mvc;
using SmartBooking.API.Interfaces;
using SmartBooking.API.Services;

namespace SmartBooking.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(string email,string firstName, string lastName, string password)
        {
            try
            {
                await _authService.SignUpAsync(email,firstName, lastName, password);
                return Ok(new { message = "User created successfully" });

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(string email, string password)
        {
            var token = await _authService.SignInAsync(email, password);
            if (token == null)
            {
                return Unauthorized(new { message = "Invalid email or password" });
            }
            return Ok(new { token });
        }
    }
}

