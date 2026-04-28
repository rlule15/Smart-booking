using SmartBooking.API.DTOs;

namespace SmartBooking.API.Interfaces
{
    public interface IAuthService
    {
        Task SignUpAsync(string email,string firstName, string lastName, string password);
        Task<UserResponseDto?> SignInAsync(string email, string password);
    }
}
