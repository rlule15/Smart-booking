using Microsoft.AspNetCore.Identity;
using SmartBooking.API.Interfaces;
using SmartBooking.API.Models;

namespace SmartBooking.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtProvider _jwtProvider;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, IJwtProvider jwtProvider)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtProvider = jwtProvider;
        }

        public async Task SignUpAsync(string email,string firstName, string lastName, string password)
        {
            var existingUser = _userManager.FindByEmailAsync(email);
            if (existingUser != null)
            {
                throw new Exception("User with email alrady exists.");
            }
            var user = new User { UserName = email, Email = email, FirstName = firstName, LastName = lastName };

            var result = _userManager.CreateAsync(user, password).Result;
            if (!result.Succeeded)
            {
                throw new Exception("User creation failed: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }
        }

        public async Task<string?> SignInAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return null;
            }

            var result = _signInManager.CheckPasswordSignInAsync(user, password, false).Result;

            if (!result.Succeeded)
            {
                return null;
            }

            return _jwtProvider.GenerateToken(user);
        }
    }
}
