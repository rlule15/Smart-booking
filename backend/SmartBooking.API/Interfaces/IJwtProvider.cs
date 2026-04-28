using SmartBooking.API.Models;

namespace SmartBooking.API.Interfaces
{
    public interface IJwtProvider
    {
        string? GenerateToken(User user);
    }
}
