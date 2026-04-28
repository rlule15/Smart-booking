namespace SmartBooking.API.DTOs
{
    public record UserRegisterDto(string FirstName, string LastName, string Email, string Password);
    public record UserSignIn(string Email, string password);
    public record UserResponse(string Token);
}
