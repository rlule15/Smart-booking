namespace SmartBooking.API.DTOs
{
    public record UserRegisterDto(string FirstName, string LastName, string Email, string Password);
    public record UserSignInDto(string Email, string Password);
    public record UserResponseDto(string Token);
}
