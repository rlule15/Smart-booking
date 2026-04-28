using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SmartBooking.API.DTOs;
using SmartBooking.API.Exceptions;
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
        public async Task<IActionResult> SignUp(UserRegisterDto userRegisterDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                await _authService.SignUpAsync(userRegisterDto.Email, userRegisterDto.FirstName, userRegisterDto.LastName, userRegisterDto.Password);
                return Ok(new { message = "User created successfully" });

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(UserSignInDto userSignInDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _authService.SignInAsync(userSignInDto.Email, userSignInDto.Password);

                if (result == null)
                {
                    return Unauthorized(new { message = "Invalid email or password" });
                }

                return Ok(result);
            }catch(TokenGenerationException ex)
            {
                return Problem(detail: ex.Message, statusCode: 500);
            }
            catch(Exception)
            {
                return Problem(detail: "An unexcpeted error occured.", statusCode: 500);
            }
        }
    }
}

